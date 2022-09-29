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
            redis = GetConnection();
            _ = redis.Connect();
            redis.OnRedisConnect += RedisConnected;
           
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


        public void RedisConnected()
        {
            redis.GetAllKeys()?.Foreach(x => TaskViewer.Nodes.Add(x));
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
            redis.Dispose();
            redis = GetConnection(true);
        }
    }
}