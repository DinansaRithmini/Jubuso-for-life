using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;


namespace WindowsFormsApp8
{
    public partial class ReportMenu : Form
    {
        public ReportMenu()
        { // Set the form properties
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
           
           Report1 r1 =new Report1();
            r1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();

        }

        private void ReportMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report2 r1 = new Report2();
            r1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Report3 r3 = new Report3();
            r3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report4 r1 = new Report4();
            r1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report5 r1 = new Report5();
            r1.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Logout r1 = new Logout();  
            r1.ShowDialog();
        }
    }
}
