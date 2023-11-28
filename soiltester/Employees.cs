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

namespace soiltester
{
    public partial class Employees : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");
        public Employees()
        {
            InitializeComponent();

            tbType.Items.Add("stuff");
            tbType.Items.Add("admin");

            tbPass.PasswordChar = '*';

            tbRepass.PasswordChar = '*';
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() != "" && tbSname.Text.Trim() != "" && tbUserame.Text.Trim() != "" && tbType.Text.Trim() != "" && tbAddress.Text.Trim() != "")
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                DataTable user = new DataTable();

                try
                {

                    SqlDataAdapter dataA = new SqlDataAdapter("EmployeeValid", conn);

                    dataA.SelectCommand.CommandType = CommandType.StoredProcedure;

                    dataA.SelectCommand.Parameters.AddWithValue("@Emp_username", tbUserame.Text.Trim());

                    dataA.Fill(user);

                    dataBox.DataSource = user;

                    if (dataBox.Rows[0].Cells[0].Value != null)
                    {
                        MessageBox.Show("Data is " + dataBox.Rows[0].Cells[0].Value.ToString());
                    }
                    

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error searching for user try again \n\n" + ex);
                    return;
                }
                finally
                {

                }

                if (dataBox.Rows[0].Cells[0].Value == null)
                {
                    if (tbPass.Text.ToLower().Trim() == tbRepass.Text.ToLower().Trim())
                    {

                        try
                        {
                            SqlCommand comm = new SqlCommand("EmployeePro", conn);

                            comm.CommandType = CommandType.StoredProcedure;

                            comm.Parameters.AddWithValue("@mode", "add");
                            comm.Parameters.AddWithValue("@Emp_name", tbName.Text.ToLower().Trim());
                            comm.Parameters.AddWithValue("@Emp_sname", tbSname.Text.ToLower().Trim());
                            comm.Parameters.AddWithValue("@Emp_username", tbUserame.Text.ToLower().Trim());
                            comm.Parameters.AddWithValue("@Emp_address", tbAddress.Text.ToLower().Trim());
                            comm.Parameters.AddWithValue("@Emp_password", tbPass.Text.ToLower().Trim());
                            comm.Parameters.AddWithValue("@Emp_type", empType(tbType.Text.ToLower().Trim()));
                            comm.Parameters.AddWithValue("@Emp_Id", 0);

                            comm.ExecuteNonQuery();

                            MessageBox.Show("Employee Successfully Registered :) ");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting Employee, Please try again\n\n" + ex);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Password do not match... ");
                    }

                }
                else
                {
                    MessageBox.Show("Username already exist, please use a different username...");
                }

                conn.Close();
            }
            else
            {
                MessageBox.Show("Error: Some field were not field, please try again....");
            }
        }

        public int empType(string name)
        {
            if (name == "stuff") return 1;
            else return 2;
        }
    }
}
