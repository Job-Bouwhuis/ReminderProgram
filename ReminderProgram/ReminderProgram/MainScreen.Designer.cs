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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.TaskViewer = new System.Windows.Forms.TreeView();
            this.NewButton = new System.Windows.Forms.Button();
            this.TaskDetailsButtons = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AppIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortByNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByNameAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByNameDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByProiorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByPriorityAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByPriorityDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByDateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByStartDateAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByStartDateDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.endDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByEndDateAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByEndDateDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskViewer
            // 
            this.TaskViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskViewer.Location = new System.Drawing.Point(3, 33);
            this.TaskViewer.Name = "TaskViewer";
            this.TaskViewer.Size = new System.Drawing.Size(211, 375);
            this.TaskViewer.TabIndex = 0;
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Location = new System.Drawing.Point(220, 3);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(154, 24);
            this.NewButton.TabIndex = 1;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // TaskDetailsButtons
            // 
            this.TaskDetailsButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskDetailsButtons.Location = new System.Drawing.Point(3, 3);
            this.TaskDetailsButtons.Name = "TaskDetailsButtons";
            this.TaskDetailsButtons.Size = new System.Drawing.Size(211, 24);
            this.TaskDetailsButtons.TabIndex = 2;
            this.TaskDetailsButtons.Text = "Task Details";
            this.TaskDetailsButtons.UseVisualStyleBackColor = true;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(380, 3);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(110, 23);
            this.LogoutButton.TabIndex = 3;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.Controls.Add(this.TaskViewer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NewButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TaskDetailsButtons, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LogoutButton, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(493, 411);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // AppIcon
            // 
            this.AppIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("AppIcon.Icon")));
            this.AppIcon.Text = "Reminder Program";
            this.AppIcon.Visible = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByNameToolStripMenuItem,
            this.sortByProiorityToolStripMenuItem,
            this.sortByDateToolStripMenuItem1,
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(505, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "MainScreenMenuStrip";
            // 
            // sortByNameToolStripMenuItem
            // 
            this.sortByNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortByNameAscending,
            this.SortByNameDescending});
            this.sortByNameToolStripMenuItem.Name = "sortByNameToolStripMenuItem";
            this.sortByNameToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.sortByNameToolStripMenuItem.Text = "Sort by Name";
            // 
            // SortByNameAscending
            // 
            this.SortByNameAscending.Name = "SortByNameAscending";
            this.SortByNameAscending.Size = new System.Drawing.Size(180, 22);
            this.SortByNameAscending.Text = "Ascending";
            this.SortByNameAscending.Click += new System.EventHandler(this.SortByNameAscending_Click);
            // 
            // SortByNameDescending
            // 
            this.SortByNameDescending.Name = "SortByNameDescending";
            this.SortByNameDescending.Size = new System.Drawing.Size(180, 22);
            this.SortByNameDescending.Text = "Descending";
            // 
            // sortByProiorityToolStripMenuItem
            // 
            this.sortByProiorityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortByPriorityAscending,
            this.SortByPriorityDescending});
            this.sortByProiorityToolStripMenuItem.Name = "sortByProiorityToolStripMenuItem";
            this.sortByProiorityToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.sortByProiorityToolStripMenuItem.Text = "Sort by Priority";
            // 
            // SortByPriorityAscending
            // 
            this.SortByPriorityAscending.Name = "SortByPriorityAscending";
            this.SortByPriorityAscending.Size = new System.Drawing.Size(136, 22);
            this.SortByPriorityAscending.Text = "Ascending";
            // 
            // SortByPriorityDescending
            // 
            this.SortByPriorityDescending.Name = "SortByPriorityDescending";
            this.SortByPriorityDescending.Size = new System.Drawing.Size(136, 22);
            this.SortByPriorityDescending.Text = "Descending";
            // 
            // sortByDateToolStripMenuItem1
            // 
            this.sortByDateToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDateToolStripMenuItem,
            this.endDateToolStripMenuItem});
            this.sortByDateToolStripMenuItem1.Name = "sortByDateToolStripMenuItem1";
            this.sortByDateToolStripMenuItem1.Size = new System.Drawing.Size(83, 20);
            this.sortByDateToolStripMenuItem1.Text = "Sort by Date";
            // 
            // startDateToolStripMenuItem
            // 
            this.startDateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortByStartDateAscending,
            this.SortByStartDateDescending});
            this.startDateToolStripMenuItem.Name = "startDateToolStripMenuItem";
            this.startDateToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.startDateToolStripMenuItem.Text = "Start Date";
            // 
            // SortByStartDateAscending
            // 
            this.SortByStartDateAscending.Name = "SortByStartDateAscending";
            this.SortByStartDateAscending.Size = new System.Drawing.Size(136, 22);
            this.SortByStartDateAscending.Text = "Ascending";
            // 
            // SortByStartDateDescending
            // 
            this.SortByStartDateDescending.Name = "SortByStartDateDescending";
            this.SortByStartDateDescending.Size = new System.Drawing.Size(136, 22);
            this.SortByStartDateDescending.Text = "Descending";
            // 
            // endDateToolStripMenuItem
            // 
            this.endDateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortByEndDateAscending,
            this.SortByEndDateDescending});
            this.endDateToolStripMenuItem.Name = "endDateToolStripMenuItem";
            this.endDateToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.endDateToolStripMenuItem.Text = "EndDate";
            // 
            // SortByEndDateAscending
            // 
            this.SortByEndDateAscending.Name = "SortByEndDateAscending";
            this.SortByEndDateAscending.Size = new System.Drawing.Size(136, 22);
            this.SortByEndDateAscending.Text = "Ascending";
            // 
            // SortByEndDateDescending
            // 
            this.SortByEndDateDescending.Name = "SortByEndDateDescending";
            this.SortByEndDateDescending.Size = new System.Drawing.Size(136, 22);
            this.SortByEndDateDescending.Text = "Descending";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softRefreshToolStripMenuItem,
            this.hardRefreshToolStripMenuItem});
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // softRefreshToolStripMenuItem
            // 
            this.softRefreshToolStripMenuItem.Name = "softRefreshToolStripMenuItem";
            this.softRefreshToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.softRefreshToolStripMenuItem.Text = "Soft Refresh";
            // 
            // hardRefreshToolStripMenuItem
            // 
            this.hardRefreshToolStripMenuItem.Name = "hardRefreshToolStripMenuItem";
            this.hardRefreshToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.hardRefreshToolStripMenuItem.Text = "Hard Refresh";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 476);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reminder Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button NewButton;
        private Button TaskDetailsButtons;
        private Button LogoutButton;
        private TableLayoutPanel tableLayoutPanel1;
        internal NotifyIcon AppIcon;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sortByNameToolStripMenuItem;
        private ToolStripMenuItem sortByProiorityToolStripMenuItem;
        private ToolStripMenuItem SortByNameAscending;
        private ToolStripMenuItem SortByNameDescending;
        private ToolStripMenuItem SortByPriorityAscending;
        private ToolStripMenuItem SortByPriorityDescending;
        private ToolStripMenuItem sortByDateToolStripMenuItem1;
        private ToolStripMenuItem startDateToolStripMenuItem;
        private ToolStripMenuItem SortByStartDateAscending;
        private ToolStripMenuItem SortByStartDateDescending;
        private ToolStripMenuItem endDateToolStripMenuItem;
        private ToolStripMenuItem SortByEndDateAscending;
        private ToolStripMenuItem SortByEndDateDescending;
        internal TreeView TaskViewer;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem softRefreshToolStripMenuItem;
        private ToolStripMenuItem hardRefreshToolStripMenuItem;
    }
}