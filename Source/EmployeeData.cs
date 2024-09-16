using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Crud_Project
{
    public partial class EmployeeData : Form
    {
        public EmployeeData()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Crud.mdf; integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            string g;
            g = " ";
            if (radioButton1.Checked)
            { g = "Male"; }
            else if (radioButton2.Checked)
            { g = "Female"; }
            else
            { g = "Transgender"; }
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Employee(Emp_id,Emp_name,Emp_gender,Emp_rating,Emp_contact) values('" + textBox1.Text + "','" + textBox2.Text + "','" + g + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("submitted");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee where Emp_id='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Done");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string g;
            g = " ";
            if (radioButton1.Checked)
            { g = "Male"; }
            else if (radioButton2.Checked)
            { g = "Female"; }
            else
            { g = "Transgender"; }
            con.Open();
            SqlCommand cmd = new SqlCommand("update Employee set Emp_name='" + textBox2.Text + "',Emp_gender='" + g + "',Emp_rating='" + textBox3.Text + "',Emp_contact='" + textBox4.Text + "'  where Emp_id='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Done");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from Employee where Emp_id='" + dataGridView1.CurrentCell.Value + "'", con);
            SqlDataReader srd = cmd.ExecuteReader();
            while (srd.Read())
            {
                textBox1.Text = srd.GetValue(0).ToString();
                textBox2.Text = srd.GetValue(1).ToString();
                textBox3.Text = srd.GetValue(3).ToString();
                textBox4.Text = srd.GetValue(4).ToString();
                string s = srd.GetValue(2).ToString();
                if (s == "Male")
                {
                    radioButton1.Checked = true;
                }
                else if (s == "Female")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton3.Checked = true;
                }
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from Employee", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            VehicleData f3 = new VehicleData();
            f3.Show();
            this.Hide();
        }

    }
}
