using ReminderProgram.Data;
using WinterRose.Serialization;

namespace ReminderProgram;

public partial class LoginScreen : Form
{
    private Connection connection = new();

    public LoginScreen() => InitializeComponent();

    public Connection Login()
    {
        ShowDialog();
        return SnowSerializer.DeserializeWIP<Connection>(AppSettings.Default.DefualtConnection);
    }

    private void ConnectionInputBox_TextChanged(object sender, EventArgs e) => connection.connection = ConnectionInputBox.Text;

    private void PasswordInputBox_TextChanged(object sender, EventArgs e) => connection.password = PasswordInputBox.Text;

    private void PortInputBox_ValueChanged(object sender, EventArgs e) => connection.port = (int)PortInputBox.Value;

    private void SubmitCridentialsButton_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(SerializedConnectionInput.Text))
        {
            Connection connection = SnowSerializer.DeserializeWIP<Connection>(SerializedConnectionInput.Text);
            if (connection != null && !string.IsNullOrWhiteSpace(connection.connection))
                this.connection = connection;
        }
        AppSettings.Default.DefualtConnection = SnowSerializer.SerializeWIP(connection);
        AppSettings.Default.Save();
        Close();
    }
}

