using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

namespace soiltester
{
    public partial class viewProject : Form
    {
        private bool ishidden = false;
        Form1 first = new Form1();
        int userr = 0;
        int cli = 0;
        int currentSample = 0;
        projectDisplay prod;

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");

        public viewProject(Form1 fst,int user, int clii, projectDisplay obj)
        {
            InitializeComponent();
            first = fst;

            userr = user;
            cli = clii;
            prod = obj;
            //testPage1.vProAdd();
            //testPage1.fieldUpdate();

            proDetails.Hide();
            button1.Text = "Show Project Info";
            ishidden = true;


            //maximize and Full screen at startup

            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;

            this.Size = new Size(x, y);

            //fullscreen
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ishidden == false)
            {
                proDetails.Hide();
                button1.Text = "Show Project Info";
                ishidden = true;

            }
            else
            {
                proDetails.Show();
                button1.Text = "Hide Project Info";
                ishidden = false;
            }
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            first.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void viewProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            first.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            proName.ReadOnly = false;
            proName.BackColor = Color.White;

            client.ReadOnly = false;
            client.BackColor = Color.White;

            opert.ReadOnly = false;
            opert.BackColor = Color.White;

            desc.ReadOnly = false;
            desc.BackColor = Color.White;
        }

        public void print()
        {

            saveFile.Filter = "PDF *.pdf |*.pdf";
            saveFile.FileName = "Untitled";

            if (saveFile.ShowDialog() == DialogResult.OK) //if save button is clicked
            {

                FileStream fs = null;

                try
                {
                    fs = new FileStream(saveFile.FileName, FileMode.Create);
                }
                catch (Exception)
                {
                    MessageBox.Show("other programs are using the pdf you are tring to overwrite, close it and try again");
                }

                //create document and open it

                Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                PdfWriter writer = PdfWriter.GetInstance(document, fs);


                document.Open();

                //add image

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("SOILHEADER.jpg");
                img.ScalePercent(26f);

                document.Add(img);

                //add headers and tables

                string p = "FORM M2.1 - REPORTING FORM FOR SOILS AND GRAVELS".PadRight(50); //makeng space
                
                Paragraph header = new Paragraph(p + " 14/02/2022");

                header.Alignment = (int)HorizontalAlignment.Center;
                header.Font.Size = 12;

                document.Add(header);

                PdfPTable table = new PdfPTable(7);

                PdfPCell cell = new PdfPCell(new Phrase("Project Description"));
                cell.Colspan = 7;
                cell.BackgroundColor = new BaseColor(250, 191, 143);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Project:.......................  Client:....................... Date Reported:........................ \n\n " +
                                                "Date Sampling.................. Date Checked:....................... Reported by:..................... \n\n" +
                                                "Report #:......................... Checked by:........................."));

