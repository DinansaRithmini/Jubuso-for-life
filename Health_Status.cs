using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp8
{
    public partial class Health_Status : Form
    {
        public Health_Status()
        {    // Set the form properties
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=Project;Uid=root;Pwd=Dinansa@2005;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string Patient_name = textBox1.Text; // Get the patient from the TextBox
                    string Check_insurance = GetInsurance();
                    string Check_past_injuries = GetInjuries();
                    string Check_allergies = GetAllergies();

                    if (string.IsNullOrWhiteSpace(Patient_name))
                    {
                        this.BackColor = Color.LightSalmon;
                        MessageBox.Show("Patient name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   
                  if (radioButton1.Checked||radioButton2.Checked)
                    {
                        
                    }
                    else
                    {
                        this.BackColor = Color.LightSalmon;
                        MessageBox.Show("Select yes or no for insurance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   if (radioButton3.Checked||radioButton4.Checked)
                    {
                       
                    }
                   else
                    {
                        this.BackColor = Color.LightSalmon;
                        MessageBox.Show("Select yes or no for past injuries", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                   if (radioButton5.Checked||radioButton6.Checked)
                    {
                       
                    }
                   else
                    {
                        this.BackColor = Color.LightSalmon;
                        MessageBox.Show("Provide an answer for allergies", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    { 
                        string query = "INSERT INTO health_status (Patient_name,Check_insurance,Check_past_injuries,Check_allergies) VALUES (@Patient_name,@Check_insurance,@Check_past_injuries,@Check_allergies)";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Patient_name", Patient_name);
                        command.Parameters.AddWithValue("@Check_insurance", Check_insurance);
                        command.Parameters.AddWithValue("@Check_past_injuries", Check_past_injuries);
                        command.Parameters.AddWithValue("@Check_allergies", Check_allergies);



                        command.ExecuteNonQuery();

                        MessageBox.Show("Data saved");








                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

           

        }
        private string GetInsurance()
        {
            if (radioButton1.Checked) return "Yes";
            if (radioButton2.Checked) return "No";
            return "Unknown";
        }
        private string GetInjuries()
        {
            if (radioButton1.Checked) return "Yes";
            if (radioButton2.Checked) return "No";
            return "Unknown";
        }
        private string GetAllergies()
        {
            if (radioButton1.Checked) return "Yes";
            if (radioButton2.Checked) return "No";
            return "Unknown";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logout logout = new Logout();
            logout.Show();
            this.Hide();
        }
    }
    }

