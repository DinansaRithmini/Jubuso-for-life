using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using WindowsFormsApp8;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp8
{
    public partial class Anxiety_Release_Classes : Form
    {
        public Anxiety_Release_Classes()
        {   
            // Set the form properties
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null)
                {
                    this.BackColor = Color.LightSalmon;
                    MessageBox.Show("Please select a class", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBox2.SelectedItem == null)
                {
                    this.BackColor = Color.LightSalmon;
                    MessageBox.Show("Please select a day", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double total = CalculateTotal();
                Amount_per_session.Text = total.ToString(); // Automatically display the total

                // Continue with your database insertion code
                string connectionString = "Server=localhost;Database=Project;Uid=root;Pwd=Dinansa@2005;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO classes (class, days, sessions,amount) VALUES (@class, @days, @sessions, @amount)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        string Select_the_class = comboBox1.SelectedItem.ToString();
                        string Select_the_day = comboBox2.SelectedItem.ToString();
                        int no_of_days = (int)numericUpDown1.Value;

                        command.Parameters.AddWithValue("@class", Select_the_class);
                        command.Parameters.AddWithValue("@days", Select_the_day);
                        command.Parameters.AddWithValue("@sessions", no_of_days);
                        command.Parameters.AddWithValue("@amount", total);

                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data saved successfully!");
                Payment login = new Payment();
                login.TotalFromAnxietyRelease = total;
                login.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private double CalculateTotal()
        {
            double total = 0;
            string selectedClass = comboBox1.SelectedItem.ToString();

            if (selectedClass == "Mindfulness and Meditation Classes")
            {
                total = 2000;
            }
            else if (selectedClass == "Yoga Classes")
            {
                total = 1500;
            }
            else if (selectedClass == "Cognitive-Behavioral Therapy (CBT) Workshops")
            {
                total = 1000;
            }
            else if (selectedClass == "Breathing and Relaxation Classes")
            {
                total = 2000;
            }
            else if (selectedClass == "Art and Creative Therapy Classes")
            {
                total = 3000;
            }

            return total; 
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
    }





/* static class Program
{
 [STAThread]
 static void Main()
 {
     Application.EnableVisualStyles();
     Application.SetCompatibleTextRenderingDefault(false);
     Application.Run(new Anxiety_Release_Classes());
 }
}*/









