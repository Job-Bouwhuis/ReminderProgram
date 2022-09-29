namespace ReminderProgram
{
    partial class LoginScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PasswordInputBox = new System.Windows.Forms.TextBox();
            this.ConnectionInputBox = new System.Windows.Forms.TextBox();
            this.PortInputBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SubmitCridentialsButton = new System.Windows.Forms.Button();
            this.SerializedConnectionInput = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortInputBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.PasswordInputBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ConnectionInputBox, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // PasswordInputBox
            // 
            resources.ApplyResources(this.PasswordInputBox, "PasswordInputBox");
            this.PasswordInputBox.Name = "PasswordInputBox";
            this.PasswordInputBox.TextChanged += new System.EventHandler(this.PasswordInputBox_TextChanged);
            // 
            // ConnectionInputBox
            // 
            resources.ApplyResources(this.ConnectionInputBox, "ConnectionInputBox");
            this.ConnectionInputBox.Name = "ConnectionInputBox";
            this.ConnectionInputBox.TextChanged += new System.EventHandler(this.ConnectionInputBox_TextChanged);
            // 
            // PortInputBox
            // 
            resources.ApplyResources(this.PortInputBox, "PortInputBox");
            this.PortInputBox.Maximum = new decimal(new int[] {
            -1981284352,
            -1966660860,
            0,
            0});
            this.PortInputBox.Name = "PortInputBox";
            this.PortInputBox.ValueChanged += new System.EventHandler(this.PortInputBox_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // SubmitCridentialsButton
            // 
            resources.ApplyResources(this.SubmitCridentialsButton, "SubmitCridentialsButton");
            this.SubmitCridentialsButton.Name = "SubmitCridentialsButton";
            this.SubmitCridentialsButton.UseVisualStyleBackColor = true;
            this.SubmitCridentialsButton.Click += new System.EventHandler(this.SubmitCridentialsButton_Click);
            // 
            // SerializedConnectionInput
            // 
            resources.ApplyResources(this.SerializedConnectionInput, "SerializedConnectionInput");
            this.SerializedConnectionInput.Name = "SerializedConnectionInput";
            // 
            // LoginScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SerializedConnectionInput);
            this.Controls.Add(this.SubmitCridentialsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.PortInputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LoginScreen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortInputBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox PasswordInputBox;
        private TextBox ConnectionInputBox;
        private NumericUpDown PortInputBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button SubmitCridentialsButton;
        private TextBox SerializedConnectionInput;
    }
}