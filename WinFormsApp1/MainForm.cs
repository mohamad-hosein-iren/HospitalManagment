using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DoctorsForm form1 = new();
            form1.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NursesForm form2 = new();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PatientsForm form3 = new();
            form3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmployeeForm form4 = new();
            form4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AppointmentsForm form5 = new();
            form5.ShowDialog();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            //button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //button3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //button4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //button5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            //label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ////.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            //// اگر می‌خواهید فاصله‌ها هم حفظ شود
            //SetupAnchorForAllControls();
        }

        
        //private void SetupAnchorForAllControls()
        //{
        //    foreach (Control control in this.Controls)
        //    {
        //        // برای کنترل‌های عمودی (مانند لیست‌ها)
        //        if (control is ListBox || control is DataGridView)
        //        {
        //            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
        //                            AnchorStyles.Left | AnchorStyles.Right;
        //        }
        //        // برای دکمه‌ها
        //        else if (control is Button)
        //        {
        //            control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        //        }
        //    }
        //}
    }
}

