using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dhruv1
{
    public partial class form3 : Form
    {
        public form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(global::dhruv1.Properties.Settings.Default.Database1ConnectionString);
            string name = Name.Text;
            string uname = UserName.Text;
            string pwd = Password.Text;
            string cpwd = Cpwd.Text;
            if (name == "")
            {
                MessageBox.Show("Enter Name.");
            }
            else if (uname == "")
            {
                MessageBox.Show("Enter Proper Username.");
            }
            else if (pwd == "")
            {
                MessageBox.Show("Enter Proper Username.");
            }
            else if (cpwd == "")
            {
                MessageBox.Show("Confirm your password.");
            }
            else if (cpwd != pwd)
            {
                MessageBox.Show("Enter same password as above");
            }
            else
            {
                try
                {
                    string query = "INSERT INTO Userdata(name,UserName,Password) VALUES('" + name + "','" + uname + "','" + pwd + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Form1 n = new Form1();
                    n.Show();
                    this.Hide();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

       
    }
}
