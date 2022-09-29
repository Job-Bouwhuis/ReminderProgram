using SnowLibrary;

namespace ReminderProgram
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            _ = "Reminder Program".StringAnimation(10).ForeachAsync(x => Text = x);
        }

    }
}