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

    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");

        int Dpanelsize = 116;
        bool c_clicked = false;
        int user = 0;
        int pDisplay = 0;
        int cli = 0;
        string cliname = "";
        string cliFnames = "";

        clientDisplay[] cDisplay = new clientDisplay[4];

        public Form1()
        {
            InitializeComponent();

            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;

            this.Size = new Size(x,y);

            for (int i = 0; i < 4; i++) cDisplay[i] = new clientDisplay();

            //fullscreen
            this.WindowState = FormWindowState.Maximized;

            proPanel.Hide();
            ClientPanel.Dock = DockStyle.Fill;

            int wid = this.Size.Width;

            int pos = (wid - 657) / 2;

            noResults.Location = new System.Drawing.Point(pos, 40);

            noResults1.Location = new System.Drawing.Point(pos, 40);

            clientResults();


        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        public void newClientDisplay(ref clientDisplay[] clientDisplay, int i, int id, string name, string num, string snm, string addr)
        {
            ClientPanel.Controls.Add(clientDisplay[i]);
            clientDisplay[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            clientDisplay[i].Dock = System.Windows.Forms.DockStyle.Top;
            clientDisplay[i].Location = new System.Drawing.Point(0, 0);
            clientDisplay[i].Size = new System.Drawing.Size(798, 148);
            clientDisplay[i].TabIndex = 0;

            clientDisplay[i].Click += new System.EventHandler(this.clientDisplay1_Click);

            clientDisplay[i].getDetails(id,name,num,snm,addr);
        }

        public void newProDisplay(ref projectDisplay[] proDisplay, int i,int pId, string pname, string cnames,string desc)
        {
            proPanel.Controls.Add(proDisplay[i]);
            proDisplay[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            proDisplay[i].Dock = System.Windows.Forms.DockStyle.Top;
            proDisplay[i].Location = new System.Drawing.Point(0, 0);
            proDisplay[i].TabIndex = 0;

            proDisplay[i].Click += new System.EventHandler(this.projectDisplay1_Click);

            proDisplay[i].setValues(pId,pname,cnames,desc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c_clicked)
            {
                newProject newP = new newProject(this,cliname,user,cli,0);
                newP.Show();
                this.Hide();

            }
            else
            {
                Users cf = new Users(this,user);
                cf.ShowDialog();
            }
            
        }

        private void clientDisplay1_Load(object sender, EventArgs e)
        {

        }

        private void clientDisplay1_Click(object sender, EventArgs e)
        {
            clientDisplay obj = (clientDisplay)sender;

            cliFnames = obj.returnValus(1) + " " + obj.returnValus(2);


            proPanel.Show();
            ClientPanel.Hide();
            clientLab.Text = cliFnames + " Poject(s)";
            DisplayPanel.Width = 340;
            c_clicked = true;
            backbutt.Visible = true;

            cli = obj.getId();
            cliname = obj.returnValus(1);

            proResults();
        }

        private void projectDisplay1_Load_1(object sender, EventArgs e)
        {

        }

        private void projectDisplay1_Click(object sender, EventArgs e)
        {
            projectDisplay obj = (projectDisplay)sender;

            viewProject vPro = new viewProject(this,user,cli,obj);
            vPro.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        public void backtoNorm()
        {
            DisplayPanel.Width = Dpanelsize;
            proPanel.Hide();
            ClientPanel.Show();
            c_clicked = false;
            backbutt.Visible = false;
        }

        private void backbutt_Click(object sender, EventArgs e)
        {
            clientLab.Text = "Clients";
            backtoNorm();
        }

        public void getUser(int userfrom)
        {
            user = userfrom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();

            Password log = new Password(this);
            log.ShowDialog();
        }

        public void clientResults()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();

                string nme = "";
                string[] num = new string[3];
                string sname = "";
                string add = "";
                int id = 0;

                SqlDataAdapter dta = new SqlDataAdapter("getClients", conn);

                dta.SelectCommand.CommandType = CommandType.StoredProcedure;

                dta.Fill(dt);

                fmDataGrid.DataSource = dt;

                if (fmDataGrid.Rows[0].Cells[0].Value != null)
                {
                    noResults.Hide();

                    SqlDataAdapter cadt = new SqlDataAdapter("getContacts", conn);
                    cadt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    cadt.SelectCommand.Parameters.AddWithValue("@Con_Id", fmDataGrid.Rows[0].Cells[0].Value);

                    cadt.Fill(dt1);

                    dataGcontact.DataSource = dt1;

                    pDisplay = (fmDataGrid.Rows.Count - 1);

                    if(pDisplay > 4)
                    {
                        pDisplay -= 4;
                    }

                    for (int i = 0; i < pDisplay; i++)
                    {
                        id = Convert.ToInt32(fmDataGrid.Rows[i].Cells[0].Value);
                        nme = fmDataGrid.Rows[i].Cells[1].Value.ToString().Trim();
                        sname = fmDataGrid.Rows[i].Cells[2].Value.ToString().Trim();

                        for (int j = 0; j < (dataGcontact.Rows.Count - 1); j++) num[j] = dataGcontact.Rows[i].Cells[0].Value.ToString();

                        add = fmDataGrid.Rows[i].Cells[4].Value.ToString().Trim();

                        newClientDisplay(ref cDisplay, i, id, nme, num[0], sname, add);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex);
            }

            conn.Close();
        }

        public void proResults()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            DataTable prodata = new DataTable();
            DataTable clidata = new DataTable();

            projectDisplay[] pDisplay = new projectDisplay[4];

            SqlDataAdapter sda = new SqlDataAdapter("getProjects",conn);

            try
            {
                string pnam = "";
                string nam = "";
                string snam = "";
                string dess = "";
                int i = 0;

                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Cli_Id",cli);

                sda.Fill(prodata);

                if (prodata != null)
                {
                    foreach (DataRow rw in prodata.Rows)
                    {
                        noResults1.Hide();

                        proPanel.Controls.Clear();

                        pDisplay[i] = new projectDisplay();

                        pnam = rw["Pro_name"].ToString();

                        SqlDataAdapter csda = new SqlDataAdapter("getClientId",conn);

                        try
                        {
                            csda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            csda.SelectCommand.Parameters.AddWithValue("@Cli_id",cli);

                            csda.Fill(clidata);

                            foreach (DataRow rw1 in clidata.Rows)
                            {
                                nam = rw1["Cli_name"].ToString().Trim();

                                snam = rw1["Cli_sname"].ToString().Trim();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: \n\n" + ex);
                        }

                        dess = rw["Pro_Desc"].ToString();

                        newProDisplay(ref pDisplay,i,Convert.ToInt32(rw["Pro_Id"].ToString()),pnam,nam + " " + snam,dess);

                        if (i < 3)
                        {
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex);
            }
            conn.Close();
        }
    }
}
