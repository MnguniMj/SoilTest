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
    public partial class Test2Page : UserControl
    {
        double[] tin = new double[65];

        double[] mass = new double[65];

        int[] choice = new int[6];

        int[] noTab = new int[21];

        double[] piFactl24 = new double[21];

        double[] piFacto24 = new double[21];

        int loaded = 0;


        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");

        public Test2Page()
        {
            InitializeComponent();

            mainTable.Rows.Add("", "", "", "", "", "");
            mainTable.Rows.Add("", "", "", "", "", "");
            mainTable.Rows.Add("", "", "", "", "", "");
            mainTable.Rows.Add("", "", "", "", "", "");
            mainTable.Rows.Add("", "", "", "", "", "");
            mainTable.Rows.Add("", "", "", "", "", "");
            
            cBoxTable.Rows.Add("", "", "", "", "", "");

            tabsTable.Rows.Add("", "", "");

            limTable.Rows.Add("");
            limTable.Rows.Add("");

            linearTable.Rows.Add("");
            linearTable.Rows.Add("");


            for (int i = 0; i < 65; i++)
            {
                tin[i] = (double)i + 41;

                col1.Items.Add(tin[i].ToString());
                Col2.Items.Add(tin[i].ToString());
                Col3.Items.Add(tin[i].ToString());
                Col4.Items.Add(tin[i].ToString());
                Col5.Items.Add(tin[i].ToString());
                

                if (i < 5)
                {
                    mass[i] = 17.8;
                }
                else if (i==5)
                {
                    mass[i] = 17.6;
                }
                else if(i > 5 && i < 10)
                {
                    mass[i] = 17.8;
                }
                else if (i > 9 && i < 13)
                {
                    mass[i] = 17.6;
                }
                else if (i == 13 || i == 14)
                {
                    mass[i] = 17.8;
                }
                else if (i > 14 && i < 19)
                {
                    mass[i] = 17.6;
                }
                else if (i == 19 || i == 20)
                {
                    mass[i] = 17.8;
                }
                else if (i == 21)
                {
                    mass[i] = 18;
                }
                else if (i > 21 && i < 29)
                {
                    mass[i] = 17.8;
                }
                else if (i == 29)
                {
                    mass[i] = 18;
                }
                else if (i == 30)
                {
                    mass[i] = 14.6;
                }
                else if (i == 31)
                {
                    mass[i] = 14.8;
                }
                else if (i > 31 && i < 36)
                {
                    mass[i] = 14.6;
                }
                else if (i > 35 && i < 39)
                {
                    mass[i] = 14.8;
                }
                else if (i == 39)
                {
                    mass[i] = 14.6;
                }
                else if (i > 39 && i < 42)
                {
                    mass[i] = 14.8;
                }
                else if (i > 41 && i < 44)
                {
                    mass[i] = 14.6;
                }
                else if (i == 44)
                {
                    mass[i] = 14.8;
                }
                else if (i > 44 && i < 51)
                {
                    mass[i] = 14.6;
                }
                else if (i > 51 && i < 54)
                {
                    mass[i] = 14.8;
                }
                else if (i > 53 && i < 55)
                {
                    mass[i] = 14.6;
                }
                else if (i == 55)
                {
                    mass[i] = 14.8;
                }
                else if (i > 55 && i < 59)
                {
                    mass[i] = 14.6;
                }
                else if (i == 59 || i == 62 )
                {
                    mass[i] = 14.8;
                }
                else
                {
                    mass[i] = 14.6;
                }

            }

            for(int i = 0; i < 21; i++)
            {
                noTab[i] = i + 15;

                Col7.Items.Add(noTab[i].ToString());
                Col8.Items.Add(noTab[i].ToString());
                Col9.Items.Add(noTab[i].ToString());

                //PI is less than 24

                if (i == 0) piFactl24[i] = 0.6;

                if (i > 0 && i < 3) piFactl24[i] = 0.61;

                if (i > 2 && i < 5) piFactl24[i] = 0.62;

                if (i == 5) piFactl24[i] = 0.63;

                if (i == 6) piFactl24[i] = 0.64;

                if (i == 7) piFactl24[i] = 0.65;

                if (i > 7 && i < 10) piFactl24[i] = 0.66;

                if(i > 9 && i < 12) piFactl24[i] = 0.67;

                if (i == 12) piFactl24[i] = 0.68;

                if (i > 12 && i < 15) piFactl24[i] = 0.69;

                if (i == 15) piFactl24[i] = 0.7;

                if (i == 16) piFactl24[i] = 0.71;

                if (i > 16 && i < 19) piFactl24[i] = 0.72;

                if (i == 19) piFactl24[i] = 0.73;

                if (i == 20) piFactl24[i] = 0.74;

                
                //PI is between 24 and 30

                if (i >= 0 && i < 3) piFacto24[i] = 0.64;

                if (i > 2 && i < 6) piFacto24[i] = 0.65;

                if (i > 5 && i < 10) piFacto24[i] = 0.66;

                if (i > 9 && i < 13) piFacto24[i] = 0.67;

                if (i > 12 && i < 17) piFacto24[i] = 0.68;

                if (i > 16 && i < 20) piFacto24[i] = 0.69;

                if (i == 20) piFactl24[i] = 0.7;

            }

            DataGridViewComboBoxCell comb = new DataGridViewComboBoxCell();

            midTable.Rows.Add("", "", "");
            midTable.Rows.Add("", "", "");

            //midTable.Rows[0] = comb;


        }

        private void Test2Page_Load(object sender, EventArgs e)
        {
            
        }

        private void heading_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool calForm2()
        {
            bool result = false;

            for (int i = 0; i < 5;i++)
            {
                result = calMainT(i);

                if (!result) return result;
            }

            return result;
        }

        public void refreshTables()
        {
            for (int i = 0; i < 5; i++) cBoxTable.Rows[0].Cells[i].Value = "";

            for(int i=0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++) mainTable.Rows[i].Cells[j].Value = "";
            }

            for (int i = 0; i < 3; i++) tabsTable.Rows[0].Cells[i].Value = "";

            for(int i = 0; i < 2; i++)
            {
                limTable.Rows[i].Cells[0].Value = "";
                linearTable.Rows[i].Cells[0].Value = "";
            }

            for (int i = 0; i < 2;i++)
            {
                for (int j = 0; j < 3; j++) midTable.Rows[i].Cells[j].Value = "";
            }

            avfac.Text = "0";
        }

        public bool calMainT(int col)
        {
            try
            {
                double m = Convert.ToDouble(mainTable.Rows[0].Cells[col].Value.ToString()) - Convert.ToDouble(mainTable.Rows[1].Cells[col].Value.ToString());

                mainTable.Rows[3].Cells[col].Value = m.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Make Sure you entered values in (wm) and (cm)");
                return false;
            }

            try
            {
                double dm = Convert.ToDouble(mainTable.Rows[1].Cells[col].Value.ToString()) - Convert.ToDouble(mainTable.Rows[2].Cells[col].Value.ToString());
                mainTable.Rows[4].Cells[col].Value = dm.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Make Sure you entered values in (cm) and container No:(tin)");
                return false;
            }

            try
            {
                double pm = (Convert.ToDouble(mainTable.Rows[3].Cells[col].Value.ToString()) / Convert.ToDouble(mainTable.Rows[4].Cells[col].Value.ToString())) * 100;
                mainTable.Rows[5].Cells[col].Value = Math.Round(pm,1).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: invalid values in m and md ");

                return false;
            }

            return true;

        }

        public bool lowerTablesCal()
        {
            try
            {
                double lim = (Convert.ToDouble(mainTable.Rows[5].Cells[2].Value.ToString()) + Convert.ToDouble(mainTable.Rows[5].Cells[2].Value.ToString())) / 2;
                limTable.Rows[1].Cells[0].Value = Math.Round(lim, 1).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: make every field is filled");
                return false;
            }

            try
            {
                double lin = Convert.ToDouble(limTable.Rows[0].Cells[0].Value.ToString()) - Convert.ToDouble(limTable.Rows[1].Cells[0].Value.ToString());

                linearTable.Rows[0].Cells[0].Value = Math.Round(lin,1);
            }
            catch (Exception)
            {
                MessageBox.Show("Error: make every field is filled cheke plastic/liquid limit");
                return false;
            }

            try
            {
                double total = 0;

                for (int i = 0; i < 3; i++) total += Convert.ToDouble(midTable.Rows[1].Cells[i].Value.ToString());

                double fac = 0;

                if (Convert.ToDouble(linearTable.Rows[0].Cells[0].Value.ToString()) < 24)
                {
                    for(int i = 0; i < 21; i++)
                    {
                        if (Convert.ToDouble(tabsTable.Rows[0].Cells[0].Value.ToString()) == noTab[i])
                        {
                            fac = piFactl24[i];
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 21; i++)
                    {
                        if (Convert.ToDouble(tabsTable.Rows[0].Cells[0].Value.ToString()) == noTab[i])
                        {
                            fac = piFacto24[i];
                            break;
                        }
                    }

                }
                double av = averFactor(total, 3, fac);

                avfac.Text = Math.Round(mRound(av, 0.5),1).ToString();

                linearTable.Rows[1].Cells[0].Value = Math.Round(mRound(av, 0.5), 1).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: make every field is filled or invalid values in the bottom left table");
                return false;
            }

            return true;
        }

        public double mRound(double num, double rounder)
        {

            int first = 0;
            double remender = 0;
            double diff = 0;

            first = Convert.ToInt32(num/rounder);

            remender = Convert.ToInt32(num) - (first * rounder);

            diff = rounder - remender;

            if (remender > diff) return ((first * rounder) + rounder);

            else return (first * rounder);

        }

        public double averFactor(double num,int div, double factor)
        {
            double avf = 0;
            try
            {
                avf = (num / div) * factor;
            }
            catch (Exception)
            {
                MessageBox.Show("Error: avarage Factor divided by 0...");

                return -1.0;
            }

            return avf;
        }

        private void cBoxTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loaded > 4) // skip change of values when cells are greated (when cell is greated c# counts it as value changed)
            {
                for (int i = 0; i < 65; i++)
                {
                    if (tin[i].ToString() == cBoxTable.Rows[0].Cells[0].Value.ToString() && cBoxTable.Rows[0].Cells[0].Value.ToString() != "")
                    {
                        choice[0] = i + 1;

                        break;
                    }

                }

                for (int i = 0; i < 65; i++)
                {

                    if (tin[i].ToString() == cBoxTable.Rows[0].Cells[1].Value.ToString() && cBoxTable.Rows[0].Cells[1].Value.ToString() != "")
                    {
                        choice[1] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 65; i++)
                {
                    if (tin[i].ToString() == cBoxTable.Rows[0].Cells[2].Value.ToString() && cBoxTable.Rows[0].Cells[2].Value.ToString() != "")
                    {
                        choice[2] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 65; i++)
                {

                    if (tin[i].ToString() == cBoxTable.Rows[0].Cells[3].Value.ToString() && cBoxTable.Rows[0].Cells[3].Value.ToString() != "")
                    {
                        choice[3] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 65; i++)
                { 

                    if (tin[i].ToString() == cBoxTable.Rows[0].Cells[4].Value.ToString() && cBoxTable.Rows[0].Cells[4].Value.ToString() != "")
                    {
                        choice[4] = i + 1;

                        break;
                    }

                }
            }

            if((choice[0] - 1) >= 0)
            {
                mainTable.Rows[2].Cells[0].Value = mass[choice[0]-1].ToString();
            }

            if ((choice[1] - 1) >= 0)
            {
                mainTable.Rows[2].Cells[1].Value = mass[choice[1]-1].ToString();
            }

            if ((choice[2] - 1) >= 0)
            {
                mainTable.Rows[2].Cells[2].Value = mass[choice[2]-1].ToString();
            }

            if ((choice[3] - 1) >= 0)
            {
                mainTable.Rows[2].Cells[3].Value = mass[choice[3]-1].ToString();
            }

            if ((choice[4] - 1) >= 0)
            {
               mainTable.Rows[2].Cells[4].Value = mass[choice[4]-1].ToString();
            }

            if (loaded < 6) loaded++; //avoid incrementing loaded everytime values changes.
        }


        //SQL Database.................................................................................database

        public void saveTableData(int TesId)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter[] sda = new SqlDataAdapter[5];
            DataTable[] dt = new DataTable[5];

            int sel = 1;
            int pos;

            for (int i = 0; i < 5; i++)
            {
                if (i < 3) pos = (i + 1);
                else pos = (i - 2);

                if (i > 2) sel++;

                sda[i] = new SqlDataAdapter("checkTable2Top",conn);
                dt[i] = new DataTable();

                try
                {
                    sda[i].SelectCommand.CommandType = CommandType.StoredProcedure;
                    
                    sda[i].SelectCommand.Parameters.AddWithValue("@select", sel);
                    sda[i].SelectCommand.Parameters.AddWithValue("@Tes_Id",TesId);
                    sda[i].SelectCommand.Parameters.AddWithValue("@position", pos);

                    sda[i].Fill(dt[i]);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }
            }

            SqlCommand[] sc = new SqlCommand[5];
            string mode;

            sel = 1;

            for (int i = 0; i < 5; i++)
            {
                mode = "add";

                if (dt[i].Rows.Count > 0) mode = "update";

                if (i < 3) pos = (i+1);
                else pos = (i-2);

                if (i > 2 && sel < 2) sel++;

                sc[i] = new SqlCommand("test2TopPart",conn);

                try
                {
                    sc[i].CommandType = CommandType.StoredProcedure;

                    sc[i].Parameters.AddWithValue("@mode", mode);
                    sc[i].Parameters.AddWithValue("@select", sel);
                    sc[i].Parameters.AddWithValue("@Tes_Id", TesId);
                    sc[i].Parameters.AddWithValue("@position", pos);
                    sc[i].Parameters.AddWithValue("@wm", Convert.ToDouble(mainTable.Rows[0].Cells[i].Value));
                    sc[i].Parameters.AddWithValue("@cm", Convert.ToDouble(mainTable.Rows[1].Cells[i].Value));
                    sc[i].Parameters.AddWithValue("@c", Convert.ToDouble(mainTable.Rows[2].Cells[i].Value));
                    sc[i].Parameters.AddWithValue("@m", Convert.ToDouble(mainTable.Rows[3].Cells[i].Value));
                    sc[i].Parameters.AddWithValue("@dm", Convert.ToDouble(mainTable.Rows[4].Cells[i].Value));
                    sc[i].Parameters.AddWithValue("@perM", Convert.ToDouble(mainTable.Rows[5].Cells[i].Value));
                    if (i < 3) sc[i].Parameters.AddWithValue("@tapsN", Convert.ToDouble(tabsTable.Rows[0].Cells[i].Value));

                    sc[i].ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }

                
            }


            SqlDataAdapter sda2 = new SqlDataAdapter("checkTest2other", conn);
            DataTable dt2 = new DataTable();

            try
            {
                sda2.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda2.SelectCommand.Parameters.AddWithValue("@Tes_Id",TesId);

                sda2.Fill(dt2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            mode = "add";

            if (dt2.Rows.Count > 0) mode = "update";

            SqlCommand sc2 = new SqlCommand("test2Other", conn);

            try
            {
                sc2.CommandType = CommandType.StoredProcedure;
                sc2.Parameters.AddWithValue("@mode",mode);
                sc2.Parameters.AddWithValue("@Tes_Id", TesId);
                sc2.Parameters.AddWithValue("@shrN1", midTable.Rows[0].Cells[0].Value.ToString().Trim());
                sc2.Parameters.AddWithValue("@shrN2", midTable.Rows[0].Cells[1].Value.ToString().Trim());
                sc2.Parameters.AddWithValue("@shrN3", midTable.Rows[0].Cells[2].Value.ToString().Trim());
                sc2.Parameters.AddWithValue("@length1", midTable.Rows[1].Cells[0].Value.ToString().Trim());
                sc2.Parameters.AddWithValue("@length2", midTable.Rows[1].Cells[1].Value.ToString().Trim());
                sc2.Parameters.AddWithValue("@length3", midTable.Rows[1].Cells[2].Value.ToString().Trim());
                sc2.Parameters.AddWithValue("@shrinkF", Convert.ToDouble(avfac.Text));
                sc2.Parameters.AddWithValue("@lqFromgraph", Convert.ToDouble(limTable.Rows[0].Cells[0].Value));
                sc2.Parameters.AddWithValue("@plasl", Convert.ToDouble(limTable.Rows[1].Cells[0].Value));
                sc2.Parameters.AddWithValue("@plasIndex", Convert.ToDouble(linearTable.Rows[0].Cells[0].Value));
                sc2.Parameters.AddWithValue("@linShr", Convert.ToDouble(linearTable.Rows[1].Cells[0].Value));

                sc2.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            conn.Close();
        }

        //get info.............................................................................................

        public void getTableData(int TesId)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter[] sda = new SqlDataAdapter[5];
            DataTable[] dt = new DataTable[5];

            int sel = 1;
            int pos;

            for (int i = 0; i < 5; i++)
            {
                if (i < 3) pos = (i + 1);
                else pos = (i - 2);

                if (i > 2 && sel < 2) sel++;

                sda[i] = new SqlDataAdapter("checkTable2Top", conn);
                dt[i] = new DataTable();

                try
                {
                    sda[i].SelectCommand.CommandType = CommandType.StoredProcedure;

                    sda[i].SelectCommand.Parameters.AddWithValue("@select", sel);
                    sda[i].SelectCommand.Parameters.AddWithValue("@Tes_Id", TesId);
                    sda[i].SelectCommand.Parameters.AddWithValue("@position", pos);

                    sda[i].Fill(dt[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (dt[i].Rows.Count > 0)
                {
                    foreach (DataRow row in dt[i].Rows)
                    {
                        mainTable.Rows[0].Cells[i].Value = Convert.ToDouble(row["wm"]);
                        mainTable.Rows[1].Cells[i].Value = Convert.ToDouble(row["cm"]);
                        mainTable.Rows[2].Cells[i].Value = Convert.ToDouble(row["c"]);
                        mainTable.Rows[3].Cells[i].Value = Convert.ToDouble(row["m"]);
                        mainTable.Rows[4].Cells[i].Value = Convert.ToDouble(row["dm"]);
                        mainTable.Rows[5].Cells[i].Value = Convert.ToDouble(row["perM"]);
                        if (i < 3) 
                        {
                            DataGridViewComboBoxCell comboCell = (tabsTable.Rows[0].Cells[i] as DataGridViewComboBoxCell);

                            comboCell.Value = row["tapsN"].ToString().Trim();
                        }
                    }
                }
            }

            SqlDataAdapter sda2 = new SqlDataAdapter("checkTest2other", conn);
            DataTable dt2 = new DataTable();

            try
            {
                sda2.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda2.SelectCommand.Parameters.AddWithValue("@Tes_Id", TesId);

                sda2.Fill(dt2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            if (dt2.Rows.Count > 0)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    midTable.Rows[0].Cells[0].Value = row["shrN1"].ToString().Trim();
                    midTable.Rows[0].Cells[1].Value = row["shrN2"].ToString().Trim();
                    midTable.Rows[0].Cells[2].Value = row["shrN3"].ToString().Trim();
                    midTable.Rows[1].Cells[0].Value = Convert.ToDouble(row["length1"]);
                    midTable.Rows[1].Cells[1].Value = Convert.ToDouble(row["length2"]);
                    midTable.Rows[1].Cells[2].Value = Convert.ToDouble(row["length3"]);
                    avfac.Text = row["shrinkF"].ToString().Trim();
                    limTable.Rows[0].Cells[0].Value = Convert.ToDouble(row["lqFromgraph"]);
                    limTable.Rows[1].Cells[0].Value = Convert.ToDouble(row["plasl"]);
                    linearTable.Rows[0].Cells[0].Value = Convert.ToDouble(row["plasIndex"]);
                    linearTable.Rows[1].Cells[0].Value = Convert.ToDouble(row["linShr"]);

                }
            }

            if (dt[0].Rows.Count > 0 && dt[4].Rows.Count > 0)
            {

                for (int i = 0; i < 5; i++)
                {
                    double num = 0;

                    try
                    {
                        num = Convert.ToDouble(mainTable.Rows[2].Cells[i].Value.ToString().Trim());

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error \n\n" + ex);
                    }

                    for (int j = 0; j < 65; j++)
                    {
                        
                        if (mass[j] == num)
                        {
                            DataGridViewComboBoxCell comboCell = (cBoxTable.Rows[0].Cells[i] as DataGridViewComboBoxCell);
                            comboCell.Value = tin[i].ToString();
                            
                            continue;
                        }
                    }
                }
            }

            conn.Close();
        }
    }
 
}
