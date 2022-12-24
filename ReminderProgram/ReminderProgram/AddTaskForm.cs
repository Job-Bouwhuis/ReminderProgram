using ReminderProgram.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReminderProgram
{
    public partial class AddTaskForm : Form, IDisposable
    {
        public UserTask constructedTask;
        public AddTaskForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TaskNameInput.Text))
            {
                MessageBox.Show("Task must have a name", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            constructedTask = new();

            constructedTask.taskName = TaskNameInput.Text;
            DateTime time = StartDateInput.Value;
            constructedTask.startDate = new DateTime(
                                        time.Year,
                                        time.Month,
                                        time.Day,
                                        TypeWorker.CastPrimitive<int>(StartDateHourInput.Value),
                                        TypeWorker.CastPrimitive<int>(StartDateMinuteInput.Value),
                                        0);
            time = EndDateInput.Value;
            constructedTask.endDate = new DateTime(
                            time.Year,
                            time.Month,
                            time.Day,
                            TypeWorker.CastPrimitive<int>(EndDateHourInput.Value),
                            TypeWorker.CastPrimitive<int>(EndDateMinuteInput.Value),
                            0);
            constructedTask.priority = TypeWorker.CastPrimitive<int>(PriorityInput.Value);
            Close();
        }

        public new void Dispose()
        {
            Dispose(true);
        }
    }
}
