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

    public partial class AddEmployee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3P3AGHU;Initial Catalog=prac;Integrated Security=True"); 
        public AddEmployee()
        {
            InitializeComponent();
            defaultFields();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //@name,@age,@gender,@jobTitle,@salary,@phNo,@address
            SqlCommand cmd = new SqlCommand("EmployeeInsertion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = nameTextBox.Text.ToString();
            cmd.Parameters.Add("@age", SqlDbType.Int).Value = Convert.ToInt32(ageTextBox.Text);
            cmd.Parameters.Add("@gender", SqlDbType.VarChar, 50).Value = genderComboBox.SelectedItem.ToString();
            cmd.Parameters.Add("@jobTitle", SqlDbType.VarChar, 50).Value = jobTitleComboBox.SelectedItem.ToString();
            cmd.Parameters.Add("@salary", SqlDbType.Int).Value = Convert.ToInt32(salaryTextBox.Text);
            cmd.Parameters.Add("@phNo", SqlDbType.VarChar,20).Value = phTextBox.Text.ToString();
            cmd.Parameters.Add("@address", SqlDbType.VarChar,255).Value = addressTextBox.Text.ToString();
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Saved to Database", "Employee Info.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            defaultFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            defaultFields();
        }
        void defaultFields()
        {
            nameTextBox.Text = string.Empty;
            ageTextBox.Text = string.Empty;
            genderComboBox.SelectedIndex = 0;
            jobTitleComboBox.SelectedIndex = 0;
            salaryTextBox.Text = string.Empty;
            phTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
        }
    }
}
