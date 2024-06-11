using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Logout : Form
    {
        public Logout()
        { // Set the form properties
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Set the exit code to 1 (for example)
            Environment.ExitCode = 1;

            // Close the application
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu login = new Menu();
            login.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

          Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
