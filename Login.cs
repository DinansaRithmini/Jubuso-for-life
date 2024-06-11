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
    public partial class Login : Form
    {
        public Login()
        {   // Set the form properties
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void btn_createaccount_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=Project;Uid=root;Pwd=Dinansa@2005;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string Email_Address = textBox1.Text; // Get the email from the TextBox
                    string Signin_Password = textBox2.Text; // Get the password from the TextBox

                    string query = "SELECT COUNT(*) FROM Signin WHERE Email_Address = @Email_Address AND Signin_Password = @Signin_Password";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email_Address", Email_Address);
                    command.Parameters.AddWithValue("@Signin_Password", Signin_Password);

                    int result = Convert.ToInt32(command.ExecuteScalar());

                    if (result > 0)
                    {
                        if (string.IsNullOrWhiteSpace(Email_Address))
                        {
                            this.BackColor = Color.LightSalmon;
                            MessageBox.Show("Email cannot be blank", "Account not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }
                        if (string.IsNullOrWhiteSpace(Signin_Password))
                        {
                            this.BackColor = Color.LightSalmon;
                            MessageBox.Show("Password cannot be blank", "Account not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }
                        // Login is successful, navigate to the next form or show a success message
                        MessageBox.Show("Login successful!");

                        Menu menu = new Menu();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Login failed, show an error message or update a label
                        MessageBox.Show("Invalid email or password. Please try again.");
                    }
                }
                catch (MySqlException ex)
                {
                    // Handle exceptions
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signin menu = new Signin();
            menu.Show();
            this.Hide();
        }
    }
}
