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
    public partial class NotepadHomePage : Form
    {
        public NotepadHomePage()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           PersonalNotePadHome login = new PersonalNotePadHome();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          Menu login = new Menu();
            login.Show();
            this.Hide();
        }
    }
}
