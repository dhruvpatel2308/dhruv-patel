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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[0].Value == true)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item.Cells[1].Value.ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item.Cells[2].Value.ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item.Cells[3].Value.ToString();
                   // dataGridView2.Rows[n].Cells[3].Value = item.Cells[1].value.ToString();
                }
            }

        }

        private void btnfetch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(global::dhruv1.Properties.Settings.Default.Database1ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Item", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = false;
                dataGridView1.Rows[n].Cells[1].Value = item["id"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["item_name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Price"].ToString();

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((bool)dataGridView1.SelectedRows[0].Cells[0].Value == false)
                dataGridView1.SelectedRows[0].Cells[0].Value = true;
            else
                dataGridView1.SelectedRows[0].Cells[0].Value = false;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }
       // double total=0;
        private void button1_Click(object sender, EventArgs e)
        {
            double total = 0;
            int n = dataGridView2.Rows.Add();
            for (int i = 0; i < n; i++)
            {
                 total = total + Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
            }
            lbltotal.Text = Convert.ToString(total);
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f = new Form4();
            f.Show();
        }

        
    }
}
