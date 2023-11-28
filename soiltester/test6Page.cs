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
    public partial class test6Page : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");

        //Moisture tins var..........................
        string[] conNo = new string[66];
        int[] massCon = new int[66];

        //Moulds var.......................
        string[] mouldNo = new string[37];
        int[] massMould = new int[37];
        int[] volMould = new int[37];

        //other variables
        int loaded = 0;
        int aloaded = 0;
        int bloaded = 0;
        int cloaded = 0;
        int[] botChoice = new int[3];
        int[] mainChoice = new int[4];
        double mmcavg1 = 0;
        double mmcavg2 = 0;

        public test6Page()
        {
            InitializeComponent();

            for (int i = 0; i < 66; i++)
            {
                if (i < 9) conNo[i] = "MT0" + (i + 1);
                else conNo[i] = "MT" + (i + 1);

                //singles.........................................................................

                if (i == 9) massCon[i] = 144;

                if (

                    i == 12 || i == 39 || i == 42 || i == 49 ||

                    i == 52 || i == 57 || i == 59 || i == 61

                    ) massCon[i] = 145;

                if (i == 24 || i == 26 || i == 31 || i == 58 || i == 60) massCon[i] = 146;

                if (i == 0 || i == 16 || i == 19 || i == 25 || i == 48) massCon[i] = 147;

                if (i == 8 || i == 20 || i == 32 || i == 53 || i == 56) massCon[i] = 148;


                //multiples.....................................................................
                if (i > 16 && i < 19 || i > 32 && i < 35) massCon[i] = 145;

                if (

                    i > 0 && i < 3 || i > 9 && i < 12 || i > 12 && i < 16 ||
                    i > 36 && i < 39 || i > 42 && i < 48 || i > 49 && i < 52 ||
                    i > 53 && i < 56 || i > 61 && i < 64

                    ) massCon[i] = 146;

                if (

                    i > 2 && i < 8 || i > 20 && i < 24 || i > 26 && i < 31 ||
                    i > 34 && i < 37 || i > 39 && i < 42 || i > 63 && i < 66

                    ) massCon[i] = 147;

            }

            MasVolAssign(ref massMould, ref volMould);

            for (int i = 0; i < 37; i++)
            {
                if (i < 9) mouldNo[i] = (i + 1).ToString();

                if (i > 8 && i < 16)
                {
                    if (i != 15) mouldNo[i] = "A" + (i - 8);
                    else mouldNo[i] = "A" + 9;
                }

                if (i > 15 && i < 29) mouldNo[i] = "B" + (i - 15);

                if (i > 28 && i < 34) mouldNo[i] = "M" + (i - 28);

                if (i > 33) mouldNo[i] = "X" + (i - 33);
            }

            setupform();

            for (int i = 0; i < 66; i++)
            {
                Col.Items.Add(conNo[i]);
                Col1.Items.Add(conNo[i]);
                Col2.Items.Add(conNo[i]);
                Col3.Items.Add(conNo[i]);

                if (i < 37)
                {
                    aCol.Items.Add(mouldNo[i]);
                    bCol.Items.Add(mouldNo[i]);
                    cCol.Items.Add(mouldNo[i]);
                }

            }

            for (int i = 0; i < 4; i++) mainChoice[i] = 0;
            for (int i = 0; i < 3; i++) botChoice[i] = 0;

        }

        private void test6Page_Load(object sender, EventArgs e)
        {

        }

        public void MasVolAssign(ref int[] mas, ref int[] vol)
        {
            if (

                mas.Length > 37 || mas.Length < 37 ||
                vol.Length > 37 || vol.Length < 37

                ) { MessageBox.Show("invalid array, array must be 37 of length"); return; }

            mas[0] = 4856;
            vol[0] = 2317;

            mas[1] = 4885;
            vol[1] = 2312;

            mas[2] = 4872;
            vol[2] = 2314;

            mas[3] = 4887;
            vol[3] = 2311;

            mas[4] = 4812;
            vol[4] = 2322;

            mas[5] = 4868;
            vol[5] = 2313;

            mas[6] = 4863;
            vol[6] = 2315;

            mas[7] = 4846;
            vol[7] = 2314;

            mas[8] = 4887;
            vol[8] = 2309;

            mas[9] = 4785;
            vol[9] = 2292;

            mas[10] = 4797;
            vol[10] = 2303;

            mas[11] = 4749;
            vol[11] = 2291;

            mas[12] = 4814;
            vol[12] = 2307;

            mas[13] = 4761;
            vol[13] = 2309;

            mas[14] = 4825;
            vol[14] = 2297;

            mas[15] = 4750;
            vol[15] = 2306;

            mas[16] = 5477;
            vol[16] = 2317;

            mas[17] = 5523;
            vol[17] = 2319;

            mas[18] = 5433;
            vol[18] = 2317;

            mas[19] = 5282;
            vol[19] = 2319;

            mas[20] = 5552;
            vol[20] = 2314;

            mas[21] = 5365;
            vol[21] = 2310;

            mas[22] = 5228;
            vol[22] = 2323;

            mas[23] = 4935;
            vol[23] = 2313;

            mas[24] = 5015;
            vol[24] = 2330;

            mas[25] = 5029;
            vol[25] = 2301;

            mas[26] = 5061;
            vol[26] = 2314;

            mas[27] = 5060;
            vol[27] = 2314;

            mas[28] = 4909;
            vol[28] = 2324;

            mas[29] = 4767;
            vol[29] = 2313;

            mas[30] = 4727;
            vol[30] = 2299;

            mas[31] = 4675;
            vol[31] = 2317;

            mas[32] = 4770;
            vol[32] = 2297;

            mas[33] = 5041;
            vol[33] = 2302;

            mas[34] = 5875;
            vol[34] = 2265;

            mas[35] = 6259;
            vol[35] = 2320;

            mas[36] = 5781;
            vol[36] = 2328;

        }

        private void setupform()
        {

            first1.Rows.Add("", "");
            first1.Rows.Add("", "");
            first1.Rows.Add("", "");
            first1.Rows.Add("", "");
            first1.Rows.Add("", "");
            first1.Rows.Add("", "");
            first1.Rows.Add("", "");

            first2.Rows.Add("", "");
            first2.Rows.Add("", "");
            first2.Rows.Add("", "");
            first2.Rows.Add("", "");
            first2.Rows.Add("", "");
            first2.Rows.Add("", "");
            
            first3.Rows.Add("", "");
            first3.Rows.Add("", "");
            first3.Rows.Add("", "");
            first3.Rows.Add("", "");
            first3.Rows.Add("", "");
            first3.Rows.Add("", "");

            aTable.Rows.Add("");
            acBox.Rows.Add("");

            bTable.Rows.Add("");
            bcBox.Rows.Add("");

            cTable.Rows.Add("");
            ccBox.Rows.Add("");

            for(int i = 0; i < 8; i++)
            {
                aTable1.Rows.Add("");
                bTable1.Rows.Add("");
                cTable1.Rows.Add("");
            }

            lastTable1.Rows.Add("");
            lastTable1.Rows.Add("");
            lastTable1.Rows.Add("");

            lastTable2.Rows.Add("");
            lastTable2.Rows.Add("");
            lastTable2.Rows.Add("");

            lastTable3.Rows.Add("");
            lastTable3.Rows.Add("");
            lastTable3.Rows.Add("");

            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");
            secpart1.Rows.Add("", "");

            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");
            secpart2.Rows.Add("", "");

            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");
            secpart3.Rows.Add("", "");

            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");
            secpart4.Rows.Add("", "");

            cBox.Rows.Add("", "","","");

            mmcAvg.Text = "mmc = 0";

        }

        private void cBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loaded > 3)
            {
                for (int i = 0; i < 66; i++)
                {
                    
                    if (cBox.Rows[0].Cells[0].Value.ToString() == conNo[i].ToString())
                    {
                        mainChoice[0] = i;
                    }
                   
                    if (cBox.Rows[0].Cells[1].Value.ToString() == conNo[i].ToString())
                    {
                        mainChoice[1] = i;
                    }
                 
                    if (cBox.Rows[0].Cells[2].Value.ToString() == conNo[i].ToString())
                    {
                        mainChoice[2] = i;
                    }

                    if (cBox.Rows[0].Cells[3].Value.ToString() == conNo[i].ToString())
                    {
                        mainChoice[3] = i; 
                    }
                   
                }
            }

            if ((mainChoice[0] - 1) >= 0) first2.Rows[2].Cells[0].Value = massCon[mainChoice[0]].ToString();

            if ((mainChoice[1] - 1) >= 0) first2.Rows[2].Cells[1].Value = massCon[mainChoice[1]].ToString();

            if ((mainChoice[2] - 1) >= 0) first3.Rows[2].Cells[0].Value = massCon[mainChoice[2]].ToString();

            if ((mainChoice[3] - 1) >= 0) first3.Rows[2].Cells[1].Value = massCon[mainChoice[3]].ToString();

            if (loaded < 4) loaded++;
        }

        private void acBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (aloaded > 0)
            {
                for (int i = 0; i < 37; i++)
                {
                    if (acBox.Rows[0].Cells[0].Value.ToString() == mouldNo[i].ToString())
                    {
                        botChoice[0] = i;

                        break;
                    }
                }
            }

            if ((botChoice[0] - 1) >= 0)
            {
                aTable1.Rows[1].Cells[0].Value = volMould[botChoice[0]].ToString();
                aTable1.Rows[3].Cells[0].Value = massMould[botChoice[0]].ToString();
            }

            if (aloaded < 1) aloaded++;

        }

        private void ccBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cloaded > 0)
            {
                for (int i = 0; i < 37; i++)
                {
                    if (ccBox.Rows[0].Cells[0].Value.ToString() == mouldNo[i].ToString())
                    {
                        botChoice[2] = i;

                        break;
                    }
                }
            }

            if ((botChoice[2] - 1) >= 0)
            {
                cTable1.Rows[1].Cells[0].Value = volMould[botChoice[2]].ToString();
                cTable1.Rows[3].Cells[0].Value = massMould[botChoice[2]].ToString();
            }

            if (cloaded < 1) cloaded++;
        }

        private void bcBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (bloaded > 0)
            {
                for (int i = 0; i < 37; i++)
                {
                    if (bcBox.Rows[0].Cells[0].Value.ToString() == mouldNo[i].ToString())
                    {
                        botChoice[1] = i;

                        break;
                    }
                }
            }

            if ((botChoice[1] - 1) >= 0)
            {
                bTable1.Rows[1].Cells[0].Value = volMould[botChoice[1]].ToString();
                bTable1.Rows[3].Cells[0].Value = massMould[botChoice[1]].ToString();
            }

            if (bloaded < 1) bloaded++;

        }

        public bool mainCal(ref DataGridView table, int c)
        {

            try
            {
                table.Rows[3].Cells[c].Value = Convert.ToDouble(table.Rows[0].Cells[c].Value.ToString()) - Convert.ToDouble(table.Rows[1].Cells[c].Value.ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("Error: make sure you entered values in (CW) and (CD)!");
                return false;
            }

            try
            {
                table.Rows[4].Cells[c].Value = Convert.ToDouble(table.Rows[1].Cells[c].Value.ToString()) - Convert.ToDouble(table.Rows[2].Cells[c].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error: make sure you entered values in (CW) and (CD)!");
                return false;
            }

            try
            {
                table.Rows[5].Cells[c].Value = (Convert.ToDouble(table.Rows[3].Cells[c].Value.ToString()) / Convert.ToDouble(table.Rows[4].Cells[c].Value.ToString())) * 100;

            }
            catch (Exception)
            {
                MessageBox.Show("Error: make sure you entered all value or values are valid");
                return false;
            }

            return true;
        }

        public bool otherCal()
        {
            try
            {
                total.Text = Math.Round(
                    (Convert.ToDouble(md.Text) * Convert.ToDouble(pd.Text))/ (Convert.ToDouble(_hm.Text) + 100),
                    1).ToString();
            }
            catch
            {
                MessageBox.Show("make sure Mass dry soil per mould is filled and try again");
                return false;
            }

            try
            {
                result.Text = (Convert.ToDouble(omcp.Text) + Convert.ToDouble(_hm.Text)+ Convert.ToDouble(pd.Text) + Convert.ToDouble(total.Text)).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);

                return false;
            }

            return true;
        }

        public void fromMOD(double dd,double mc,double av)
        {
            mmd1.Text = Math.Round(dd,1).ToString().Trim();

            omc.Text = omcp.Text = Math.Round(mc,1).ToString().Trim();

            modAvg.Text = _hm.Text = Math.Round(av,1).ToString().Trim();

            pd.Text = Math.Round(Convert.ToDouble(omcp.Text) - Convert.ToDouble(_hm.Text),1).ToString();
        }

        public bool avgCal(ref DataGridView table, ref Label av)
        {
            try
            {
                double value = Math.Round((Convert.ToDouble(table.Rows[5].Cells[0].Value.ToString()) + Convert.ToDouble(table.Rows[5].Cells[1].Value.ToString())) / 2,1);

                if (av.Name == "avgLab")
                {
                    av.Text = value.ToString();
                    mmcavg1 = value;
                }
                else
                {
                    av.Text = "mmc = " + value;
                    mmcavg2 = value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);

                return false;
            }

            return true;
        }

        public bool abcCal(ref DataGridView table)
        {
            try
            {
                table.Rows[4].Cells[0].Value = Convert.ToDouble(table.Rows[2].Cells[0].Value.ToString()) - Convert.ToDouble(table.Rows[3].Cells[0].Value.ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("Error: check mv & mm if they are entered correctly");
                return false;
            }

            try
            {
                table.Rows[5].Cells[0].Value = Convert.ToDouble(table.Rows[3].Cells[0].Value.ToString()) / (mmcavg2 * 100 );
            }
            catch (Exception)
            {
                MessageBox.Show("Error: check mv & mm if they are entered correctly");
                return false;
            }

            try
            {
                table.Rows[6].Cells[0].Value = (Convert.ToDouble(table.Rows[1].Cells[0].Value.ToString()) / Convert.ToDouble(table.Rows[5].Cells[0].Value.ToString())) * 1000;
            }
            catch (Exception)
            {
                MessageBox.Show("Error: some value are invalid or not entered 6");
                return false;
            }

            try
            {
                table.Rows[7].Cells[0].Value = (Convert.ToDouble(table.Rows[6].Cells[0].Value.ToString()) / Convert.ToDouble(mmd1.Text)) * 100;
            }
            catch (Exception)
            {
                MessageBox.Show("Error: some value are invalid or not entered 7");
                return false;
            }

            return true;
        }

        public bool bottomCal(ref DataGridView table)
        {
            try
            {
                table.Rows[2].Cells[0].Value = Math.Round((Convert.ToDouble(table.Rows[1].Cells[0].Value) - Convert.ToDouble(table.Rows[0].Cells[0].Value)) / 127 * 100);
            }
            catch
            {
                MessageBox.Show("Some values are missing or invalid, check and re-try");
                return false;
            }

            return true;
        }

        public bool allCal()
        {
            for (int i = 0; i < 4;i++)
            {
                if (i < 2)
                {
                    if (!mainCal(ref first2, i )) return false;
                }
                else
                {
                    if (!mainCal(ref first3, i - 2)) return false;
                }
            }

            if(!avgCal(ref first2,ref avgLab)) return false;

            if (!avgCal(ref first2, ref mmcAvg)) return false;

            if (!otherCal()) return false;

            if (!abcCal(ref aTable1)) return false;

            if (!abcCal(ref bTable1)) return false;
            
            if (!abcCal(ref cTable1)) return false;

            //first bottom area....

            if(!bottomCal(ref lastTable1)) return false; 
            
            if(!bottomCal(ref lastTable2)) return false;
            
            if(!bottomCal(ref lastTable3)) return false;

            return true;
        }

        //SQL Database...................................................................................................................

        public void saveTableData(int TesId)
        {
            string mode = "add";

            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter[] sda = new SqlDataAdapter[2];
            DataTable[] dt = new DataTable[2];

            for (int i = 0; i < 2;i++)
            {
                sda[i] = new SqlDataAdapter("checkWR_Comp", conn);
                dt[i] = new DataTable();
                try
                {
                    sda[i].SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda[i].SelectCommand.Parameters.AddWithValue("@select", i + 1);
                    sda[i].SelectCommand.Parameters.AddWithValue("@Tes_Id", TesId);

                    sda[i].Fill(dt[i]);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }
            }

            if (dt[0].Rows.Count > 0) mode = "update";

            SqlCommand sc = new SqlCommand("Water_Req", conn);

            try
            {
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@mode", mode);
                sc.Parameters.AddWithValue("@Tes_Id", TesId);
                sc.Parameters.AddWithValue("@diff", Convert.ToDouble(pd.Text));
                sc.Parameters.AddWithValue("@dmd", Convert.ToDouble(total.Text));
                sc.Parameters.AddWithValue("@total", Convert.ToDouble(result.Text));

                sc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            mode = "add";

            if (dt[1].Rows.Count > 0) mode = "update";

            SqlCommand sc1 = new SqlCommand("Water_Req", conn);

            try
            {
                sc1.CommandType = CommandType.StoredProcedure;
                sc1.Parameters.AddWithValue("@mode", mode);
                sc1.Parameters.AddWithValue("@Tes_Id", TesId);
                sc1.Parameters.AddWithValue("@diff", Convert.ToDouble(pd.Text));
                sc1.Parameters.AddWithValue("@dmd", Convert.ToDouble(total.Text));
                sc1.Parameters.AddWithValue("@total", Convert.ToDouble(result.Text));

                sc1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            SqlDataAdapter[] sda1 = new SqlDataAdapter[4];
            DataTable[] dt1 = new DataTable[4];

            for(int i = 0; i < 4; i++)
            {
                checkMoisData(ref sda1[i], ref dt1[i], i, TesId);
            }

            SqlCommand[] sc2 = new SqlCommand[4];

            for (int i = 0;i < 4;i++)
            {
                mode = "add";
                int pos;
                string typee;
                sc2[i] = new SqlCommand("Moist_DataPro", conn);

                if (dt1[i].Rows.Count > 0) mode = "update";

                if (i < 2)
                {
                    pos = i;
                    typee = "mmc";

                    moisData(ref first2, ref sc2[i],typee,mode,i,pos,TesId);
                }
                else
                {
                    pos = i - 2;
                    typee = "mmc1";

                    moisData(ref first3, ref sc2[i], typee, mode, i, pos, TesId);
                }
            }

            SqlDataAdapter[] sda3 = new SqlDataAdapter[6];
            DataTable[] dt3 = new DataTable[6];

            char typ = 'a';

            for (int i = 0; i < 6; i++)
            {
                sda3[i] = new SqlDataAdapter("checkS6Other",conn);
                dt3[i] = new DataTable();

                
                int sel;

                if (i < 3) typ++;

                if (i == 2) typ = 'a';

                if (i > 2) typ++;

                if (i < 3) sel = 1;
                else sel = 2;

                checkRest(ref sda3[i],ref dt3[i], sel, TesId, typ);
            }

            SqlCommand[] sc3 = new SqlCommand[3];

            SqlCommand[] sc4 = new SqlCommand[3];

             typ = 'a';

            for (int i = 0; i < 6; i++)
            {
                if(i < 3) sc3[i] = new SqlCommand("Comp_DataPro", conn);

                if(i > 2) sc4[i - 3] = new SqlCommand("Exp_Data", conn);

                int prt = 1;

                mode = "add";
                if (dt3[i].Rows.Count > 0) mode = "update";

                if (i < 3 && i != 0) ++typ;

                if (i == 3) typ = 'a';

                if (i > 3) ++typ;

                if (i > 2) prt = 2;

                switch (i)
                {
                    case 0:
                        bottomTbls(ref aTable1,ref aTable,ref sc3[i], prt, mode, typ, TesId);
                        break;
                    case 1:
                        bottomTbls(ref bTable1, ref bTable, ref sc3[i], prt, mode, typ, TesId);
                        break;
                    case 2:
                        bottomTbls(ref cTable1, ref cTable, ref sc3[i], prt, mode, typ, TesId);
                        break;
                    case 3:
                        bottomTbls(ref lastTable1, ref sc4[i - 3], prt, mode, typ, TesId);
                        break;
                    case 4:
                        bottomTbls(ref lastTable2, ref sc4[i - 3], prt, mode, typ, TesId);
                        break;
                    case 5:
                        bottomTbls(ref lastTable3, ref sc4[i - 3], prt, mode, typ, TesId);
                        break;
                }
            }

            conn.Close();
        }

        public void checkMoisData(ref SqlDataAdapter sda, ref DataTable dt,int i, int TesID)
        {
            int pos;
            string typee;

            if (i < 3)
            {
                pos = i + 1;
                typee = "mmc";
            }
            else 
            { 
                pos = 1 - 2;
                typee = "mmc1";
            }

            sda = new SqlDataAdapter("checkMoistData", conn);
            dt = new DataTable();

            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Type", typee);
                sda.SelectCommand.Parameters.AddWithValue("@position", pos);
                sda.SelectCommand.Parameters.AddWithValue("@Tes_Id", TesID);

                sda.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }
        }

        public void moisData(ref DataGridView tbl, ref SqlCommand sc, string typee, string mode, int i, int pos, int TesID)
        {
            try
            {
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@mode", mode);
                sc.Parameters.AddWithValue("@Tes_Id", TesID);
                sc.Parameters.AddWithValue("@Type", typee);
                sc.Parameters.AddWithValue("@position", pos + 1);
                sc.Parameters.AddWithValue("@MoistCN",  (cBox.Rows[0].Cells[i].Value));
                sc.Parameters.AddWithValue("@cw", Convert.ToDouble(tbl.Rows[0].Cells[pos].Value));
                sc.Parameters.AddWithValue("@cd", Convert.ToDouble(tbl.Rows[1].Cells[pos].Value));
                sc.Parameters.AddWithValue("@c", Convert.ToDouble(tbl.Rows[2].Cells[pos].Value));
                sc.Parameters.AddWithValue("@mm", Convert.ToDouble(tbl.Rows[3].Cells[pos].Value));
                sc.Parameters.AddWithValue("@md", Convert.ToDouble(tbl.Rows[4].Cells[pos].Value));
                sc.Parameters.AddWithValue("@m", Convert.ToDouble(tbl.Rows[5].Cells[pos].Value));

                sc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }
        }

        public void checkRest(ref SqlDataAdapter sda, ref DataTable dt, int s, int TesID, char typ)
        {
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@select", s);
                sda.SelectCommand.Parameters.AddWithValue("@Tes_Id", TesID);
                sda.SelectCommand.Parameters.AddWithValue("@type", typ);

                sda.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }
        }

        public void bottomTbls(ref DataGridView tbl, ref DataGridView tbl2, ref SqlCommand sc,int prt,string mode,char typ, int id)
        {
            sc.CommandType = CommandType.StoredProcedure;

            try
            {
                sc.Parameters.AddWithValue("@mode", mode);
                sc.Parameters.AddWithValue("@Tes_Id", id);
                sc.Parameters.AddWithValue("@type", typ);

                sc.Parameters.AddWithValue("@compEffort", tbl2.Rows[0].Cells[0].Value.ToString().Trim());
                sc.Parameters.AddWithValue("@hamN", tbl.Rows[0].Cells[0].Value.ToString().Trim());
                sc.Parameters.AddWithValue("@v", Convert.ToDouble(tbl.Rows[1].Cells[0].Value));
                sc.Parameters.AddWithValue("@mw", Convert.ToDouble(tbl.Rows[2].Cells[0].Value));
                sc.Parameters.AddWithValue("@mm", Convert.ToDouble(tbl.Rows[3].Cells[0].Value));
                sc.Parameters.AddWithValue("@mwm", Convert.ToDouble(tbl.Rows[4].Cells[0].Value));
                sc.Parameters.AddWithValue("@mdm", Convert.ToDouble(tbl.Rows[5].Cells[0].Value));
                sc.Parameters.AddWithValue("@dmPv", Convert.ToDouble(tbl.Rows[6].Cells[0].Value));
                sc.Parameters.AddWithValue("@perComp", Convert.ToDouble(tbl.Rows[7].Cells[0].Value));
               
                sc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }
        }

        public void bottomTbls(ref DataGridView tbl, ref SqlCommand sc, int prt, string mode, char typ, int id)
        {
            sc.CommandType = CommandType.StoredProcedure;

            try
            {
                sc.Parameters.AddWithValue("@mode", mode);
                sc.Parameters.AddWithValue("@Tes_Id", id);
                sc.Parameters.AddWithValue("@type", typ);

                sc.Parameters.AddWithValue("@d0", Convert.ToDouble(tbl.Rows[0].Cells[0].Value));
                sc.Parameters.AddWithValue("@d4", Convert.ToDouble(tbl.Rows[1].Cells[0].Value));
                sc.Parameters.AddWithValue("@perswing", Convert.ToDouble(tbl.Rows[2].Cells[0].Value));
                
                sc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }
        }

        public void getTableData(int TesId)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter[] sda = new SqlDataAdapter[2];
            DataTable[] dt = new DataTable[2];

            for (int i = 0; i < 2; i++)
            {
                sda[i] = new SqlDataAdapter("checkWR_Comp", conn);
                dt[i] = new DataTable();
                try
                {
                    sda[i].SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda[i].SelectCommand.Parameters.AddWithValue("@select", i + 1);
                    sda[i].SelectCommand.Parameters.AddWithValue("@Tes_Id", TesId);

                    sda[i].Fill(dt[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }
            }

            if(dt[0].Rows.Count > 0)
            {
                foreach(DataRow row in dt[0].Rows)
                {
                    pd.Text = row["diff"].ToString().Trim();
                    total.Text = row["dmd"].ToString().Trim();
                    result.Text = row["total"].ToString().Trim();
                }
            }

            if (dt[1].Rows.Count > 0)
            {
                foreach (DataRow row in dt[1].Rows)
                {
                    mmd1.Text = row["mdd"].ToString().Trim();
                    omc.Text = row["omc"].ToString().Trim();
                    omcp.Text = row["omc"].ToString().Trim();
                    md.Text = row["md"].ToString().Trim();
                    modAvg.Text = row["avgg"].ToString().Trim();
                    _hm.Text = row["avgg"].ToString().Trim();
                }
            }

            SqlDataAdapter[] sda1 = new SqlDataAdapter[4];
            DataTable[] dt1 = new DataTable[4];

            for (int i = 0; i < 4; i++)
            {
                checkMoisData(ref sda1[i], ref dt1[i], i, TesId);
            }

            for (int i = 0; i < 4;i++)
            {
               if(i < 2) moistResults(ref first2, ref dt1[i],i,i);
               else moistResults(ref first3, ref dt1[i], i - 2, i);
            }

            SqlDataAdapter[] sda3 = new SqlDataAdapter[6];
            DataTable[] dt3 = new DataTable[6];
            
            char typ = 'a';

            for (int i = 0; i < 6; i++)
            {
                sda3[i] = new SqlDataAdapter("checkS6Other", conn);
                dt3[i] = new DataTable();

                
                int sel;

                if (i < 3 && i != 0) ++typ;

                if (i == 3) typ = 'a';

                if (i > 3) ++typ;

                if (i < 3) sel = 1;
                else sel = 2;

                MessageBox.Show("type: " + typ);

                checkRest(ref sda3[i], ref dt3[i], sel, TesId, typ);
            }

            for(int i = 0; i < 3; i++)
            {
                if (dt3[i].Rows.Count > 0)
                {
                   if (i == 0) bottomResults(ref aTable1,ref aTable,ref acBox,ref dt3[i],1);

                   if (i == 1) bottomResults(ref bTable1, ref bTable, ref bcBox, ref dt3[i], 1);

                   if (i == 2) bottomResults(ref cTable1, ref cTable, ref ccBox, ref dt3[i], 1);
                }
            }

            for (int i = 3; i < 6; i++)
            {
                if (dt3[i].Rows.Count > 0)
                {
                    if (i == 3) bottomResults(ref lastTable1, ref aTable, ref acBox, ref dt3[i], 2);

                    if (i == 4) bottomResults(ref lastTable2, ref bTable, ref bcBox, ref dt3[i], 2);

                    if (i == 5) bottomResults(ref lastTable3, ref cTable, ref ccBox, ref dt3[i], 2);

                }
            }

            conn.Close();
        }

        public void moistResults(ref DataGridView tbl, ref DataTable dt,int c,int i)
        {
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    DataGridViewCell cell = (cBox.Rows[0].Cells[i] as DataGridViewCell);

                    cell.Value = row["MoistCN"].ToString().Trim();

                    tbl.Rows[0].Cells[c].Value = row["cw"].ToString().Trim();
                    tbl.Rows[1].Cells[c].Value = row["cd"].ToString().Trim();
                    tbl.Rows[2].Cells[c].Value = row["c"].ToString().Trim();
                    tbl.Rows[3].Cells[c].Value = row["mm"].ToString().Trim();
                    tbl.Rows[4].Cells[c].Value = row["md"].ToString().Trim();
                    tbl.Rows[5].Cells[c].Value = row["m"].ToString().Trim();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }
            }
        }

        public void bottomResults(ref DataGridView tbl, ref DataGridView abctbl, ref DataGridView boxtbl, ref DataTable dt,int prt)
        {
            if (prt == 1)
            {

                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        abctbl.Rows[0].Cells[0].Value = row["compEffort"].ToString().Trim();
                        tbl.Rows[0].Cells[0].Value = row["hamN"].ToString().Trim();
                        tbl.Rows[1].Cells[0].Value = row["v"].ToString().Trim();
                        tbl.Rows[2].Cells[0].Value = row["mw"].ToString().Trim();
                        tbl.Rows[3].Cells[0].Value = row["mm"].ToString().Trim();
                        tbl.Rows[4].Cells[0].Value = row["mwm"].ToString().Trim();
                        tbl.Rows[5].Cells[0].Value = row["mdm"].ToString().Trim();
                        tbl.Rows[6].Cells[0].Value = row["dmPv"].ToString().Trim();
                        tbl.Rows[7].Cells[0].Value = row["perComp"].ToString().Trim();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error \n\n" + ex);
                    }
                }

                for (int i = 0; i < 37; i++)
                {
                    try
                    {
                        if (massMould[i] == Convert.ToInt32(tbl.Rows[4].Cells[0].Value) && volMould[i] == Convert.ToInt32(tbl.Rows[2].Cells[0].Value))
                        {
                            DataGridViewCell cell = (boxtbl.Rows[0].Cells[0] as DataGridViewCell);
                            cell.Value = mouldNo[i];

                            break;
                        }
                    }
                    catch
                    {

                    }
                }

            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        tbl.Rows[0].Cells[0].Value = row["d0"].ToString().Trim();
                        tbl.Rows[1].Cells[0].Value = row["d4"].ToString().Trim();
                        tbl.Rows[2].Cells[0].Value = row["perswing"].ToString().Trim();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error \n\n" + ex);
                    }
                }
            }
        }
    }
}
