using Microsoft.VisualBasic.Logging;
using ReminderProgram.Data;
using SnowLibrary;
using SnowLibrary.Serialization;
using System.CodeDom;
using System.Runtime.CompilerServices;

namespace ReminderProgram
{
    public partial class MainScreen : Form
    {
        public Redis redis;
        public MainScreen()
        {
            InitializeComponent();
            redis = GetConnection();
            _ = redis.ConnectAsync();
            redis.OnRedisConnect += OnRedisConnected;

            Clipboard.SetText(AppSettings.Default.DefualtConnection);
        }

        public async Task<bool> ShowTasks()
        {
            if(TaskViewer.Nodes.Count > 0)
            {
                await ClearTaskViewer();
            }
            List<UserTask> userTasks = new();
            userTasks = GetAllTasks().OrderBy(x => x.startDate).ToList();

            foreach (var task in userTasks)
            {
                if (TaskViewer.Nodes.ContainsKey(task.startDate.ToString("dddd, dd MMMM yyyy")))
                    continue;
                TaskViewer.Nodes.Add(task.startDate.ToString("dddd, dd MMMM yyyy"));
                await Task.Delay(35);
            }

            await Task.Delay(100);

            foreach (TreeNode node in TaskViewer.Nodes)
            {
                foreach (var task in userTasks.Where(x => x.startDate.ToString("dddd, dd MMMM yyyy") == node.Text))
                {
                    node.Nodes.Add(task.taskName);
                    await Task.Delay(35);
                }
            }

            await Task.Delay(100);
            if (TaskViewer.Nodes.Count < 15)
                foreach (TreeNode node in TaskViewer.Nodes)
                {
                    node.Expand();
                    await Task.Delay(35);
                }

            return true;

            List<UserTask> GetAllTasks()
            {
                // Task.Run(() =>
                // {
                List<UserTask> userTasks = new();
                redis.GetAllKeys().Foreach(x => userTasks.Add(SnowSerializer.Deserialize<UserTask>(redis.Get(x))));
                return userTasks;
                //});
                //throw new Exception("GetAllTasks method failed to execute");
            }
        }
        public async Task<bool> ClearTaskViewer()
        {
            foreach (TreeNode node in TaskViewer.Nodes)
                foreach (TreeNode n in node.Nodes)
                {
                    node.Nodes.Remove(n);
                    await Task.Delay(35);
                }

            await Task.Delay(100);

            System.Collections.IList list = TaskViewer.Nodes;
            for (int i = 0; list.Count > 0; i = 0)
            {
                TreeNode node = (TreeNode)list[i];
                if (node.Nodes.Count == 0)
                    TaskViewer.Nodes.RemoveAt(i);
                await Task.Delay(35);
            }
            return true;
        }
        public async Task<bool> RefreshTasks()
        {
            await ClearTaskViewer();
            await Task.Delay(100);
            return await ShowTasks();
        }
        public void WindowsNotification(string title, string content, int showDurationInMiliseconds = 2000, ToolTipIcon icon = ToolTipIcon.Info)
        {
            AppIcon.BalloonTipIcon = icon;
            AppIcon.BalloonTipTitle = title;
            AppIcon.BalloonTipText = content;
            AppIcon.ShowBalloonTip(showDurationInMiliseconds);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            var addScreen = new AddScreen();

            Hide();
            addScreen.ShowDialog();
            Show();
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
            _ = ShowTasks();
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
            _ = ShowTasks();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            _ = RefreshTasks();
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<CloseReason> reasonsToIgnoreConfirmation = new List<CloseReason>() { CloseReason.TaskManagerClosing, CloseReason.FormOwnerClosing, CloseReason.WindowsShutDown, CloseReason.ApplicationExitCall };
            if (!reasonsToIgnoreConfirmation.Contains(e.CloseReason))
            {
                var result = MessageBox.Show("Do you want to close the application?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    Hide();
                    WindowsNotification("Moved to system tray!", "Task Manager is now running in the background.", 1000);
                }
            }
        }


    }
}