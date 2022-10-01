using Microsoft.VisualBasic.Logging;
using ReminderProgram.Data;
using SnowLibrary;
using SnowLibrary.Serialization;
using StackExchange.Redis;
using System.CodeDom;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ReminderProgram
{
    public partial class MainScreen : Form
    {
        public Redis redis;
        TaskHandler taskHandler;
        public TaskSortMode taskSortMode = TaskSortMode.Name;
        bool sortAscending = true;

        public MainScreen()
        {
            taskHandler = new(this);
            InitializeComponent();
            redis = GetConnection();
            _ = redis.ConnectAsync();
            redis.OnRedisConnect += OnRedisConnected;

            Clipboard.SetText(AppSettings.Default.DefualtConnection);
        }

        public void WindowsNotification(string title, string content, int duration = 2000, ToolTipIcon icon = ToolTipIcon.Info)
        {
            AppIcon.ShowBalloonTip(duration, title, content, icon);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            var addScreen = new AddScreen();
            addScreen.Owner = this;
            addScreen.ShowInTaskbar = false;

            Hide();
            addScreen.ShowDialog();
            Show();
            addScreen.Dispose();
        }
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No)
                return;

            Hide();
            while (true)
            {
                redis.Dispose();
                redis = GetConnection(forceLogin: true);
                bool r = redis.Connect();
                if (r)
                    break;
            }

            Show();
            _ = taskHandler.ShowTasks(taskSortMode, true);
        }
        private static Redis GetConnection(bool forceLogin = false)
        {
            Connection connection = SnowSerializer.Deserialize<Connection>(AppSettings.Default.DefualtConnection);
            if (forceLogin || connection == null || connection.port == 0)
            {
                LoginScreen login = new();
                connection = login.Login();
            }
            return new(connection);
        }
        private void OnRedisConnected()
        {
            TaskViewer.Nodes.Clear();
            taskHandler.currentTasks = taskHandler.GetNewTasks();
            _ = taskHandler.ShowTasks(taskSortMode, true);
        }

        //if the application is closing this method is called
        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //create a fast list for every close reason it should accept the closing regardless of the situation
            List<CloseReason> reasonsToIgnoreConfirmation = new List<CloseReason>() { CloseReason.TaskManagerClosing, CloseReason.FormOwnerClosing, CloseReason.WindowsShutDown, CloseReason.ApplicationExitCall };
            if (!reasonsToIgnoreConfirmation.Contains(e.CloseReason))
            {
                //if the current close reason does not consist of the previous created list then promt the user with the question whether it was intended to close the application or not
                var result = MessageBox.Show("Do you want to close the application?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    //if not then hide the application to the system tray and cancel the closing
                    e.Cancel = true;
                    Hide();
                    WindowsNotification("Moved to system tray!", "Task Manager is now running in the background.", 1000);
                }
            }
            if (!e.Cancel)
            {
                redis.Dispose();
            }
        }

        //When the app icon in the task bar's ^ is pressed once the application will show and put itself on the foreground
        private void AppIcon_MouseDown(object sender, MouseEventArgs e)
        {
            Show();
            Activate();
            WindowState = FormWindowState.Normal;
        }

        private void SortByNameAscending_Click(object sender, EventArgs e)
        {
            taskSortMode = TaskSortMode.Name;
            sortAscending = true;
            _ = taskHandler.ShowTasks(taskSortMode, sortAscending);
        }
        private void SortByNameDescending_Click(object sender, EventArgs e)
        {
            taskSortMode = TaskSortMode.Name;
            sortAscending = false;
            _ = taskHandler.ShowTasks(taskSortMode, sortAscending);
        }
        private void SortByPriorityAscending_Click(object sender, EventArgs e)
        {
            taskSortMode = TaskSortMode.Priority;
            sortAscending = true;
            _ = taskHandler.ShowTasks(taskSortMode, sortAscending);
        }
        private void SortByPriorityDescending_Click(object sender, EventArgs e)
        {
            taskSortMode = TaskSortMode.Priority;
            sortAscending = false;
            _ = taskHandler.ShowTasks(taskSortMode, sortAscending);
        }

        private void SortByStartDateAscending_Click(object sender, EventArgs e)
        {
            taskSortMode = TaskSortMode.StartDate;
            sortAscending = true;
            _ = taskHandler.ShowTasks(taskSortMode, sortAscending);
        }
        private void SortByStartDateDescending_Click(object sender, EventArgs e)
        {
            taskSortMode = TaskSortMode.StartDate;
            sortAscending = false;
            _ = taskHandler.ShowTasks(taskSortMode, sortAscending);
        }

        private void SortByEndDateAscending_Click(object sender, EventArgs e)
        {
            taskSortMode = TaskSortMode.EndDate;
            sortAscending = true;
            _ = taskHandler.ShowTasks(taskSortMode, sortAscending);
        }
        private void SortByEndDateDescending_Click(object sender, EventArgs e)
        {
            taskSortMode = TaskSortMode.EndDate;
            sortAscending = false;
            _ = taskHandler.ShowTasks(taskSortMode, sortAscending);
        }

        private void softRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<UserTask> newTasks = new();
            redis.GetAllValues().Foreach(x => newTasks.Add(SnowSerializer.Deserialize<UserTask>(x)));

            foreach(var task in newTasks)
            {
            }
        }
    }

    public enum TaskSortMode
    {
        Name,
        Priority,
        StartDate,
        EndDate
    }

    public class TaskHandler
    {
        MainScreen ms;
        public List<UserTask> currentTasks = new();
        public TaskHandler(MainScreen ms)
        {
            this.ms = ms;
        }

        public bool TaskExists(string name) => currentTasks.Any(x => x.taskName == name);

        public List<UserTask> GetNewTasks()
        {
            List<UserTask> newTasks = new();
            ms.redis.GetAllValues().Foreach(x => SnowSerializer.Deserialize<UserTask>(x));
            return newTasks;
        }

        public async Task<bool> ShowTasks(TaskSortMode sortingmode, bool ascending)
        {
            var tv = ms.TaskViewer;
            var n = tv.Nodes;

            if (tv.Nodes.Count > 0)
                await ClearTaskView();
            currentTasks = SortTasks();

            if (sortingmode == TaskSortMode.Name)
                foreach(var task in currentTasks)
                {
                    n.Add(new TreeNode(task.taskName));
                    await Task.Delay(35);
                }

            if (sortingmode == TaskSortMode.Priority)
            {
                foreach (var task in currentTasks)
                {
                    List<string> nodeTextList = new();
                    foreach (TreeNode node in tv.Nodes)
                        nodeTextList.Add(node.Text);
                    if (!nodeTextList.Contains(task.priority.ToString()))
                    {
                        n.Add(task.priority.ToString());
                        await Task.Delay(35);
                    }
                }

                foreach (TreeNode sn in n)
                {
                    foreach (var task in currentTasks.Where(x => x.priority.ToString() == sn.Text))
                    {
                        sn.Nodes.Add(task.taskName);
                        await Task.Delay(35);
                    }
                }


            }

            if(sortingmode == TaskSortMode.StartDate)
            {
                foreach(var task in currentTasks)
                {
                    List<string> nodeTextList = new();
                    foreach (TreeNode node in tv.Nodes)
                        nodeTextList.Add(node.Text);

                    if (!nodeTextList.Contains(task.startDate.ToString("dddd dd MMMM : yyyy")))
                    {
                        n.Add(task.startDate.ToString("dddd dd MMMM : yyyy"));
                        await Task.Delay(35);
                    }
                }
                foreach (TreeNode sn in n)
                {
                    foreach (var task in currentTasks.Where(x => x.startDate.ToString("dddd dd MMMM : yyyy") == sn.Text))
                    {
                        sn.Nodes.Add(task.taskName);
                        await Task.Delay(35);
                    }
                }
            }
            foreach (TreeNode node in n)
            {
                node.Expand();
                await Task.Delay(35);
            }
            return true;

            List<UserTask> SortTasks()
            {
                IOrderedEnumerable<UserTask> result = sortingmode switch
                {
                    TaskSortMode.Name => ascending ? currentTasks.OrderBy(x => x.taskName) : currentTasks.OrderByDescending(x => x.taskName),
                    TaskSortMode.Priority => ascending ? currentTasks.OrderBy(x => x.priority) : currentTasks.OrderByDescending(x => x.priority),
                    TaskSortMode.StartDate => ascending ? currentTasks.OrderBy(x => x.startDate) : currentTasks.OrderByDescending(x => x.startDate),
                    TaskSortMode.EndDate => ascending ? currentTasks.OrderBy(x => x.endDate) : currentTasks.OrderByDescending(x => x.endDate),
                    _ => currentTasks.OrderBy(x => x.taskName)
                };
                return result.ToList();
            }
        }
        public async Task<bool> ClearTaskView(bool fancy = true)
        {
            int initialCount = ms.TaskViewer.Nodes.Count;
            for (int i1 = 0; i1 < initialCount; i1++)
            {
                TreeNode node = ms.TaskViewer.Nodes[0];
                
                System.Collections.IList list1 = node.Nodes;
                int subInitialCount = list1.Count;
                for (int i = 0; i < subInitialCount; i++)
                {
                    node.Nodes.Remove(node.FirstNode);
                    await Task.Delay(fancy ? 35 : 0);
                }

                ms.TaskViewer.Nodes.RemoveAt(0);
                await Task.Delay(fancy ? 35 : 0);
            }
            return true;
        }

        public async Task<bool> RefreshTasks()
        {
            await ClearTaskView(true);
            await Task.Delay(100);
            return await ShowTasks(ms.taskSortMode, true);
        }
    }
}