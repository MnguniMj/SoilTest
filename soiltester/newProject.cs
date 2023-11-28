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
    public partial class newProject : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");

        int hideBtTrack = 0;
        int panel1H = 0;
        int panelnewH = 0;
        Form1 first = new Form1();


        //Test 1 variables
        TestPage[] sample = new TestPage[10];
        string[] sampleName = new string[10];
        int[] sampleNum = new int[10];
        int count = 0;
        int count1 = 0;
        int h = 0; //hold for count
        int holdindex = 0;
        int user = 0;
        int cli = 0;
        int proId = 0;

        public newProject(Form1 fst, string name,int user1, int cli1,int proid)
        {
            InitializeComponent();
            first = fst; // mona ke assign formo ea pele hore e bulehe
            client.Text = name;

            user = user1;
            cli = cli1;
            proId = proid;

            calButt2.Hide();

            panel1H = panel1.Height;
            panelnewH = pNewpro.Height;

            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;

            this.Size = new Size(x, y);

            //fullscreen
            this.WindowState = FormWindowState.Maximized;

            for (int i = 0; i < 10; i++)
            {
                sample[i] = new TestPage();
            }
            

        }

        private void newProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            first.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hideBtTrack == 0)
            {
                button1.Text = "Show";
                fshieft.Hide();
                pClient.Hide();
                pProject.Hide();
                pOper.Hide();
                pDesc.Hide();
                pImg.Hide();
                panel4.Hide();
                buttArea.Hide();
                calButt2.Show();

                panel1.Height = panelnewH;

                hideBtTrack = 1;
            }
            else
            {
                button1.Text = "Hide";
                fshieft.Show();
                pClient.Show();
                pProject.Show();
                pOper.Show();
                pDesc.Show();
                pImg.Show();
                panel4.Show();
                buttArea.Show();
                calButt2.Hide();

                panel1.Height = panel1H;

                hideBtTrack = 0;
            }
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (testTabs.SelectedTab == test1)
            {
                testPage1.fieldUpdate();

                sample[h].copyFrom(testPage1);
            }
            else if(testTabs.SelectedTab == test2)
            {
                test2Page1.calForm2();

                test2Page1.lowerTablesCal();
            }
            else if (testTabs.SelectedTab == test3)
            {
                for (int i = 1;i < 6 ; i++)
                {
                    test5Page1.masWetMatCal(i);
                    test5Page1.lowerSecCal(i);
                }

                for(int i = 1; i < 6; i++) test5Page1.lowerSecCal1(i);


            }
            else
            {
                MessageBox.Show(" Test 1 is not selected.... the selected tab is " + testTabs.SelectedTab.Name.ToString());
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            first.Show();
            this.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void calButt2_Click(object sender, EventArgs e)
        {
            if (testTabs.SelectedTab == test1)
            {
                testPage1.fieldUpdate();

                sample[h].copyFrom(testPage1);
            }
            else
            {
                MessageBox.Show(" Test 1 is not selected.... the selected tab is " + testTabs.SelectedTab.Name.ToString());
            }
        }

        private void calbutt_Click(object sender, EventArgs e)
        {
            if (testTabs.SelectedTab == test1)
            {
                testPage1.fieldUpdate();

                sample[h].copyFrom(testPage1);
            }
            else
            {
                MessageBox.Show("Test 1 is not selected.... the selected tab is " + testTabs.SelectedTab.Name.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (proName.Text.Trim() != "" && client.Text.Trim() != "" && optextf.Text.Trim() != "")
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                //Code to retrive all data with the name provided to see if it exists

                SqlDataAdapter esda = new SqlDataAdapter("getProject", conn);

                DataTable edt = new DataTable();

                esda.SelectCommand.CommandType = CommandType.StoredProcedure;

                esda.SelectCommand.Parameters.AddWithValue("@Pro_name", proName.Text.Trim().ToLower());

                esda.Fill(edt);

                if (edt == null) //checking if the project alread exists
                {
                    SqlCommand comm = new SqlCommand("ProjectPro", conn);
                    string date = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();

                    try //try to save new user into database
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@mode", "add");
                        comm.Parameters.AddWithValue("@Cli_Id", cli);
                        comm.Parameters.AddWithValue("@Pro_name", proName.Text.Trim().ToLower());
                        comm.Parameters.AddWithValue("@Pro_enteredby", user);
                        comm.Parameters.AddWithValue("@Pro_date", DateTime.Parse(date));
                        comm.Parameters.AddWithValue("@Pro_Desc", description.Text.Trim());

                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving data into database... \n\n" + ex);
                    }
                    finally
                    {
                        MessageBox.Show("Data successfully saved.... ");

                    }

                    SqlDataAdapter sda = new SqlDataAdapter("getProject", conn);

                    DataTable dt = new DataTable();

                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                    sda.SelectCommand.Parameters.AddWithValue("@Pro_name", proName.Text.Trim().ToLower());

                    sda.Fill(dt);

                    if (dt != null)
                    {
                        foreach (DataRow rw in dt.Rows)
                        {
                            proId = Convert.ToInt32(rw["Pro_Id"]);
                        }
                    }

                    SampleInfo si = new SampleInfo(this, user, proId);
                    si.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Project Not Saved... Please change Project name, because name already exists");
                }
            }
            else
            {
                MessageBox.Show("You need fill atleast project Name, Client and Oparater to Save Data");
            }

            
            conn.Close();
        }

        public void hideFields()
        { 
            //hide all details
            button1.Text = "Show";
            fshieft.Hide();
            pClient.Hide();
            pProject.Hide();
            pOper.Hide();
            pDesc.Hide();
            pImg.Hide();
            panel4.Hide();
            buttArea.Hide();
            

            panel1.Height = panelnewH;

            hideBtTrack = 1;

            
        }

        public void setSample(int num)
        {
            sampleNo.Text = num.ToString();
        }

        public void newSample(string name,int num)
        {

            if (conn.State == ConnectionState.Closed) conn.Open();

            testPage1.refreshTables();

            SqlDataAdapter sda = new SqlDataAdapter("checkSample",conn);
            DataTable dt = new DataTable();

            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Sam_name", name.Trim());
                sda.SelectCommand.Parameters.AddWithValue("@Pro_Id", proId);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\n " + ex);
            }


            if (dt.Rows.Count < 1)
            {
                SqlCommand sc = new SqlCommand("SamplePro", conn);

                try
                {
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@Sam_name", name.Trim());
                    sc.Parameters.AddWithValue("@Sam_number", num);
                    sc.Parameters.AddWithValue("@Pro_Id", proId);

                    sc.ExecuteNonQuery();

                    samples.Items.Add(name);
                    samples.Text = name;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: \n\n" + ex);
                }
            }
            else
            {
                MessageBox.Show("Samples already exists for this project please use a different Sample name");
            }

            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (proId != 0)
            {
                SampleInfo si = new SampleInfo(this, user, 1);
                si.ShowDialog();
            }
            else
            {
                MessageBox.Show("You need to save project details first (under New Project hit the 'save projce data' button)");
            }
        }

        private void newProject_Load(object sender, EventArgs e)
        {

        }

        private void samples_SelectedIndexChanged(object sender, EventArgs e)
        {

            

             testPage1.refreshTables();

             //testPage1.copyFrom(sample[holdindex]);
             
            
        }
    }
}
