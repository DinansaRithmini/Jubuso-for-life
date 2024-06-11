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
    public partial class Report1 : Form
    {
        public Report1()
        {
            InitializeComponent();
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ReportSource = "C:\\Users\\dinar\\source\\repos\\WindowsFormsApp8\\WindowsFormsApp8\\CrystalReport1.rpt";
        }
    }
}
