namespace ReminderProgram
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.NewButton = new System.Windows.Forms.Button();
            this.TaskDetailsButtons = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(261, 426);
            this.treeView1.TabIndex = 0;
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(279, 12);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(124, 23);
            this.NewButton.TabIndex = 1;
            this.NewButton.Text = "New Task";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // TaskDetailsButtons
            // 
            this.TaskDetailsButtons.Location = new System.Drawing.Point(279, 41);
            this.TaskDetailsButtons.Name = "TaskDetailsButtons";
            this.TaskDetailsButtons.Size = new System.Drawing.Size(124, 23);
            this.TaskDetailsButtons.TabIndex = 2;
            this.TaskDetailsButtons.Text = "Task Details";
            this.TaskDetailsButtons.UseVisualStyleBackColor = true;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 450);
            this.Controls.Add(this.TaskDetailsButtons);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.treeView1);
            this.Name = "MainScreen";
            this.Text = "Reminder Program";
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView treeView1;
        private Button NewButton;
        private Button TaskDetailsButtons;
    }
}