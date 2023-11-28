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
    public partial class Password : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");
        bool valid = false;

        int user = 0;

        Form1 fm;

        public Password(Form1 fm1)
        {
            InitializeComponent();

            tbPass.PasswordChar = '*';

            fm = fm1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                SqlDataAdapter comm = new SqlDataAdapter("loginPro",conn);

                comm.SelectCommand.CommandType = CommandType.StoredProcedure;
                comm.SelectCommand.Parameters.AddWithValue("@Emp_username",tbUser.Text.ToLower().Trim());
                comm.SelectCommand.Parameters.AddWithValue("@Emp_password", tbPass.Text.ToLower().Trim());

                comm.Fill(dt);

                dataP.DataSource = dt;
            }
            catch
            {

            }

            if (dataP.Rows[0].Cells[0].Value == null) 
            {
                MessageBox.Show("Username or Password incorrect");
            }
            else
            {

                user = Convert.ToInt32(dataP.Rows[0].Cells[0].Value);

                fm.getUser(user);

                valid = true;

                this.Close();
            }

            conn.Close();
        }

        private void Password_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!valid)
            {
                Application.Exit();
            }

            fm.Show();
        }
    }
}
