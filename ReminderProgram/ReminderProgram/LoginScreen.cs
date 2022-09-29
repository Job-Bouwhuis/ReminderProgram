using ReminderProgram.Data;
using SnowLibrary.Serialization;

namespace ReminderProgram;

public partial class LoginScreen : Form
{
    private Connection connection = new();

    public LoginScreen() => InitializeComponent();

    public Connection Login()
    {
        ShowDialog();
        return AppSettings.Default.DefualtConnection.Deserialize<Connection>();
    }

    private void ConnectionInputBox_TextChanged(object sender, EventArgs e) => connection.connection = ConnectionInputBox.Text;

    private void PasswordInputBox_TextChanged(object sender, EventArgs e) => connection.password = PasswordInputBox.Text;

    private void PortInputBox_ValueChanged(object sender, EventArgs e) => connection.port = (int)PortInputBox.Value;

    private void SubmitCridentialsButton_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(SerializedConnectionInput.Text))
        {
            Connection connection = SnowSerializer.Deserialize<Connection>(SerializedConnectionInput.Text);
            if (connection != null && !string.IsNullOrWhiteSpace(connection.connection))
                this.connection = connection;
        }
        AppSettings.Default.DefualtConnection = SnowSerializer.Serialize(connection);
        AppSettings.Default.Save();
        Close();
    }
}

