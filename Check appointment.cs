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





namespace WindowsFormsApp8
{
    public partial class Check_appointment : Form
    {
        public Check_appointment()
        {
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Check_appointment_Load(object sender, EventArgs e)
        {

            // Establish a connection to MySQL
            string connectionString = "Server=localhost;Database=Project;Uid=root;Pwd=Dinansa@2005;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Create a SQL command to retrieve appointment data
                string query = "SELECT * FROM doctorappointments";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Create a DataTable to store the result
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable appointmentsDataTable = new DataTable();
                        adapter.Fill(appointmentsDataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = appointmentsDataTable;
                    }
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string patientName = textBox1.Text;

            

            string connectionString = "Server=localhost;Database=Project;Uid=root;Pwd=Dinansa@2005;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT VisitDateTime, DoctorType FROM  doctorappointments WHERE patient_name = @patientName";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@patientName", patientName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Display the details in the TextBox controls
                            textBox2.Text = reader["VisitDateTime"].ToString();
                            textBox3.Text = reader["DoctorType"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Patient name cannot be found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
      
            {
                string patientName = textBox1.Text;


            string connectionString = "Server=localhost;Database=Project;Uid=root;Pwd=Dinansa@2005;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM doctorappointments WHERE patient_name = @patientName";
                    using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@patientName", patientName);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Data was deleted successfully
                            // You can provide feedback to the user, clear TextBoxes, etc.
                            MessageBox.Show("Patient data deleted successfully.");
                          textBox2.Text = string.Empty;
                           textBox3.Text = string.Empty;
                        }
                        else
                        {
                            // Data was not deleted (patient not found)
                            MessageBox.Show("Patient not found or data was not deleted.");
                        }
                    }
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logout menu = new Logout();
            menu.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }


