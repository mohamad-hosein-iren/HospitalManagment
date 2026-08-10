using HospitalManagementSystem.Models;
using HospitalManagementSystem.Models.People;

namespace WinFormsApp1
{
    public partial class DoctorsForm : Form
    {
        List<Doctor> doctors = new List<Doctor>();
        public DoctorsForm()
        {
            InitializeComponent();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string family = textBox2.Text;
            DateTime birthdate = dateTimePicker1.MinDate;
            string medicalconsilnumber = textBox4.Text;
            string nationalcode = textBox5.Text;
            string homeaddress = textBox6.Text;
            string phonenumber = textBox7.Text;
            Gender gender = radioButton1.Text == "Male" ? Gender.Male : Gender.Female;
            string experienceyears = textBox8.Text;
            object department = comboBox1.SelectedItem;
            object specialization = comboBox3.SelectedItem;

            doctors.Add(new Doctor(nationalcode, name, family, medicalconsilnumber, (MedicalSpecialty)specialization));
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
