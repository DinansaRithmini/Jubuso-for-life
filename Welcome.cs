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
    public partial class Welcome : Form
    {
        public Welcome()
        {// Set the form properties
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Set the minimum and maximum values for the progress bar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            // Update the progress bar value
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;

                // Simulate a delay to show progress
                System.Threading.Thread.Sleep(50);
            }

            // Reset the progress bar when the task is complete
            progressBar1.Value = 0;



            Login login = new Login();
            login.Show();
            this.Hide();
        }



        private void Welcome_Load(object sender, EventArgs e)
        {
        }
    }
}