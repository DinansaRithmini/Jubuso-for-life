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
    public partial class Track_Mood : Form
    {
        public Track_Mood()
        {// Set the form properties
            Text = "Centered Form Example";
            Width = 400; // Set your desired width
            Height = 300; // Set your desired height;

            // Center the form on the screen
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Mistakenly clicked
        }

        private void button3_Click(object sender, EventArgs e)
        { try
            {
                string connectionString = "Server=localhost;Database=Project;Uid=root;Pwd=Dinansa@2005;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string Feel = GetSelectedFeel();
                    string Hapiness = GetSelectedHapiness();
                    string Sadness = GetSelectedSadness();
                    string Rage = GetSelectedRage();
                    string Boredom = GetSelectedBoredom();
                    string query = "INSERT INTO Mood_Tracker (Feel,Hapiness,Sadness,Rage,Boredom) VALUES (@Feel,@Hapiness,@Sadness,@Rage,@Boredom)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Feel", Feel);
                        command.Parameters.AddWithValue("@Hapiness", Hapiness);
                        command.Parameters.AddWithValue("@Sadness", Sadness);
                        command.Parameters.AddWithValue("@Rage", Rage);
                        command.Parameters.AddWithValue("@Boredom", Boredom);
                        command.ExecuteNonQuery();

                        if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked ||radioButton4.Checked ||radioButton5.Checked)
                        {
                        }

                        else
                        {
                            this.BackColor = Color.LightSalmon;
                            MessageBox.Show("Provide answer for Question 01", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;

                        }
                    }
                    if (radioButton6.Checked || radioButton7.Checked || radioButton8.Checked || radioButton9.Checked || radioButton10.Checked)
                    {
                    }

                    else
                    {
                        this.BackColor = Color.LightSalmon;
                        MessageBox.Show("Provide answer for Question 02", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;

                    }
                    if (radioButton11.Checked || radioButton12.Checked || radioButton13.Checked || radioButton14.Checked || radioButton15.Checked)
                    {
                    }

                    else
                    {
                        this.BackColor = Color.LightSalmon;
                        MessageBox.Show("Provide answer for Question 03", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;

                    }
                }
                if (radioButton16.Checked || radioButton17.Checked || radioButton18.Checked || radioButton19.Checked || radioButton20.Checked)
                {
                }

                else
                {
                    this.BackColor = Color.LightSalmon;
                    MessageBox.Show("Provide answer for Question 04", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }
                if (radioButton21.Checked || radioButton22.Checked || radioButton23.Checked || radioButton24.Checked || radioButton25.Checked)
                {
                }

                else
                {
                    this.BackColor = Color.LightSalmon;
                    MessageBox.Show("Provide answer for Question 05", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }
                MessageBox.Show("Data save sucessfully!");



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
            
            private string GetSelectedFeel()
            {
                if (radioButton1.Checked) return "Happy";
                if (radioButton2.Checked) return "Sad";
                if (radioButton3.Checked) return "Angry";
                if (radioButton4.Checked) return "Calm";
                if (radioButton5.Checked) return "Excited";
                return "Unknown"; // Return a default value if none are selected
            }
        private string GetSelectedHapiness()
        {
            if (radioButton1.Checked) return "Never";
            if (radioButton2.Checked) return "Rarely";
            if (radioButton3.Checked) return "Sometimes";
            if (radioButton4.Checked) return "Often";
            if (radioButton5.Checked) return "Always";
            return "Unknown"; // Return a default value if none are selected
        }
        private string GetSelectedSadness()
        {
            if (radioButton1.Checked) return "Never";
            if (radioButton2.Checked) return "Rarely";
            if (radioButton3.Checked) return "Sometimes";
            if (radioButton4.Checked) return "Often";
            if (radioButton5.Checked) return "Always";
            return "Unknown"; // Return a default value if none are selected
        }
        private string GetSelectedRage()
        {
            if (radioButton1.Checked) return "Never";
            if (radioButton2.Checked) return "Rarely";
            if (radioButton3.Checked) return "Sometimes";
            if (radioButton4.Checked) return "Often";
            if (radioButton5.Checked) return "Always";
            return "Unknown"; // Return a default value if none are selected
        }
        private string GetSelectedBoredom()
        {
            if (radioButton1.Checked) return "Never";
            if (radioButton2.Checked) return "Rarely";
            if (radioButton3.Checked) return "Sometimes";
            if (radioButton4.Checked) return "Often";
            if (radioButton5.Checked) return "Always";
            return "Unknown"; // Return a default value if none are selected
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Menu login = new Menu();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton16.Checked = false;
            radioButton17.Checked = false;
            radioButton18.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
            radioButton21.Checked = false;
            radioButton22.Checked = false;
            radioButton23.Checked = false;
            radioButton24.Checked = false;
            radioButton25.Checked = false;
           
        }

        private void Track_Mood_Load(object sender, EventArgs e)
        {

        }
    }
    }

