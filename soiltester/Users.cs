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
    public partial class Users : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");

        Form1 fm = new Form1();
        bool isCell2On = false;
        bool isCell3On = false;
        Button darkimg = new Button();
        Button lightimg = new Button();

        int user = 0;
        int cli = 0;
        public Users(Form1 form, int user1)
        {
            InitializeComponent();

            //int middleX = (SystemInformation.WorkingArea.Width - this.Width) / 2;

            //int middleY = (SystemInformation.WorkingArea.Height - this.Height) / 2;

            user = user1;

            fm = form;

        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name1 = "";

            if (name.Text == "" || surname.Text == "" || cell1.Text == "" || address.Text == "")
            {

                MessageBox.Show("Some fields are not filled");
                return;
            }
            else
            {
                if (isCell2On)
                {
                    if (cell2.Text == "")
                    {
                        MessageBox.Show("Some fields are not filled");
                        return;
                    }
                    else
                    {
                        Saveto();
                    }
                }
                else
                {
                    if (isCell3On)
                    {
                        if (cell2.Text == "")
                        {
                            MessageBox.Show("Some fields are not filled");
                            return;
                        }
                        else
                        {
                            Saveto();
                        }
                    }
                    else
                    {
                        Saveto();
                    }

                }
            }

            name1 = name.Text;
            
            newProject newP = new newProject(fm,name1,user,cli,0);
            newP.Show();
            fm.Hide();
            this.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isCell2On)
            {
                cell2butt.Image = new Bitmap("fbutt.png");
                isCell2On = false;
                cell2.Enabled = false;
            }
            else
            {
                Bitmap pic = new Bitmap("fbutt2.png");
                cell2butt.Image = pic;
                isCell2On = true;
                cell2.Enabled = true;
            }
            
        }

        private void cell3butt_Click(object sender, EventArgs e)
        {
            if (isCell3On)
            {
                cell3butt.Image = new Bitmap("fbutt.png");
                isCell3On = false;
                cell3.Enabled = false;
            }
            else
            {
                Bitmap pic = new Bitmap("fbutt2.png");
                cell3butt.Image = pic;
                isCell3On = true;
                cell3.Enabled = true;
            }
        }

        public void Saveto()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlCommand comm = new SqlCommand("clientPro",conn);

            DataTable dt = new DataTable();

            try
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@mode", "add");
                comm.Parameters.AddWithValue("@Cli_name", name.Text.ToLower().Trim());
                comm.Parameters.AddWithValue("@Cli_sname", surname.Text.ToLower().Trim());
                comm.Parameters.AddWithValue("@RegBy", user);
                comm.Parameters.AddWithValue("@Cli_address", address.Text.ToLower().Trim());

                comm.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter("getClientId", conn);

                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                sda.Fill(dt);

                DataT.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error saving client, please try again\n\n" + ex);
            }

            if (DataT.Rows[0].Cells[0].Value != null)
            {
                SqlCommand comm1 = new SqlCommand();

                cli = Convert.ToInt32(DataT.Rows[0].Cells[0].Value);
                try
                {
                    contactsNos(DataT.Rows[0].Cells[0].Value.ToString(), cell1.Text.ToLower().Trim(), comm1);

                    if (isCell2On)
                        contactsNos(DataT.Rows[0].Cells[0].Value.ToString(), cell2.Text.ToLower().Trim(), comm1);

                    if (isCell3On)
                        contactsNos(DataT.Rows[0].Cells[0].Value.ToString(), cell3.Text.ToLower().Trim(), comm1);
                }
                catch
                {
                    MessageBox.Show("User phone numbers not saved use edit to input them");
                }
            }
            else
            {
                MessageBox.Show("Some critical error occured while saving");
            }

        }

        public void contactsNos(string id, string no, SqlCommand comm)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            comm = new SqlCommand("CContacts",conn);
            
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@Con_Id", id);
            comm.Parameters.AddWithValue("@CCon_number",no);

            comm.ExecuteNonQuery();

            conn.Close();
        }
    }
}
