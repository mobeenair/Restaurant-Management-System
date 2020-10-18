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
    public partial class ItemUpdate : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-3P3AGHU;Initial Catalog=prac;Integrated Security=True");
        public ItemUpdate()
        {
            InitializeComponent();
        }

        static int id;
        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("MenuItemSelection", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@itemId", SqlDbType.Int).Value = Convert.ToInt32(searchTextBox.Text);

            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                id = Convert.ToInt32(dataReader["ItemId"]);

                nameTextBox.Text = dataReader["ItemName"].ToString();
                itemTypeComboBox.SelectedItem = dataReader["ItemType"].ToString();
                priceTextBox.Text = dataReader["Price"].ToString();
            }
            cn.Close();
            searchTextBox.Text = string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("MenuItemUpdate", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //providing all parameters to the stored procedure
            cmd.Parameters.Add("@itemId", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@itemName", SqlDbType.VarChar, 50).Value = nameTextBox.Text.ToString();
            cmd.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(priceTextBox.Text);
            cmd.Parameters.Add("@itemType", SqlDbType.VarChar, 50).Value = itemTypeComboBox.SelectedItem.ToString();
            
            cn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Item is Updated", "Database Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cn.Close();

            afterUpdateBtnClick();
        }

        void afterUpdateBtnClick()
        {
            nameTextBox.Text = string.Empty;
            priceTextBox.Text = string.Empty;
            itemTypeComboBox.SelectedIndex = 0;
        }
        
    }
}
