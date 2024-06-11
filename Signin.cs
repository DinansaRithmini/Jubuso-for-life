using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
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
    public partial class Signin : Form
    {
        public Signin()
        {
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
                    string Full_Name = textBox1.Text;
                    string Email_Address = textBox2.Text;
                    string Telephone = textBox3.Text;
                    string Signin_Password = textBox4.Text;

                    if (string.IsNullOrWhiteSpace(Full_Name))
                    {
                        // Full Name is null or empty
                        this.BackColor = Color.LightSalmon;
                        MessageBox.Show("Full Name cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(Email_Address))
                    {
                        // Email Address is null or empty
                        this.BackColor = Color.LightSalmon;
                        MessageBox.Show("Email Address cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!ValidateTelephone(Telephone))
                    {
                        // Telephone is not a valid format
                        MessageBox.Show("Invalid telephone number. It should have exactly 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(Signin_Password))
                    {
                        // Password is null or empty
                        this.BackColor = Color.LightSalmon;
                        MessageBox.Show("Password cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                    string query = "INSERT INTO signin (Full_Name,Email_Address,Telephone,Signin_Password) VALUES (@Full_Name,@Email_Address,@Telephone,@Signin_Password)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    {
                        command.Parameters.AddWithValue("@Full_name", Full_Name);
                        command.Parameters.AddWithValue("@Email_Address", Email_Address);
                        command.Parameters.AddWithValue("@Telephone", Telephone);
                        command.Parameters.AddWithValue("@Signin_Password", Signin_Password);


                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            // Registration successful
                            MessageBox.Show("Registration successful!");

                            // Close the current form and open the Menu form
                            this.Hide();
                            Menu menu = new Menu();
                            menu.Show();
                        }
                        else
                        {
                            // Registration failed
                            MessageBox.Show("Registration failed. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                  
                    
                  
                
               
            
           

        }
       
        }
        private bool ValidateTelephone(string Telephone)
        {
            // Remove non-numeric characters
            string numericTelephone = new string(Telephone.Where(char.IsDigit).ToArray());

            return numericTelephone.Length == 10;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login menu = new Login();
            menu.Show();
        }

        private void Signin_Load(object sender, EventArgs e)
        {

        }
    }
}
