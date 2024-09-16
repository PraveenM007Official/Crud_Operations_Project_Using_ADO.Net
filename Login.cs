using System;
using System.Windows.Forms;

namespace Crud_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id, pass;

            id = textBox1.Text;
            pass = textBox2.Text;
            if (id == "admin" && pass == "1234")
            {

                EmployeeData f2 = new EmployeeData();
                f2.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Wrong Id and Password.");

        }
    }
}
