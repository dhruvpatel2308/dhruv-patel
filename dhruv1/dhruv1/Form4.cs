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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Uname_TextChanged(object sender, EventArgs e)
        {

        }
        //string constr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Punit Bhatt\Docume
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(global::dhruv1.Properties.Settings.Default.Database1ConnectionString);
            con.Open();
            string uname = Uname.Text;
            string pwd = Pwd.Text;
            if (uname == "" && pwd == "")
            {
                MessageBox.Show("Enter valid Username/Password");
            }
            else
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter("Select count(*) From Userdata where UserName='" + uname + "' and Password='" + pwd + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        Form1 n = new Form1();
                        n.Show();

                    }
                    else
                    {
                        MessageBox.Show("UserName/Password Incorrect");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form3 signUp = new form3();
            signUp.Show();
        }

        
        

    }
}
