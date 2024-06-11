using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp8
{
    public partial class Contact_doctor : Form
    {
        public Contact_doctor()
        {   // Set the form properties
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {try
            { if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please enter patient name.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(comboBox1.Text))
                {
                 MessageBox.Show("Please select a doctor type.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!dateTimePicker1.Checked)
                {
                    MessageBox.Show("Please select a valid date and time.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    MessageBox.Show("Please select either 'Yes' or 'No' for hospital visit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please enter your age.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a gender.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string connectionString = "Server=localhost;Database=Project;Uid=root;Pwd=Dinansa@2005;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string doctorType = comboBox1.SelectedItem as string;
                DateTime visitDateTime = dateTimePicker1.Value;
                int age = int.Parse(textBox2.Text);
                string VisitHospitalBefore = GetData();
                bool isFemale = comboBox4.Text == "Female"; // Assuming ComboBox values are "Female" and "Male"
                string patient_name =textBox1.Text;

                   

                    
                string genderValue = isFemale ? "Female" : "Male" ;

                string query = "INSERT INTO doctorappointments (patient_name,DoctorType, VisitDateTime, VisitHospitalBefore, Age, Gender) VALUES (@patient_name,@DoctorType, @VisitDateTime, @VisitHospitalBefore, @Age, @Gender)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@DoctorType", doctorType);
                command.Parameters.AddWithValue("@VisitDateTime", visitDateTime);
                command.Parameters.AddWithValue("@VisitHospitalBefore", VisitHospitalBefore);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Gender", genderValue);
                    command.Parameters.AddWithValue("@patient_name", patient_name);

                command.ExecuteNonQuery();
                    

                    {
                    }

           MessageBox.Show("Data saved successfully!");
                    Anxiety_Release_Classes login = new Anxiety_Release_Classes();
                    login.Show();
                    this.Hide();

                }
        }
            
        catch (Exception ex)
        {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private string GetData()
        { if (radioButton1.Checked) return "Yes";
            if (radioButton2.Checked) return "No";
            return "Unknown";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value=DateTime.Now; ;
            textBox2.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
       //Anxiety_Release_Classes login = new Anxiety_Release_Classes();
            //login.Show();
           // this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Contact_doctor_Load(object sender, EventArgs e)
        {

        }
    }
}
        
    

