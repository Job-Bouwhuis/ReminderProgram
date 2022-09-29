using ReminderProgram.Data;
using SnowLibrary;

namespace ReminderProgram
{
    public partial class MainScreen : Form
    {
        public Redis redis;

        public MainScreen()
        {
            
            InitializeComponent();
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