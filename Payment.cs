using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp8
{
    public partial class Payment : Form
    {
        public double TotalFromAnxietyRelease { get; set; }
        public Payment()
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
            if (TotalFromAnxietyRelease != 0)
            {
                double updatedTotal = TotalFromAnxietyRelease + 1500;
                textBox1.Text = updatedTotal.ToString();
            }
            {
                try
                {
                    if (!radioButton1.Checked && !radioButton2.Checked)
                    {
                        MessageBox.Show("Please select a payment method.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (radioButton1.Checked && radioButton2.Checked)
                    {
                        MessageBox.Show("Please select only one payment method.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string cardNumber = textBox2.Text;
                    if (!ValidateCardNumber(cardNumber))
                    {
                        MessageBox.Show("Invalid card number. It should have exactly 12 digits.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string PinNumber = textBox3.Text;
                    if (!ValidatePinNumber(PinNumber))
                    {
                        MessageBox.Show("Invalid PIN. It should have exactly 4 digits.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        MessageBox.Show("Card holder name cannot be blank.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                    // Continue with your database insertion code
                    string connectionString = "Server=localhost;Database=Project;Uid=root;Pwd=Dinansa@2005;";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();



                    string query = "INSERT INTO payment (Card_holder,pin_number,Card_number,Total_amount,payment_method) VALUES (@Card_holder, @pin_number, @Card_number, @Total_amount,@payment_method)";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                               string Card_holder = textBox4.Text.ToString();
                               string pin_number = textBox3.Text.ToString();
                               string Card_number = textBox2.Text.ToString();
                               string Total_amount=textBox1.Text.ToString();
                               string payment_holder = CardType();

                            command.Parameters.AddWithValue("@Card_holder", Card_holder);
                            command.Parameters.AddWithValue("@pin_number", pin_number);
                            command.Parameters.AddWithValue("@Card_number", Card_number);
                            command.Parameters.AddWithValue("@Total_amount", Total_amount);
                            command.Parameters.AddWithValue("payment_method", payment_holder);

                            int rowsAffected = command.ExecuteNonQuery();
                        }
                    }

                     MessageBox.Show("Data saved successfully!");
                     Logout logout = new Logout();
                     logout.Show();
                     this.Hide();
                
               
            }
        }



        private string CardType()
        {
            if (radioButton1.Checked) return "Credit card";
            if (radioButton2.Checked) return "Debit card";
            return "Unknown";
        }

        private bool ValidateCardNumber(string cardNumber)
        {
            if (!string.IsNullOrEmpty(cardNumber) && cardNumber.Length == 12 && long.TryParse(cardNumber, out _))
            {
                return true;
            }
            return false;
        }
        private bool ValidatePinNumber(string PinNumber)
        {
            if (!string.IsNullOrEmpty(PinNumber) && PinNumber.Length == 4 && long.TryParse(PinNumber, out _))
            {
                return true;
            }
            return false;
        }
      

    }
}
        
    
  


