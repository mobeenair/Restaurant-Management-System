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
    public partial class ItemRemove : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3P3AGHU;Initial Catalog=prac;Integrated Security=True");
        public ItemRemove()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("ItemDeletion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@itemId", SqlDbType.Int).Value = Convert.ToInt32(searchTextBox.Text);

            if (MessageBox.Show("Are You Sure?",
                "Delete Item", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Item Deleted from Database", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ItemRemove_Load(object sender, EventArgs e)
        {

        }
    }
}