                cell.Colspan = 7;
                cell.Rowspan = 5;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Sample Description"));
                cell.Colspan = 7;
                cell.BackgroundColor = new BaseColor(250, 191, 143);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Sample No.:"));
                cell.Colspan = 2;
                cell.BackgroundColor = new BaseColor(255, 255, 255);
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(" "));
                for(int i = 0; i < 5; i++) table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Location of Sampling"));
                cell.Colspan = 2;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(" "));
                for (int i = 0; i < 5; i++) table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Depth in mm"));
                cell.Colspan = 2;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(" "));
                for (int i = 0; i < 5; i++) table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Weather Conditions"));
                cell.Colspan = 2;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(" "));
                for (int i = 0; i < 5; i++) table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Material Description"));
                cell.Colspan = 2;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(" "));
                for (int i = 0; i < 5; i++) table.AddCell(cell);

                //third part

                cell = new PdfPCell(new Phrase("Screen Analysis (% Passing)  -  SANS 3001  :  GR 1"));
                cell.Colspan = 7;
                cell.BackgroundColor = new BaseColor(250, 191, 143);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;

                table.AddCell(cell);

                string[] num = new string[] {"75.0 mm","63.0 mm","50.0 mm","37.5 mm","28.0 mm","20.0 mm","14.0 mm", "5.0 mm","2.0 mm","0.425 mm","0.075 mm"};

                for (int i = 0; i < 11; i++)
                {
                    cell = new PdfPCell(new Phrase(num[i]));
                    cell.Colspan = 2;

                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(" "));
                    for (int j = 0; j < 5; j++) table.AddCell(cell);


                }


                //end of pdf
                table.WidthPercentage = 100;
                document.Add(table);
                // Close the document  
                document.Close();
                // Close the writer instance  
                writer.Close();
                // Always close open filehandles explicity  
                fs.Close();

                MessageBox.Show("pdf succefully Ceated...");

            }



        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void printButt_Click_1(object sender, EventArgs e)
        {
            print();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SampleInfo si = new SampleInfo(this, userr, prod.returnID(),1);
            si.ShowDialog();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();

            emp.ShowDialog();
        }

        public void setSample(int num)
        {
            sampleNo.Text = num.ToString();
        }

        public void newSample(string name, int num)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            testPage1.refreshTables();

            SqlDataAdapter sda = new SqlDataAdapter("checkSample", conn);
            DataTable dt = new DataTable();

            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Sam_name", name.Trim());

                MessageBox.Show("" + prod.returnID());

                sda.SelectCommand.Parameters.AddWithValue("@Pro_Id", prod.returnID());

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
                    sc.Parameters.AddWithValue("@Pro_Id", prod.returnID());

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

        private void samples_SelectedIndexChanged(object sender, EventArgs e)
        {
            testPage1.refreshTables();
            test2Page1.refreshTables();
            test5Page1.refreshTables();

            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("checkSample",conn);
            DataTable dt = new DataTable();

            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Sam_name", samples.Text.Trim());
                sda.SelectCommand.Parameters.AddWithValue("@Pro_Id", prod.returnID());

                sda.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    currentSample = Convert.ToInt32(row["Sam_Id"]);
                }
            }

            if (makeorselectTest(1,false) != 0)
            {
                testPage1.getTableData(makeorselectTest(1, false));
            }

            if (makeorselectTest(2, false) != 0)
            {
                test2Page1.getTableData(makeorselectTest(2, false));
            }

            if(makeorselectTest(3, false) != 0)
            {
                test5Page1.getTableData(makeorselectTest(3, false));
            }


            conn.Close();
        }

        private void viewProject_Load(object sender, EventArgs e)
        {
            getAllSamples();

            tableInfo();
        }

        public void getAllSamples()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("getSamples",conn);
            DataTable dt = new DataTable();

            try
            {

                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Pro_Id", prod.returnID());
                
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            if (dt.Rows.Count > 0)
            {
                int i = 0;

                foreach (DataRow rw in dt.Rows)
                {
                    samples.Items.Add(rw["Sam_name"].ToString().Trim());

                    if (i == 0)
                    {
                        samples.Text = rw["Sam_name"].ToString().Trim();
                        setSample(Convert.ToInt32(rw["Sam_number"]));

                        currentSample = Convert.ToInt32(rw["Sam_Id"]);
                    }

                    i++;
                }

            }
            else
            {
                MessageBox.Show("No Samples were found... New Sample Dialog will open automatically...");
                
                SampleInfo si = new SampleInfo(this, userr, prod.returnID(), 1);
                
                si.ShowDialog();
            }

            conn.Close();
        }

        public void tableInfo()
        {
            testPage1.refreshTables();
            test2Page1.refreshTables();
            test5Page1.refreshTables();

            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter[] sda = new SqlDataAdapter[4];
            DataTable[] dt = new DataTable[4];

            for (int i = 0; i < 4; i++) sda[i] = new SqlDataAdapter("checkTest",conn);

            for(int i = 0; i < 4; i++)
            {
                dt[i] = new DataTable();

                try
                {

                    sda[i].SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda[i].SelectCommand.Parameters.AddWithValue("@test", i+1);
                    sda[i].SelectCommand.Parameters.AddWithValue("@Sam_Id", currentSample);

                    sda[i].Fill(dt[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error at " + (i+1) + " \n\n" + ex);
                }
            }

            for(int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    if (dt[i].Rows.Count > 0)
                    {
                        foreach (DataRow row in dt[i].Rows)
                        { 
                            testPage1.getTableData(Convert.ToInt32(row["Tes_Id"]));
                        }
                    }
                    else
                    {
                        makeorselectTest(i+1,true);
                    }
                }

                if (i == 1)
                {
                    if (dt[i].Rows.Count > 0)
                    {
                        foreach (DataRow row in dt[i].Rows)
                        {
                            test2Page1.getTableData(Convert.ToInt32(row["Tes_Id"]));
                        }
                    }
                    else
                    {
                        makeorselectTest(i + 1,true);
                    }
                }

                if (i == 2)
                {
                    if (dt[i].Rows.Count > 0)
                    {
                        foreach (DataRow row in dt[i].Rows)
                        {
                            test5Page1.getTableData(Convert.ToInt32(row["Tes_Id"]));
                        }
                        test5Page1.genGraph();

                        test6Page1.fromMOD(test5Page1.ddandmc(1), test5Page1.ddandmc(2), test5Page1.ddandmc(3));
                    }
                    else
                    {
                        makeorselectTest(i + 1, true);
                    }
                }

                if (i == 3)
                {
                    if (dt[i].Rows.Count > 0)
                    {
                        foreach (DataRow row in dt[i].Rows)
                        {
                            test6Page1.getTableData(Convert.ToInt32(row["Tes_Id"]));
                        }

                    }
                    else
                    {
                        makeorselectTest(i + 1,true);
                    }
                }
            }

            conn.Close();
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataGridView dt = test5Page1.enterEv();

            pressEnter(ref dt);

            if (currentSample != 0)
            {
                if (testsTab.SelectedTab == test1)
                {
                    if (testPage1.fieldUpdate())
                    {
                        if (conn.State == ConnectionState.Closed) conn.Open();

                        if (makeorselectTest(1, false) != 0) testPage1.saveTableData(makeorselectTest(1, false));
                        else testPage1.saveTableData(makeorselectTest(1, true));

                        conn.Close();
                    }
                }
                if (testsTab.SelectedTab == test2)
                {
                    if (test2Page1.calForm2() && test2Page1.lowerTablesCal()) 
                    {
                        if (conn.State == ConnectionState.Closed) conn.Open();

                        if (makeorselectTest(2, false) != 0) test2Page1.saveTableData(makeorselectTest(2, false));
                        else test2Page1.saveTableData(makeorselectTest(2, true));

                        conn.Close();
                    }
                }

                if (testsTab.SelectedTab == test3)
                {
                    bool CalIsCorrect = false;

                    for (int i = 1;i < 6; i++)
                    {
                        if (test5Page1.masWetMatCal(i) && test5Page1.lowerSecCal(i))
                        {
                            CalIsCorrect = true;
                        }
                        else
                        {
                            CalIsCorrect = false;
                            break;
                        }
                    }

                    /* this loops are separate because lowerSecCal1 depend on some values in lowerSecCal, therefore
                       lowerSecCal  needs to loop first and complete */
                    
                    if (CalIsCorrect)
                    {
                        for (int i = 1; i < 6; i++)
                        {
                            if (test5Page1.lowerSecCal1(i))
                            {
                                CalIsCorrect = true;
                            }
                            else
                            {
                                CalIsCorrect = false;
                                break;
                            }
                        }
                    }

                    if (test5Page1.topCal() && CalIsCorrect)
                    {
                        if (conn.State == ConnectionState.Closed) conn.Open();

                        if (makeorselectTest(3, false) != 0) test5Page1.saveTableData(makeorselectTest(3, false));
                        else test5Page1.saveTableData(makeorselectTest(3, true));

                        test5Page1.genGraph();

                        test6Page1.fromMOD(test5Page1.ddandmc(1), test5Page1.ddandmc(2), test5Page1.ddandmc(3));

                        conn.Close();
                    }
                }

                if (testsTab.SelectedTab == test4)
                {
                    if (test6Page1.allCal())
                    {
                        if (conn.State == ConnectionState.Closed) conn.Open();

                        if (makeorselectTest(4, false) != 0) test6Page1.saveTableData(makeorselectTest(4, false));
                        else test6Page1.saveTableData(makeorselectTest(4, true));

                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Create at least 1 sample number and press calculate again");
            }
        }

        private void pressEnter(ref DataGridView dv)
        {
           this.ActiveControl = dv;
        }

        private int makeorselectTest(int type,bool all)
        {
            int id = 0;

            if (all)
            {
                SqlCommand sc = new SqlCommand("makeTests", conn);

                try
                {
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@Sam_Id", currentSample);
                    sc.Parameters.AddWithValue("@Tes_type", type);

                    sc.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }
            }

            SqlDataAdapter sda = new SqlDataAdapter("checkTest",conn);
            DataTable dt = new DataTable();

            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Sam_Id", currentSample);
                sda.SelectCommand.Parameters.AddWithValue("@test", type);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    id = Convert.ToInt32(row["Tes_Id"]);
                } 
            }

            return id;
        }
    }
}
