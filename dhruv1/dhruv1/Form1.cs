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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(global::dhruv1.Properties.Settings.Default.Database1ConnectionString);
            try
            {   
                string query = "INSERT INTO Item(Item_name,Price)  VALUES ('"+tb_itemname.Text+"',"+tbprice.Text+")";
                SqlCommand sql = new SqlCommand(query,conn);
                conn.Open();
                sql.ExecuteNonQuery();
                MessageBox.Show("add new item is done","messeg",MessageBoxButtons.OK,MessageBoxIcon.Information);
                 this.itemTableAdapter.Fill(this.database1DataSet.Item);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            tb_itemname.Text = "";
            tbprice.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Item' table. You can move, or remove it, as needed.
            this.itemTableAdapter.Fill(this.database1DataSet.Item);

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(global::dhruv1.Properties.Settings.Default.Database1ConnectionString);
            try
            {
                string query = "UPDATE  Item SET Item_name='" + tb_itemname.Text + "',Price=" + tbprice.Text + " WHERE Id="+tbupdate.Text;
                SqlCommand sql = new SqlCommand(query, conn);
                conn.Open();
                sql.ExecuteNonQuery();
                MessageBox.Show("item updating is done", "messeg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.itemTableAdapter.Fill(this.database1DataSet.Item);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            tb_itemname.Text = "";
            tbprice.Text = "";
            tbupdate.Text = "";
        }

        private void tbprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SqlConnection conn = new SqlConnection(global::dhruv1.Properties.Settings.Default.Database1ConnectionString);
                try
                {
                    string query = "INSERT INTO Item(Item_name,Price)  VALUES ('" + tb_itemname.Text + "'," + tbprice.Text + ")";
                    SqlCommand sql = new SqlCommand(query, conn);
                    conn.Open();
                    sql.ExecuteNonQuery();
                    MessageBox.Show("add new item is done", "messeg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.itemTableAdapter.Fill(this.database1DataSet.Item);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
                tb_itemname.Text = "";
                tbprice.Text = "";
            }

        }

        
    }
}
