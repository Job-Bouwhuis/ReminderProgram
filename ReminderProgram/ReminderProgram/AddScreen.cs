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
    public partial class AddScreen : Form
    {
        public AddScreen()
        {
            InitializeComponent();
            AddItems();
        }

        public void AddItems()
        {
            foreach (string priority in AddScreenUtilities.GetPriorities())
            {
                dataGridViewComboBoxColumn1.Items.Add(priority);
            }
        }

    }
}
