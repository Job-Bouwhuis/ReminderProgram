namespace ReminderProgram
{
    partial class AddTaskForm
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
            this.TaskNameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionInput = new System.Windows.Forms.TextBox();
            this.StartDateInput = new System.Windows.Forms.DateTimePicker();
            this.EndDateInput = new System.Windows.Forms.DateTimePicker();
            this.StartDateHourInput = new System.Windows.Forms.NumericUpDown();
            this.StartDateMinuteInput = new System.Windows.Forms.NumericUpDown();
            this.EndDateHourInput = new System.Windows.Forms.NumericUpDown();
            this.EndDateMinuteInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PriorityInput = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateHourInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateMinuteInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDateHourInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDateMinuteInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskNameInput
            // 
            this.TaskNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskNameInput.Location = new System.Drawing.Point(12, 37);
            this.TaskNameInput.Name = "TaskNameInput";
            this.TaskNameInput.Size = new System.Drawing.Size(755, 23);
            this.TaskNameInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Task Name*";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripton (optional)";
            // 
            // DescriptionInput
            // 
            this.DescriptionInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionInput.Location = new System.Drawing.Point(12, 300);
            this.DescriptionInput.Multiline = true;
            this.DescriptionInput.Name = "DescriptionInput";
            this.DescriptionInput.Size = new System.Drawing.Size(758, 129);
            this.DescriptionInput.TabIndex = 2;
            // 
            // StartDateInput
            // 
            this.StartDateInput.Location = new System.Drawing.Point(12, 160);
            this.StartDateInput.Name = "StartDateInput";
            this.StartDateInput.Size = new System.Drawing.Size(200, 23);
            this.StartDateInput.TabIndex = 4;
            // 
            // EndDateInput
            // 
            this.EndDateInput.Location = new System.Drawing.Point(285, 160);
            this.EndDateInput.Name = "EndDateInput";
            this.EndDateInput.Size = new System.Drawing.Size(200, 23);
            this.EndDateInput.TabIndex = 5;
            // 
            // StartDateHourInput
            // 
            this.StartDateHourInput.Location = new System.Drawing.Point(19, 193);
            this.StartDateHourInput.Name = "StartDateHourInput";
            this.StartDateHourInput.Size = new System.Drawing.Size(45, 23);
            this.StartDateHourInput.TabIndex = 6;
            // 
            // StartDateMinuteInput
            // 
            this.StartDateMinuteInput.Location = new System.Drawing.Point(83, 193);
            this.StartDateMinuteInput.Name = "StartDateMinuteInput";
            this.StartDateMinuteInput.Size = new System.Drawing.Size(45, 23);
            this.StartDateMinuteInput.TabIndex = 7;
            // 
            // EndDateHourInput
            // 
            this.EndDateHourInput.Location = new System.Drawing.Point(295, 193);
            this.EndDateHourInput.Name = "EndDateHourInput";
            this.EndDateHourInput.Size = new System.Drawing.Size(45, 23);
            this.EndDateHourInput.TabIndex = 8;
            // 
            // EndDateMinuteInput
            // 
            this.EndDateMinuteInput.Location = new System.Drawing.Point(357, 193);
            this.EndDateMinuteInput.Name = "EndDateMinuteInput";
            this.EndDateMinuteInput.Size = new System.Drawing.Size(45, 23);
            this.EndDateMinuteInput.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = ":";
            // 
            // PriorityInput
            // 
            this.PriorityInput.Location = new System.Drawing.Point(524, 160);
            this.PriorityInput.Name = "PriorityInput";
            this.PriorityInput.Size = new System.Drawing.Size(120, 23);
            this.PriorityInput.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Start Date/Time*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "End Date/Time*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(524, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Priority*";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(692, 66);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 16;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(611, 66);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 17;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // AddTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 441);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PriorityInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EndDateMinuteInput);
            this.Controls.Add(this.EndDateHourInput);
            this.Controls.Add(this.StartDateMinuteInput);
            this.Controls.Add(this.StartDateHourInput);
            this.Controls.Add(this.EndDateInput);
            this.Controls.Add(this.StartDateInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescriptionInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TaskNameInput);
            this.Name = "AddTaskForm";
            this.Text = "Add Task";
            ((System.ComponentModel.ISupportInitialize)(this.StartDateHourInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDateMinuteInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDateHourInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDateMinuteInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TaskNameInput;
        private Label label1;
        private Label label2;
        private TextBox DescriptionInput;
        private DateTimePicker StartDateInput;
        private DateTimePicker EndDateInput;
        private NumericUpDown StartDateHourInput;
        private NumericUpDown StartDateMinuteInput;
        private NumericUpDown EndDateHourInput;
        private NumericUpDown EndDateMinuteInput;
        private Label label3;
        private Label label4;
        private NumericUpDown PriorityInput;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button CancelButton;
        private Button SubmitButton;
    }
}