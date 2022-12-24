using ReminderProgram.Data;
using WinterRose.Serialization;
using WinterRose.WIP.Redis;

namespace ReminderProgram;

public partial class MainScreen : Form
{
    public RedisConnection redis;

    public MainScreen()
    {
        InitializeComponent();
        redis = GetConnection();
        OnRedisConnected();
    }

    public async Task<bool> ShowTasks()
    {
        if (TaskViewer.Nodes.Count > 0)
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
            List<UserTask> userTasks = new();

            redis.GetKeysByPattern("*").Value.Foreach(x => userTasks.Add(SnowSerializer.DeserializeWIP<UserTask>(redis.Get<string, string>(x))));
            return userTasks;
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
        var addScreen = new Form();

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
            redis = GetConnection(forceGetCredentials: true);
            if (redis.IsConnected)
                break;
        }

        Show();
        _ = ShowTasks();
    }
    private RedisConnection GetConnection(bool forceGetCredentials = false)
    {
        Connection connection;
        try
        {
            connection = SnowSerializer.DeserializeWIP<Connection>(AppSettings.Default.DefualtConnection);
            if (forceGetCredentials || connection == null || connection.port == 0)
            {
                throw new Exception("yes");
            }
            return new(connection!.connection, connection.port, connection.password!);
        }
        catch
        {
            if (!forceGetCredentials)
            {
                var result = MessageBox.Show("Failed to connect. \n" +
                                             "   Yes: Try again, \n" +
                                             "   No: abort, \n" +
                                             "   Cancel: log out", 
                                             
                                             "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                
                if (result == DialogResult.No)
                    Environment.Exit(0);
            }
            try
            {
                LoginScreen login = new();
                connection = login.Login();
                return new(connection!.connection, connection.port, connection.password!);
            }
            catch
            {
                MessageBox.Show("Credentials are invalid or there is no internet access.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return null;
            }
        }
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
        List<CloseReason> reasonsToIgnoreConfirmation = new List<CloseReason>() 
        { CloseReason.TaskManagerClosing, CloseReason.FormOwnerClosing, CloseReason.WindowsShutDown, CloseReason.ApplicationExitCall };
        
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

    private void SortByNameAscending_Click(object sender, EventArgs e)
    {

    }
}


public enum TaskSortMode
{
    /// <summary>
    /// Used to sort the tasks by their start date in ascending order
    /// </summary>
    StartDate,
    /// <summary>
    /// Used to sort the tasks by their start date in descending order
    /// </summary>
    StartDateDescending,
    /// <summary>
    /// Used to sort the tasks by their end date in ascending order
    /// </summary>
    EndDate,
    /// <summary>
    /// Used to sort the tasks by their end date in descending order
    /// </summary>
    EndDateDescending,
    /// <summary>
    /// Used to sort the tasks by their priority in ascending order
    /// </summary>
    Priority,
    /// <summary>
    /// Used to sort the tasks by their priority in descending order
    /// </summary>
    PriorityDescending,
    /// <summary>
    /// Used to sort the tasks by their name in ascending order
    /// </summary>
    Name,
    /// <summary>
    /// Used to sort the tasks by their name in descending order
    /// </summary>
    NameDescending
}