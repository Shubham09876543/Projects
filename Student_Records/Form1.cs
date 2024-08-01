using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;

namespace Student_Records
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gender,choice;
            string query = "insert into StudentRecord(NAME,Id,BRANCH,SEM,CITY,GENDER,CHOICE) values(@NAME,@Id,@BRANCH,@SEM,@CITY,@GENDER,@CHOICE)";
            string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentRecord;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@NAME",textBox1.Text);
            cmd.Parameters.AddWithValue("@Id", textBox2.Text);
            cmd.Parameters.AddWithValue("@BRANCH", textBox3.Text);
            cmd.Parameters.AddWithValue("@SEM", textBox4.Text);
            cmd.Parameters.AddWithValue("@CITY", comboBox1.SelectedItem.ToString());
            if (checkBox1.Checked == true) {
                choice = "ASP.NET";
            }
            else
            {
                choice = "C#";
            }
            cmd.Parameters.AddWithValue("@CHOICE",choice);
            if (radioButton1.Checked == true) {
                gender = "MALE";
            }
            else{
                gender = "FEMALE";
            }
            cmd.Parameters.AddWithValue("@GENDER", gender);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Register Suseccfull...");
       }
    }
}
