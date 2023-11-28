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
    public partial class test5Page : UserControl
    {
        //Moisture tins var..........................
        string[] conNo = new string[66];
        int[] massCon = new int[66];

        //Moulds var.......................
        string[] mouldNo = new string[37];
        int[] massMould = new int[37];
        int[] volMould = new int[37];

        //other var
        int loaded = 0;
        int loaded1 = 0;
        int loaded2 = 0;
        int[] choice = new int[5];
        int[] choice1 = new int[2];
        double av = 0;
        double av1 = 0;

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");

        public test5Page()
        {
            InitializeComponent();

            topTable.Rows.Add("Total Sample Mass (g)", "", "Mass Scalped (g)", "", "Percentage Scalped (%)", "");

            secondTable.Rows.Add("Test", "", "", "", "", "", "");
            secondTable.Rows.Add("Percentage Water added (P)", "", "", "", "", "", "");
            secondTable.Rows.Add("Water add per mould: (P x A)/100 ml", "", "", "", "", "", "");

            
            
            //second part of the the tables

            //secondTable.Rows.Add("Mould number ", "", "", "", "", "", "");

            
            secTable2.Rows.Add("Mould volume(V)", "", "", "", "", "", "");
            secTable2.Rows.Add("Hammer number", "", "", "", "", "", "");
            secTable2.Rows.Add("Mass mould + wet material (MW)", "", "", "", "", "", "");
            secTable2.Rows.Add("Mass Mould (MLd)", "", "", "", "", "", "");
            secTable2.Rows.Add("Mass wet material : MW - MLd: (B)", "", "", "", "", "", "");


            //secondTable.Rows.Add("Moisture tin Number", "", "", "", "", "", "");

             
            secTable3.Rows.Add("Mass tin + wet material: (TW)", "", "", "", "", "", "");
            secTable3.Rows.Add("Mass tin + dry material: (TD)", "", "", "", "", "", "");
            secTable3.Rows.Add("Mass empty tin: (T)", "", "", "", "", "", "");
            secTable3.Rows.Add("Mass water lost= TW-TD=(C)", "", "", "", "", "", "");
            secTable3.Rows.Add("Mass dry material: TD - T = (D)", "", "", "", "", "", "");
            secTable3.Rows.Add("Approx % moisture (AP) = CX100/D ", "", "", "", "", "", "");
            secTable3.Rows.Add("Hygroscopic moisture (HM)=  AP-M", "", "", "", "", "", "");
            secTable3.Rows.Add("Hygro moisture used for average: (HV)", "", "", "", "", "", "");
            secTable3.Rows.Add("Hygroscopic correction: (HC)", "", "", "", "", "", "");
            secTable3.Rows.Add("True % MC : HC-HV+AP (TC) ", "", "", "", "", "", "");
            secTable3.Rows.Add("Wet density : B /V*1000 =(WD)", "", "", "", "", "", "");
            secTable3.Rows.Add("Dry density : WD/(100+TC)*100=(DD)", "", "", "", "", "", "");


            sideTable.Rows.Add("", "");
            sideTable.Rows.Add("", "");
            sideTable.Rows.Add("", "");
            sideTable.Rows.Add("", "");
            sideTable.Rows.Add("", "");
            sideTable.Rows.Add("", "");
            sideTable.Rows.Add("", "");

            Enterbox.Rows.Add("");

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


            MasVolAssign(ref massMould,ref volMould);

            for (int i = 0; i < 37; i++)
            {
                if (i < 9) mouldNo[i] = (i + 1).ToString();

                if (i > 8 && i < 16) {
                    if (i != 15) mouldNo[i] = "A" + (i - 8);
                    else mouldNo[i] = "A" + 9;
                }

                if (i > 15 && i < 29) mouldNo[i] = "B" + (i - 15);

                if (i > 28 && i < 34) mouldNo[i] = "M" + (i - 28);

                if (i > 33) mouldNo[i] = "X" + (i - 33);

            }

            cBoxTable.Rows.Add("","","","","");

            cBoxTable2.Rows.Add("", "", "", "", "");

            sideBoxTable.Rows.Add("", "");

            for (int i = 0; i < 66; i++)
            {
                Col6.Items.Add(conNo[i]);
                Col7.Items.Add(conNo[i]);
                Col8.Items.Add(conNo[i]);
                Col9.Items.Add(conNo[i]);
                Col10.Items.Add(conNo[i]);

                Col11.Items.Add(conNo[i]);
                Col12.Items.Add(conNo[i]);

                if (i < 37)
                {
                    Col1.Items.Add(mouldNo[i]);
                    Col2.Items.Add(mouldNo[i]);
                    Col3.Items.Add(mouldNo[i]);
                    Col4.Items.Add(mouldNo[i]);
                    Col5.Items.Add(mouldNo[i]);
                }
            }

            choice1[0] = 0;
            choice1[1] = 0;

        }

        private void test5Page_Load(object sender, EventArgs e)
        {

        }

        public bool topCal()
        {
            try
            {
                topTable.Rows[0].Cells[5].Value = (Convert.ToDouble(topTable.Rows[0].Cells[3].Value.ToString())/ Convert.ToDouble(topTable.Rows[0].Cells[1].Value.ToString()) * 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
                return false;
            }

            return true;
        }

        public bool masWetMatCal(int c)
        {
            try
            {
                secTable2.Rows[4].Cells[c].Value = (

                        Convert.ToDouble(secTable2.Rows[2].Cells[c].Value.ToString()) - Convert.ToDouble(secTable2.Rows[3].Cells[c].Value.ToString())

                    ).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Check if mass moulds entrys are filled...");
                return false;
            }

            return true;
        }

        public bool lowerSecCal(int c)
        {
            try
            {
                secTable3.Rows[3].Cells[c].Value = (

                    Convert.ToDouble(secTable3.Rows[0].Cells[c].Value.ToString()) - Convert.ToDouble(secTable3.Rows[1].Cells[c].Value.ToString())

                    );
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Mass water lost might not be filled");
                return false;
            }

            try
            {

                secTable3.Rows[4].Cells[c].Value = (

                Convert.ToDouble(secTable3.Rows[1].Cells[c].Value.ToString()) - Convert.ToDouble(secTable3.Rows[2].Cells[c].Value.ToString())

                );
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Mass dry materials might not be filled");
                return false;
            }

            try
            {
                secTable3.Rows[5].Cells[c].Value = (

                    (Convert.ToDouble(secTable3.Rows[3].Cells[c].Value.ToString())*100) / Convert.ToDouble(secTable3.Rows[4].Cells[c].Value.ToString())

                    );
            }
            catch (Exception)
            {
                MessageBox.Show("Error: check if values entered in Mass tin are correct");
                return false;
            }

            //side table calculations...................................................................................................................................

            if (c < 3) 
            {
                try
                {
                    sideTable.Rows[3].Cells[c - 1].Value = (

                    Convert.ToDouble(sideTable.Rows[0].Cells[c - 1].Value.ToString()) - Convert.ToDouble(sideTable.Rows[1].Cells[c - 1].Value.ToString())

                    );
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Mass water lost might not be filled");
                    return false;
                }

                try
                {
                    sideTable.Rows[4].Cells[c - 1].Value = (

                    Convert.ToDouble(sideTable.Rows[1].Cells[c - 1].Value.ToString()) - Convert.ToDouble(sideTable.Rows[2].Cells[c - 1].Value.ToString())

                    );
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Mass dry materials might not be filled");
                    return false;
                }

                try
                {
                    sideTable.Rows[5].Cells[c - 1].Value = (

                    (Convert.ToDouble(sideTable.Rows[3].Cells[c - 1].Value.ToString()) * 100) / Convert.ToDouble(sideTable.Rows[4].Cells[c - 1].Value.ToString())

                    );
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: check if values entered in Mass tin are correct");
                    return false;                
                }

            }

            //end of side table calculations............................................................................................................................
            try
            {
                secTable3.Rows[6].Cells[c].Value = (

                Convert.ToDouble(secTable3.Rows[5].Cells[c].Value.ToString()) - Convert.ToDouble(secondTable.Rows[1].Cells[c].Value.ToString())

                );

            }
            catch (Exception e)
            {
                MessageBox.Show("Error occurred at hygroscopic moisture \n" + e);
                return false;
            }
            

            secTable3.Rows[7].Cells[c].Value = secTable3.Rows[6].Cells[c].Value;

            return true;

        }

        public bool lowerSecCal1(int c)
        {

            if (c == 1)
            {
                for(int i = 0; i < 2;i++)
                {
                    try
                    {
                        av += Convert.ToDouble(sideTable.Rows[5].Cells[i].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error getting Approx % moisture (AP) make sure all field were filled ");
                    }
                    
                }

                av = av / 2;

                for (int i = 1; i < 6; i++)
                {
                    try
                    {
                        av1 += Convert.ToDouble(secTable3.Rows[5].Cells[i].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hygro moisture used for average: (HV)");
                    }
                }

                av1 = av1 / 5;
            }

            avg.Text = av.ToString();

            avg2.Text = "Av=      " + av1;

            secTable3.Rows[8].Cells[c].Value = av1;

            try
            {
                secTable3.Rows[9].Cells[c].Value = (
                    Convert.ToDouble(secTable3.Rows[8].Cells[c].Value.ToString()) - (
                        Convert.ToDouble(secTable3.Rows[7].Cells[c].Value.ToString()) + Convert.ToDouble(secTable3.Rows[5].Cells[c].Value.ToString())
                       )
                    );
            }
            catch(Exception)
            {
                MessageBox.Show("Error: at True percentage, varify every entry was filled");
                return false;
            }

            try
            {
                secTable3.Rows[10].Cells[c].Value = (Convert.ToDouble(secTable2.Rows[3].Cells[c].Value.ToString()) / Convert.ToDouble(secTable2.Rows[0].Cells[c].Value.ToString())) * 1000;

                secTable3.Rows[11].Cells[c].Value = (Convert.ToDouble(secTable3.Rows[10].Cells[c].Value.ToString()) / ((Convert.ToDouble(secTable3.Rows[0].Cells[c].Value.ToString())) + 100) * 100);
            }
            catch (Exception)
            {
                MessageBox.Show("Error: the might be invaled values or some values may be empty ");
                return false;
            }

            return true;
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

        private void cBoxTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < 5; i++) choice[i] = -1;

            if (loaded > 4) // skip change of values when cells are greated (when cell is greated c# counts it as value changed)
            {

                for (int i = 0; i < 37; i++)
                {
                    if(cBoxTable.Rows[0].Cells[0].Value.ToString() == mouldNo[i].ToString())
                    {
                        choice[0] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 37; i++)
                {
                    if (cBoxTable.Rows[0].Cells[1].Value.ToString() == mouldNo[i].ToString())
                    {
                        choice[1] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 37; i++)
                {
                    if (cBoxTable.Rows[0].Cells[2].Value.ToString() == mouldNo[i].ToString())
                    {
                        choice[2] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 37; i++)
                {
                    if (cBoxTable.Rows[0].Cells[3].Value.ToString() == mouldNo[i].ToString())
                    {
                        choice[3] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 37; i++)
                {
                    if (cBoxTable.Rows[0].Cells[4].Value.ToString() == mouldNo[i].ToString())
                    {
                        choice[4] = i + 1;

                        break;
                    }
                }

            }

            if ((choice[0] - 1) >= 0)
            {
                secTable2.Rows[0].Cells[1].Value = volMould[choice[0]-1].ToString();
                secTable2.Rows[3].Cells[1].Value = massMould[choice[0]-1].ToString();
            }

            if ((choice[1] - 1) >= 0)
            {
                secTable2.Rows[0].Cells[2].Value = volMould[choice[1]-1].ToString();
                secTable2.Rows[3].Cells[2].Value = massMould[choice[1]-1].ToString();
            }

            if ((choice[2] - 1) >= 0)
            {
                secTable2.Rows[0].Cells[3].Value = volMould[choice[2]-1].ToString();
                secTable2.Rows[3].Cells[3].Value = massMould[choice[2]-1].ToString();
            }

            if ((choice[3] - 1) >= 0)
            {
                secTable2.Rows[0].Cells[4].Value = volMould[choice[3]-1].ToString();
                secTable2.Rows[3].Cells[4].Value = massMould[choice[3]-1].ToString();
            }

            if ((choice[4] - 1) >= 0)
            {
                secTable2.Rows[0].Cells[5].Value = volMould[choice[4]-1].ToString();
                secTable2.Rows[3].Cells[5].Value = massMould[choice[4]-1].ToString();
            }

            if (loaded < 6) loaded++;
        }

        private void cBoxTable2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < 5; i++) choice[i] = -1;

            if (loaded1 > 4) // skip change of values when cells are greated (when cell is greated c# counts it as value changed)
            {

                for (int i = 0; i < 66; i++)
                {
                    if (cBoxTable2.Rows[0].Cells[0].Value.ToString() == conNo[i].ToString())
                    {
                        choice[0] = i + 1;

                        break;
                    }
                }


                for (int i = 0; i < 66; i++)
                {

                    if (cBoxTable2.Rows[0].Cells[1].Value.ToString() == conNo[i].ToString())
                    {
                        choice[1] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 66; i++)
                {

                    if (cBoxTable2.Rows[0].Cells[2].Value.ToString() == conNo[i].ToString())
                    {
                        choice[2] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 66; i++)
                {

                    if (cBoxTable2.Rows[0].Cells[3].Value.ToString() == conNo[i].ToString())
                    {
                        choice[3] = i + 1;

                        break;
                    }
                }

                for (int i = 0; i < 66; i++)
                {

                    if (cBoxTable2.Rows[0].Cells[4].Value.ToString() == conNo[i].ToString())
                    {
                        choice[4] = i + 1;

                        break;
                    }
                }

            }

            if ((choice[0] - 1) >= 0)
            {
                secTable3.Rows[2].Cells[1].Value = massCon[choice[0] - 1].ToString();
            }

            if ((choice[1] - 1) >= 0)
            {
                secTable3.Rows[2].Cells[2].Value = massCon[choice[1] - 1].ToString();
            }

            if ((choice[2] - 1) >= 0)
            {
                secTable3.Rows[2].Cells[3].Value = massCon[choice[2] - 1].ToString();
            }

            if ((choice[3] - 1) >= 0)
            {
                secTable3.Rows[2].Cells[4].Value = massCon[choice[3] - 1].ToString();
            }

            if ((choice[4] - 1) >= 0)
            {
                secTable3.Rows[2].Cells[5].Value = massCon[choice[4] - 1].ToString();
            }

            if (loaded1 < 6) loaded1++;

        }

        private void sideBoxTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            

            if (loaded2 > 1) // skip change of values when cells are greated (when cell is greated c# counts it as value changed)
            {

                for (int i = 0; i < 66; i++)
                {
                    if (sideBoxTable.Rows[0].Cells[0].Value.ToString() == conNo[i].ToString())
                    {
                        choice1[0] = i + 1;

                    }

                    if (sideBoxTable.Rows[0].Cells[1].Value.ToString() == conNo[i].ToString())
                    {
                        choice1[1] = i + 1;

                    }
                }

            }

            if ((choice1[0] - 1) >= 0)
            {
                sideTable.Rows[2].Cells[0].Value = massCon[choice1[0] - 1].ToString();
            }

            if ((choice1[1] - 1) >= 0)
            {
                sideTable.Rows[2].Cells[1].Value = massCon[choice1[1] - 1].ToString();
            }

            if (loaded2 < 6) loaded2++;
        }

        public DataGridView enterEv()
        {
            return Enterbox;
        }

        public void refreshTables()
        {
            for (int i = 1; i < 6; i += 2)
            {
                topTable.Rows[0].Cells[i].Value = "";
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    secondTable.Rows[i].Cells[j].Value = "";
                }
            }

            for (int i = 0; i < 5; i++)
            {
                cBoxTable.Rows[0].Cells[i].Value = "";

                cBoxTable2.Rows[0].Cells[i].Value = "";
            }

            for (int i = 0; i < 5;i++)
            {
                for (int j = 1; j < 6; j++) secTable2.Rows[i].Cells[j].Value = "";
            }

            for (int i = 0; i < 12; i++)
            {
                for (int j = 1; j < 6; j++) secTable3.Rows[i].Cells[j].Value = "";
            }

            for (int i = 0; i < 2; i++) sideBoxTable.Rows[0].Cells[i].Value = "";

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 2; j++) sideTable.Rows[i].Cells[j].Value = "";
            }

            

            avg.Text = "";
            avg2.Text = "Av = 0";
        }

        public void genGraph()
        {
            for (int i = 1;i < 6;i++)
            {
                graph5.Series[0].Points.AddXY(Convert.ToDouble(secTable3.Rows[9].Cells[i].Value), Convert.ToDouble(secTable3.Rows[11].Cells[i].Value));
            }
        }

        public double ddandmc(int op)
        {
            if (op == 1)
            {
                double[] dd = new double[5];

                for (int i = 0; i < 5; i++) dd[i] = 0;

                for (int i = 0;i < 5; i++)
                {
                    dd[i] = Convert.ToDouble(secTable3.Rows[11].Cells[i+1].Value);
                }

                //bubble sort....
                for (int i = 0;i < 5;i++)
                {
                    for (int j = 0; j < (5 - i) - 1;j++)
                    {
                        if (dd[j] > dd[j+1])
                        {
                            //swap values...
                            double hold = 0;
                            hold = dd[j];
                            dd[j] = dd[j + 1];
                            dd[j + 1] = hold;
                        }
                    }
                }

                return dd[4];
            }
            else if(op == 2)
            {
                return Convert.ToDouble(secTable3.Rows[5].Cells[3].Value);
            }
            else
            {
                return Convert.ToDouble(avg.Text);
            }
        }

        public void saveTableData(int TesId)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter[] sda = new SqlDataAdapter[5];
            DataTable[] dt = new DataTable[5];
            string mode = "add";

            for (int i = 0; i < 5; i++)
            {
                sda[i] = new SqlDataAdapter("checkS5", conn);
                dt[i] = new DataTable();

                try
                {
                    sda[i].SelectCommand.CommandType = CommandType.StoredProcedure;

                    sda[i].SelectCommand.Parameters.AddWithValue("@select", 1);
                    sda[i].SelectCommand.Parameters.AddWithValue("@Tes_Id", TesId);
                    sda[i].SelectCommand.Parameters.AddWithValue("@position", i + 1);

                    sda[i].Fill(dt[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }
            }

            SqlCommand[] sc = new SqlCommand[5];

            for (int i = 0; i < 5; i++)
            {
                if (dt[i].Rows.Count > 0) mode = "update";

                sc[i] = new SqlCommand("S5TestsPro", conn);

                try
                {
                    sc[i].CommandType = CommandType.StoredProcedure;

                    sc[i].Parameters.AddWithValue("@mode", mode);
                    sc[i].Parameters.AddWithValue("@Tes_Id", TesId);
                    sc[i].Parameters.AddWithValue("@position", i + 1);
                    sc[i].Parameters.AddWithValue("@p", Convert.ToDouble(secondTable.Rows[0].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@pxa_perm", Convert.ToDouble(secondTable.Rows[1].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@modN", cBoxTable.Rows[0].Cells[i].Value.ToString().Trim());
                    sc[i].Parameters.AddWithValue("@v", Convert.ToDouble(secTable2.Rows[0].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@hamN", secTable2.Rows[1].Cells[i + 1].Value.ToString().Trim());
                    sc[i].Parameters.AddWithValue("@mw", Convert.ToDouble(secTable2.Rows[2].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@mld", Convert.ToDouble(secTable2.Rows[3].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@b", Convert.ToDouble(secTable2.Rows[4].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@tinN", cBoxTable2.Rows[0].Cells[i].Value.ToString().Trim());
                    sc[i].Parameters.AddWithValue("@tw", Convert.ToDouble(secTable3.Rows[0].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@td", Convert.ToDouble(secTable3.Rows[1].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@t", Convert.ToDouble(secTable3.Rows[2].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@c", Convert.ToDouble(secTable3.Rows[3].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@d", Convert.ToDouble(secTable3.Rows[4].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@ap", Convert.ToDouble(secTable3.Rows[5].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@hm", Convert.ToDouble(secTable3.Rows[6].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@hv", Convert.ToDouble(secTable3.Rows[7].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@hc", Convert.ToDouble(secTable3.Rows[8].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@tc", Convert.ToDouble(secTable3.Rows[9].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@wd", Convert.ToDouble(secTable3.Rows[10].Cells[i + 1].Value));
                    sc[i].Parameters.AddWithValue("@dd", Convert.ToDouble(secTable3.Rows[11].Cells[i + 1].Value));

                    sc[i].ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }

                mode = "add";
            
            }

            SqlDataAdapter[] sda1 = new SqlDataAdapter[2];
            DataTable[] dt1 = new DataTable[2];

            for (int i = 0; i < 2; i++)
            {
                sda1[i] = new SqlDataAdapter("checkS5", conn);
                dt1[i] = new DataTable();

                try
                {
                    sda1[i].SelectCommand.CommandType = CommandType.StoredProcedure;

                    sda1[i].SelectCommand.Parameters.AddWithValue("@select",2);
                    sda1[i].SelectCommand.Parameters.AddWithValue("@Tes_Id", TesId);
                    sda1[i].SelectCommand.Parameters.AddWithValue("@position", i + 1);

                    sda1[i].Fill(dt1[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);      
                }
            }

            mode = "add";

            SqlCommand[] sc1 = new SqlCommand[2];

            for (int i = 0; i < 2; i++)
            {
                if (dt1[i].Rows.Count > 0) mode = "update";

                sc1[i] = new SqlCommand("S5hyg_Mc", conn);

                try
                {
                    sc1[i].CommandType = CommandType.StoredProcedure;

                    sc1[i].Parameters.AddWithValue("@mode", mode);
                    sc1[i].Parameters.AddWithValue("@Tes_Id", TesId);
                    sc1[i].Parameters.AddWithValue("@position", i + 1);
                    sc1[i].Parameters.AddWithValue("@tinN", sideBoxTable.Rows[0].Cells[i].Value.ToString().Trim());
                    sc1[i].Parameters.AddWithValue("@tw", Convert.ToDouble(sideTable.Rows[0].Cells[i].Value));
                    sc1[i].Parameters.AddWithValue("@td", Convert.ToDouble(sideTable.Rows[1].Cells[i].Value));
                    sc1[i].Parameters.AddWithValue("@t", Convert.ToDouble(sideTable.Rows[2].Cells[i].Value));
                    sc1[i].Parameters.AddWithValue("@c", Convert.ToDouble(sideTable.Rows[3].Cells[i].Value));
                    sc1[i].Parameters.AddWithValue("@d", Convert.ToDouble(sideTable.Rows[4].Cells[i].Value));
                    sc1[i].Parameters.AddWithValue("@ap", Convert.ToDouble(sideTable.Rows[5].Cells[i].Value));

                    sc1[i].ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }

                mode = "add";
            }

            SqlDataAdapter sda2 = new SqlDataAdapter("checkS5Other",conn);
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

            if (dt2.Rows.Count > 0) mode = "update";

            SqlCommand sc2 = new SqlCommand("S5OthersPro",conn);

            try
            {

                sc2.CommandType = CommandType.StoredProcedure;

                sc2.Parameters.AddWithValue("@mode", mode);
                sc2.Parameters.AddWithValue("@Tes_ID", TesId);
                sc2.Parameters.AddWithValue("@TSampleN", Convert.ToDouble(topTable.Rows[0].Cells[1].Value));
                sc2.Parameters.AddWithValue("@massS", Convert.ToDouble(topTable.Rows[0].Cells[3].Value));
                sc2.Parameters.AddWithValue("@perS", Convert.ToDouble(topTable.Rows[0].Cells[5].Value));
                sc2.Parameters.AddWithValue("@avgg", Convert.ToDouble(avg.Text));

                sc2.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            conn.Close();
        }

        public void getTableData(int TesId)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            SqlDataAdapter[] sda = new SqlDataAdapter[5];
            DataTable[] dt = new DataTable[5];

            for (int i = 0; i < 5; i++)
            {
                sda[i] = new SqlDataAdapter("checkS5", conn);
                dt[i] = new DataTable();

                try
                {
                    sda[i].SelectCommand.CommandType = CommandType.StoredProcedure;

                    sda[i].SelectCommand.Parameters.AddWithValue("@select", 1);
                    sda[i].SelectCommand.Parameters.AddWithValue("@Tes_Id", TesId);
                    sda[i].SelectCommand.Parameters.AddWithValue("@position", i + 1);

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
                        secondTable.Rows[0].Cells[i + 1].Value = Convert.ToDouble(row["p"]);
                        secondTable.Rows[1].Cells[i + 1].Value = Convert.ToDouble(row["pxa_perm"]);

                        DataGridViewCell cell = (cBoxTable.Rows[0].Cells[i] as DataGridViewCell);

                        cell.Value = row["modN"].ToString().Trim();
                        secTable2.Rows[0].Cells[i + 1].Value = Convert.ToDouble(row["v"]);
                        secTable2.Rows[1].Cells[i + 1].Value = row["hamN"].ToString().Trim();
                        secTable2.Rows[2].Cells[i + 1].Value = Convert.ToDouble(row["mw"]);
                        secTable2.Rows[3].Cells[i + 1].Value = Convert.ToDouble(row["mld"]);
                        secTable2.Rows[4].Cells[i + 1].Value = Convert.ToDouble(row["b"]);

                        DataGridViewCell cell1 = (cBoxTable2.Rows[0].Cells[i] as DataGridViewCell);

                        cell1.Value = row["tinN"].ToString().Trim();
                        secTable3.Rows[0].Cells[i + 1].Value = Convert.ToDouble(row["tw"]);
                        secTable3.Rows[1].Cells[i + 1].Value = Convert.ToDouble(row["td"]);
                        secTable3.Rows[2].Cells[i + 1].Value = Convert.ToDouble(row["t"]);
                        secTable3.Rows[3].Cells[i + 1].Value = Convert.ToDouble(row["c"]);
                        secTable3.Rows[4].Cells[i + 1].Value = Convert.ToDouble(row["d"]);
                        secTable3.Rows[5].Cells[i + 1].Value = Convert.ToDouble(row["ap"]);
                        secTable3.Rows[6].Cells[i + 1].Value = Convert.ToDouble(row["hm"]);
                        secTable3.Rows[7].Cells[i + 1].Value = Convert.ToDouble(row["hv"]);
                        secTable3.Rows[8].Cells[i + 1].Value = Convert.ToDouble(row["hc"]);
                        secTable3.Rows[9].Cells[i + 1].Value = Convert.ToDouble(row["tc"]);
                        secTable3.Rows[10].Cells[i + 1].Value = Convert.ToDouble(row["wd"]);
                        secTable3.Rows[11].Cells[i + 1].Value = Convert.ToDouble(row["dd"]);

                    }
                }
            }

            SqlDataAdapter[] sda1 = new SqlDataAdapter[2];
            DataTable[] dt1 = new DataTable[2];

            for (int i = 0; i < 2; i++)
            {
                sda1[i] = new SqlDataAdapter("checkS5", conn);
                dt1[i] = new DataTable();

                try
                {
                    sda1[i].SelectCommand.CommandType = CommandType.StoredProcedure;

                    sda1[i].SelectCommand.Parameters.AddWithValue("@select",2);
                    sda1[i].SelectCommand.Parameters.AddWithValue("@Tes_Id", TesId);
                    sda1[i].SelectCommand.Parameters.AddWithValue("@position", i + 1);

                    sda1[i].Fill(dt1[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if (dt1[i].Rows.Count > 0)
                {
                    foreach (DataRow row in dt1[i].Rows)
                    {
                        DataGridViewCell cell = (sideBoxTable.Rows[0].Cells[i] as DataGridViewCell);

                        cell.Value = row["tinN"].ToString().Trim();
                        sideTable.Rows[0].Cells[i].Value = Convert.ToDouble(row["tw"]);
                        sideTable.Rows[1].Cells[i].Value = Convert.ToDouble(row["td"]);
                        sideTable.Rows[2].Cells[i].Value = Convert.ToDouble(row["t"]);
                        sideTable.Rows[3].Cells[i].Value = Convert.ToDouble(row["c"]);
                        sideTable.Rows[4].Cells[i].Value = Convert.ToDouble(row["d"]);
                        sideTable.Rows[5].Cells[i].Value = Convert.ToDouble(row["ap"]);
                    }
                }
            }

            SqlDataAdapter sda2 = new SqlDataAdapter("checkS5Other", conn);
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
                    topTable.Rows[0].Cells[1].Value = Convert.ToDouble(row["TSampleN"]);
                    topTable.Rows[0].Cells[3].Value = Convert.ToDouble(row["massS"]);
                    topTable.Rows[0].Cells[5].Value = Convert.ToDouble(row["perS"]);
                    avg.Text = row["avgg"].ToString().Trim();
                    avg2.Text = "Av= " + row["avgg"].ToString().Trim();
                }
            }

                conn.Close();
        }
    }

}
