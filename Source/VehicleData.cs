using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Crud_Project
{
    public partial class VehicleData : Form
    {
        public VehicleData()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Crud.mdf; integrated security=true");

        private void button1_Click(object sender, EventArgs e)
        {
            string a, t, s;
            a = "";
            t = "";
            s = "";
            if (comboBox1.SelectedItem.ToString() == "2-seater")
            {
                s = "2-seater";
            }
            else if (comboBox1.SelectedItem.ToString() == "4-seater")
            {
                s = "4-seater";
            }
            else if (comboBox1.SelectedItem.ToString() == "6-seater")
            {
                s = "6-seater";
            }
            else
            {
                s = "other";
            }
            if (comboBox3.SelectedItem.ToString() == "ac")
            {
                a = "ac";
            }
            else if (comboBox3.SelectedItem.ToString() == "non-ac")
            {
                a = "non-ac";
            }
            if (radioButton1.Checked)
            {
                t = "Yes";
            }
            else if (radioButton2.Checked)
            {
                t = "No";
            }

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into vehicle(vehicle_id,vehicle_name,vehicle_Model_Year,vehicle_Facil,vehicle_type,EV_,Vehicle_space,vehicle_price_per_Hr) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + a + "','" + textBox4.Text + "','" + t + "','" + s + "','" + textBox5.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("submitted");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from vehicle where vehicle_id='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Done");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a, t, s;
            a = "";
            t = "";
            s = "";
            if (comboBox1.SelectedItem.ToString() == "2-seater")
            {
                s = "2-seater";
            }
            else if (comboBox1.SelectedItem.ToString() == "4-seater")
            {
                s = "4-seater";
            }
            else if (comboBox1.SelectedItem.ToString() == "6-seater")
            {
                s = "6-seater";
            }
            else
            {
                s = "other";
            }
            if (comboBox3.SelectedItem.ToString() == "ac")
            {
                a = "ac";
            }
            else if (comboBox3.SelectedItem.ToString() == "non-ac")
            {
                a = "non-ac";
            }
            if (radioButton1.Checked)
            {
                t = "Yes";
            }
            else if (radioButton2.Checked)
            {
                t = "No";
            }

            con.Open();
            SqlCommand cmd = new SqlCommand("update vehicle set vehicle_name='" + textBox2.Text + "',vehicle_Model_Year='" + textBox3.Text + "',vehicle_Facil='" + a + "',vehicle_type='" + textBox4.Text + "',EV_='" + t + "',Vehicle_space='" + s + "',vehicle_price_per_Hr='" + textBox5.Text + "' where vehicle_id='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Done");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from vehicle where vehicle_id='" + dataGridView1.CurrentCell.Value + "'", con);
            SqlDataReader srd = cmd.ExecuteReader();
            while (srd.Read())
            {
                comboBox3.SelectedItem = srd.GetValue(3).ToString();
                textBox1.Text = srd.GetValue(0).ToString();
                textBox2.Text = srd.GetValue(1).ToString();
                textBox3.Text = srd.GetValue(2).ToString();
                textBox4.Text = srd.GetValue(4).ToString();
                textBox5.Text = srd.GetValue(7).ToString();
                string s = srd.GetValue(5).ToString();
                if (s == "Yes")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                comboBox1.SelectedItem = srd.GetValue(6).ToString();

            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select*from vehicle", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            EmployeeData f2 = new EmployeeData();
            f2.Show();
            this.Hide();
        }
    }
}
