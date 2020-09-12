using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class UpdatePassForm : Form
    {
        public User user { get; set; }

        public UpdatePassForm(User user)
        {
            InitializeComponent();

            this.user = user;
        }

        private void UpdatePassForm_Load(object sender, EventArgs e)
        {
            if(user.password == "")
            {
                label1.Hide();
                oldPassTextBox.Hide();
            }
            if(user.constraint == true)
            {
                constraintLabel.Text = "Запрещенные знаки:\n1. Цифры\n2.Знаки +,-,*,/";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
        }
    }
}
