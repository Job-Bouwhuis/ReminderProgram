using Microsoft.VisualBasic.Logging;
using ReminderProgram.Data;
using SnowLibrary;
using SnowLibrary.Serialization;

namespace ReminderProgram
{
    public partial class MainScreen : Form
    {
        public Redis redis;

        public MainScreen()
        {
            InitializeComponent();
            ConnectToRedis();
        }
        public void ConnectToRedis()
        {
            Connection connection = SnowSerializer.Deserialize<Connection>(AppSettings.Default.DefualtConnection);
            if(connection == null || connection.port == 0)
            {
                LoginScreen login = new();
                connection = login.Login();
            }
            redis = new(connection);

            redis.GetAllKeys()?.Foreach(x => TaskViewer.Nodes.Add(new TreeNode(x)));
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            var addScreen = new AddScreen();

            Hide();
            addScreen.ShowDialog();
            Show();
        }
    }
}