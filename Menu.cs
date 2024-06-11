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
    public partial class Menu : Form
    {
        public Menu()
        {
            // Set the form properties
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           NotepadHomePage login = new NotepadHomePage();
            login.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         ReportMenu menu = new ReportMenu();
            menu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contact_doctor login = new Contact_doctor();
            login.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Extra button deleted
        }

        private void button6_Click(object sender, EventArgs e)
        {
           Check_appointment health = new Check_appointment ();//Show the new form
            health.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Track_Mood nextPage = new Track_Mood();
            nextPage.Show();  // Show the new form
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Health_Status nextPage = new Health_Status();
            nextPage.Show();  // Show the new form
            this.Hide();
        }
    }
}
