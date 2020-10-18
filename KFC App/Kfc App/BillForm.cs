using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kfc_App
{
    public partial class BillForm : Form
    {
        public BillForm()
        {
            InitializeComponent();
        }
        static int total = 0;
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3P3AGHU;Initial Catalog=prac;Integrated Security=True");
        private void BillForm_Load(object sender, EventArgs e)
        {
            cn.Open();
            string query = "select o.CustomerID, od.OrderID, od.Item, od.ItemPrice, od.Qty, od.TotalPrice from Orders as o Inner Join OrderDetails as od ON o.OrderID = od.OrderID where od.OrderID = (SELECT max(OrderID) from OrderDetails as MaxID) and od.Item!='NULL'";
            SqlDataAdapter sda = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            query = "select sum(TotalPrice) from OrderDetails where OrderID = (SELECT max(OrderID) from OrderDetails as MaxID)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            total=(int)cmd.ExecuteScalar();
            cn.Close();
            
            label3.Text ="Rs. " + total.ToString();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            BillForm bf = new BillForm();
            bf.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
