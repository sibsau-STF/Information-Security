using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class AuthForm : Form
    {
        public string Username { get; set; }
        public string Password { get; set; }

        Form1 main;
        public AuthForm(Form1 form)
        {
            Username = "";
            Password = "";
            InitializeComponent();

            main = form;
        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Username = usernameTextBox.Text;
            Password = passTextBox.Text;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }

        private void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //main.Close();
        }
    }
}
