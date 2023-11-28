using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace soiltester
{
    public partial class TestPage : UserControl
    {
        private double md = 0;
        private double md1 = 0;
        private double md2 = 0;

        private double[] mret = new double[10];

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\soiltester\soiltester\soilDB.mdf;Integrated Security=True");
        
        public TestPage()
        {
            InitializeComponent();

            rfbox.Rows.Add("Mass of oven-dried Sample Md(g)", "", "Mass of sample passing 20mm sieve, Md1(g)", "");

            rfbox.Rows.Add("Reduction Factor, RF = Md2/Md1(g)", "", "Mass of riffled sample, Md2(g)", "");

            rfbox.Rows.Add("Redused Mass test sample, Md*RF Md(g)", "", "", "");

            rfbox.Rows[1].Cells[1].ReadOnly.Equals(true);

            rfbox.Rows[2].Cells[1].ReadOnly.Equals(true);

            rfbox.Rows[2].Cells[3].ReadOnly.Equals(true);

            secondtable.Rows.Add("75.0", "", "", "", "");
            secondtable.Rows.Add("63.0", "", "", "", "");
            secondtable.Rows.Add("50.0", "", "", "", "");
            secondtable.Rows.Add("37.5", "", "", "", "");
            secondtable.Rows.Add("28.0", "", "", "", "");
            secondtable.Rows.Add("20.0", "", "", "", "");
            secondtable.Rows.Add("14.0", "", "", "", "");
            secondtable.Rows.Add("5.0", "", "", "", "");
            secondtable.Rows.Add("2.0", "", "", "", "");
            secondtable.Rows.Add("0.425", "", "", "", "");
            secondtable.Rows.Add("0.075", "", "", "", "");

            sideTable.Rows.Add("Mass passing 0.425 mm Sieve (g)", "");
            sideTable.Rows.Add("Total mass passing 0.425 mm sieve, Md3  =  Mass in PAN + fines obtained by dry sieving and wasshing", "");
            sideTable.Rows.Add("Mass of reduced sample, Md9 = reduced mass on 75 mm sieve to 20 mm sieve + mass retained on 14 mm seive to 0.425 mm sieve + mass passing 0.425 mm sieve ", "");

            sideTable2.Rows.Add("Difference = (( Md-Md9)/Md9))*100", "", "");

            sideTable3.Rows.Add("Mass of fines used to determine 0.075 mm fraction, Md4A (g)", "");
            sideTable3.Rows.Add("Mass retained on 0.075 mm sieve, Md5 (g)", "");

            bottomTable.Rows.Add("Grading Modulus, GM = [300-(Pp(2mm)+Pp(425µm)+Pp(75µm)]/100", "");

            bottomTable2.Rows.Add("Md6 = Mass of fraction retained on 0.250 mm  (g)", "", "","");
            bottomTable2.Rows.Add("Md7 = Mass of fraction retained on 0.150 mm  (g)", "", "","");
            bottomTable2.Rows.Add("Md8 = Mass of fraction retained on 0.075 mm  (g)", "", "","");

            bottomTable3.Rows.Add("2,00 - 0,425", "Coarse Sand (SC)", "[(Pp(2mm)-Pp(425µm))/Pp(2mm)]*100", "");

            bottomTable3.Rows.Add("0,425 - 0,250", "Coarse Fine Sand (SFC)", "[(Pp(425µm)-Pp(250µm))/Pp(2mm)]*100", "");

            bottomTable3.Rows.Add("0,250 - 0,150", "Medium Fine Sand (SFM)", "[(Pp(250µm)-Pp(150µm))/Pp(2mm)]*100", "");

            bottomTable3.Rows.Add("0,150 - 0,075", "Fine Fine Sand (SFF)", "[(Pp(150µm)-Pp(75µm))/Pp(2mm)]*100", "");

            bottomTable3.Rows.Add("< 0,075", "Silt and Clay (SS)", "[Pp(75µm)/Pp(2mm)]*100", "");

        }

        private void TestPage_Load(object sender, EventArgs e)
        {

        }

        public bool fieldUpdate()
        {
            S1Fomulas cal = new S1Fomulas();

            try
            {
                md = Convert.ToDouble(rfbox.Rows[0].Cells[1].Value.ToString());
                md1 = Convert.ToDouble(rfbox.Rows[0].Cells[3].Value.ToString());
                md2 = Convert.ToDouble(rfbox.Rows[1].Cells[3].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Values entered in mass must be a number (Make sure you pressed enter after inputing a value)");
               
                return false;
            }

            cal.setMdtoMd2(md,md1,md2);

            
            double RF = cal.RF();

            rfbox.Rows[1].Cells[1].Value = Math.Round( RF , 9);

            for (int i = 0; i < 6; i++)
            {
                secondtable.Rows[i].Cells[2].Value = Math.Round( RF, 8);
            }

            double RedM = cal.redMassTest();

            rfbox.Rows[2].Cells[1].Value = Math.Round( RedM, 1);

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    mret[i] = Convert.ToDouble(secondtable.Rows[i].Cells[1].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Values entered in field " + i + " must be a number (Make sure you pressed enter after inputing a value)");

                    return false;
                }
            }

            cal.setMassRet(mret);

            double[] redM = new double[11];
            double[] perR = new double[11];
            double[] perP = new double[11];

            redM = cal.redMass(redM);

            redM[10] = 0.0;

            for (int i = 0; i < 11; i++)
            {
                secondtable.Rows[i].Cells[3].Value = Math.Round( redM[i], 1);
            }

            double md3 = 0;
            double mpass = 0;

            try
            {
                mpass = Convert.ToDouble(sideTable.Rows[0].Cells[1].Value.ToString());
                md3 = Convert.ToDouble(sideTable.Rows[1].Cells[1].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Values entered in Mass Passing or Md3 must be a number (Make sure you pressed enter after inputing a value)");

                return false;
            }

            cal.setsideTable(mpass, md3);

            double md9 = cal.md9Cal(redM);

            sideTable.Rows[2].Cells[1].Value = Math.Round(md9,1);

            perR = cal.perRet(redM,perR);

            for (int i = 0; i < 11; i++)
            {
                secondtable.Rows[i].Cells[4].Value = Math.Round( perR[i],1);
            }

            perP = cal.perPas(perR, perP);

            for (int i = 0; i < 11; i++)
            {
                secondtable.Rows[i].Cells[5].Value = Math.Round(perP[i],1);
            }

            double dif = 0;

            dif = cal.Diff();

            sideTable2.Rows[0].Cells[1].Value = Math.Round(dif,1);

            double md4a = 0;
            double md5 = 0;

            try
            {
                md4a = Convert.ToDouble(sideTable3.Rows[0].Cells[1].Value.ToString());
                md5 = Convert.ToDouble(sideTable3.Rows[1].Cells[1].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Values entered in Md4A or Md5 must be a number (Make sure you pressed enter after inputing a value)");

                return false;
            }

            cal.setMd4to5(md4a, md5);

            perR[10] = cal.corrPret(perR, perP);

            perP[10] = perP[9] - perR[10];

            double gm = cal.GM(perP);

            secondtable.Rows[10].Cells[4].Value = Math.Round(perR[10],1);

            secondtable.Rows[10].Cells[5].Value = Math.Round(perP[10],1);

            bottomTable.Rows[0].Cells[1].Value = Math.Round(gm,1);

            double md6 = 0;
            double md7 = 0;
            double md8 = 0;
            
            try
            {
                md6 = Convert.ToDouble(bottomTable2.Rows[0].Cells[1].Value.ToString());
                md7 = Convert.ToDouble(bottomTable2.Rows[1].Cells[1].Value.ToString());
                md8 = Convert.ToDouble(bottomTable2.Rows[2].Cells[1].Value.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: Values entered in Md6 or Md7 or Md8 must be a number (Make sure you pressed enter after inputing a value)" + e);

                return false;
            }



            cal.setMd6to8(md6,md7,md8);

            double[] ppp = new double[3];

            double[] prp = new double[3];

            prp = cal.prper(prp, perP[9]);

            ppp = cal.ppper(ppp, prp, perP[9]);

            for (int i = 0; i < 3; i++)
            {
                bottomTable2.Rows[i].Cells[2].Value = Math.Round(prp[i],1);
                bottomTable2.Rows[i].Cells[3].Value = Math.Round(ppp[i],1);
            }

            double[] sM = new double[6];

            sM = cal.soilM(sM, perP, ppp);

            for (int i = 0; i < 5; i++)
            {
                bottomTable3.Rows[i].Cells[3].Value = Math.Round(sM[i],1);
            }

            return true;

        }

        public void refreshTables()
        {
            for (int i = 1; i < 4; i+=2)
            {
                for(int j = 0; j < 3; j++)
                {
                    rfbox.Rows[j].Cells[i].Value = "";
                }
            }

            //second table

            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    secondtable.Rows[j].Cells[i].Value = "";
                }
            }

            //side table

            for (int i = 0; i < 3; i++)
            {
                sideTable.Rows[i].Cells[1].Value = "";
            }

            //side table 2

            sideTable2.Rows[0].Cells[1].Value = "";

            //side table 3

            for (int i = 0; i < 2; i++)
            {
                sideTable3.Rows[i].Cells[1].Value = "";
            }

            //bottom table

            bottomTable.Rows[0].Cells[1].Value = "";

            //bottom table 2

            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bottomTable2.Rows[j].Cells[i].Value = "";
                }
            }

            //bottom table 2

            for (int i = 0; i < 5; i++)
            {
                bottomTable3.Rows[i].Cells[3].Value = "";
            }
        }


        // gridTable returns.....................................................

        public string getRfbox(int r, int c)
        {
            return rfbox.Rows[r].Cells[c].Value.ToString();
        }

        public string getSec(int r, int c)
        {
            return secondtable.Rows[r].Cells[c].Value.ToString();
        }

        public string getSide(int r)
        {
            return sideTable.Rows[r].Cells[1].Value.ToString();
        }

        public string getSide1()
        {
            return sideTable2.Rows[0].Cells[1].Value.ToString();
        }

        public string getSide2(int r)
        {
            return sideTable3.Rows[r].Cells[1].Value.ToString();
        }

        public string getBott()
        {
            return bottomTable.Rows[0].Cells[1].Value.ToString();
        }

        public string getBott1(int r, int c)
        {
            return bottomTable2.Rows[r].Cells[c].Value.ToString();
        }

        public string getBott2(int r)
        {
            return bottomTable3.Rows[r].Cells[1].Value.ToString();
        }

        // end of gridTable returns................................................

        public void copyFrom(TestPage tp)
        {
            for (int i = 1; i < 4; i += 2)
            {
                for (int j = 0; j < 3; j++)
                {
                    rfbox.Rows[j].Cells[i].Value = tp.getRfbox(j,i);

                }
            }

            //second table

            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    secondtable.Rows[j].Cells[i].Value = tp.getSec(j,i);
                }
            }

            //side table

            for (int i = 0; i < 3; i++)
            {
                sideTable.Rows[i].Cells[1].Value = tp.getSide(i);
            }

            //side table 2

            sideTable2.Rows[0].Cells[1].Value = tp.getSide1();

            //side table 3

            for (int i = 0; i < 2; i++)
            {
                sideTable3.Rows[i].Cells[1].Value = tp.getSide2(i);
            }

            //bottom table

            bottomTable.Rows[0].Cells[1].Value = tp.getBott();

            //bottom table 2

            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bottomTable2.Rows[j].Cells[i].Value = tp.getBott1(j,i);
                }
            }

            //bottom table 3

            for (int i = 0; i < 5; i++)
            {
                bottomTable3.Rows[i].Cells[3].Value = tp.getBott2(i);
            }
        }

        public void setGrid(TestPage pg,int i)
        {

            switch (i)
            {
                case 1:
                    rfbox = pg.giveGrid("first");
                    break;

                case 2:
                    secondtable = pg.giveGrid("second");
                    break;

                case 3:
                    sideTable = pg.giveGrid("side");
                    break;

                case 4:
                    sideTable2 = pg.giveGrid("side2");
                    break;

                case 5:
                    sideTable3 = pg.giveGrid("side3");
                    break;

                case 6:
                    bottomTable = pg.giveGrid("bottom");
                    break;

                case 7:
                    bottomTable2 = pg.giveGrid("bottom1");
                    break;
                    
                case 8:
                    bottomTable3 = pg.giveGrid("bottom2");
                    break;
            }

        }

        public DataGridView giveGrid(string i)
        {
            DataGridView dgw = new DataGridView();

            switch (i)
            {
                case "first":
                    return rfbox;

                case "second":
                    return secondtable;

                case "side":
                    return sideTable;

                case "side2":
                    return sideTable2;

                case "side3":
                    return sideTable3;

                case "bottom":
                    return bottomTable;

                case "bottom1":
                    return bottomTable2;

                case "bottom2":
                    return bottomTable3;
            }

            return dgw;
        }

        public void saveTableData(int testId)
        {
            string mode = "add";

            if (conn.State == ConnectionState.Closed) conn.Open();



            SqlCommand[] comm = new SqlCommand[5];

            for (int i = 0; i < 5; i++) comm[i] = new SqlCommand("test1Table2Pro", conn);

            for (int i = 0; i < 5; i++) scTable(ref comm[i], (i+1), i, testId);


            SqlDataAdapter[] osda = new SqlDataAdapter[3];
            DataTable[] odt = new DataTable[3];

            for (int i = 0; i < 3; i++)
            {
                osda[i] = new SqlDataAdapter("getTest1D",conn);
                odt[i] = new DataTable();

                try
                {
                    osda[i].SelectCommand.CommandType = CommandType.StoredProcedure;
                    osda[i].SelectCommand.Parameters.AddWithValue("@mode",i+5);
                    osda[i].SelectCommand.Parameters.AddWithValue("@Tes_Id", testId);

                    osda[i].Fill(odt[i]);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }
            }

            if (odt[0].Rows.Count > 0) mode = "update";

            SqlCommand comm2 = new SqlCommand("test1Others", conn);

            try
            {
                comm2.CommandType = CommandType.StoredProcedure;
                comm2.Parameters.AddWithValue("@mode", mode);
                comm2.Parameters.AddWithValue("@Tes_ID", testId);
                comm2.Parameters.AddWithValue("@oven_dried", Convert.ToDouble(rfbox.Rows[0].Cells[1].Value));
                comm2.Parameters.AddWithValue("@rf", Convert.ToDouble(rfbox.Rows[1].Cells[1].Value));
                comm2.Parameters.AddWithValue("@md_rf", Convert.ToDouble(rfbox.Rows[2].Cells[1].Value));
                comm2.Parameters.AddWithValue("@sPassing", Convert.ToDouble(rfbox.Rows[0].Cells[3].Value));
                comm2.Parameters.AddWithValue("@riffled", Convert.ToDouble(rfbox.Rows[1].Cells[3].Value));
                comm2.Parameters.AddWithValue("@mPassing", Convert.ToDouble(sideTable.Rows[0].Cells[1].Value));
                comm2.Parameters.AddWithValue("@totalmpassing", Convert.ToDouble(sideTable.Rows[1].Cells[1].Value));
                comm2.Parameters.AddWithValue("@redSam", Convert.ToDouble(sideTable.Rows[2].Cells[1].Value));
                comm2.Parameters.AddWithValue("@diff", Convert.ToDouble(sideTable2.Rows[0].Cells[1].Value));
                comm2.Parameters.AddWithValue("@finesused", Convert.ToDouble(sideTable3.Rows[0].Cells[1].Value));
                comm2.Parameters.AddWithValue("@massR", Convert.ToDouble(sideTable3.Rows[1].Cells[1].Value));
                comm2.Parameters.AddWithValue("@grading", Convert.ToDouble(bottomTable.Rows[0].Cells[1].Value));

                comm2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex);
            }

            mode = "add";

            if (odt[1].Rows.Count > 0) mode = "update";

            SqlCommand comm3 = new SqlCommand("SoilMPro", conn);

            try
            {
                comm3.CommandType = CommandType.StoredProcedure;
                comm3.Parameters.AddWithValue("@mode", mode);
                comm3.Parameters.AddWithValue("@Tes_Id", testId);
                comm3.Parameters.AddWithValue("@md6", Convert.ToDouble(bottomTable2.Rows[0].Cells[1].Value));
                comm3.Parameters.AddWithValue("@md7", Convert.ToDouble(bottomTable2.Rows[1].Cells[1].Value));
                comm3.Parameters.AddWithValue("@md8", Convert.ToDouble(bottomTable2.Rows[2].Cells[1].Value));

                comm3.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex);
            }

            SqlDataAdapter sda = new SqlDataAdapter("getSoilM",conn);
            DataTable dt = new DataTable();

            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Tes_Id",testId);

                sda.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex);

            }

            int tblId = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows) tblId = Convert.ToInt32(row["Soi_Id"]);
            }

            if (tblId != 0)
            {
                SqlCommand comm4 = new SqlCommand("PrPpPro", conn);

                SqlDataAdapter[] psda = new SqlDataAdapter[2];
                DataTable[] pdt = new DataTable[2];

                for (int i = 0; i < 2;i++)
                {
                    psda[i] = new SqlDataAdapter("test1PsD", conn);
                    pdt[i] = new DataTable();

                    try
                    {
                        psda[i].SelectCommand.CommandType = CommandType.StoredProcedure;
                        psda[i].SelectCommand.Parameters.AddWithValue("@mode", i );
                        psda[i].SelectCommand.Parameters.AddWithValue("@Soi_Id", tblId);

                        psda[i].Fill(pdt[i]);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error \n\n" + ex);
                    }

                }
                mode = "add";
                if (pdt[0].Rows.Count > 0) mode = "update";

                try
                {

                    comm4.CommandType = CommandType.StoredProcedure;
                    comm4.Parameters.AddWithValue("@mode", mode);
                    comm4.Parameters.AddWithValue("@Soi_Id", tblId);
                    comm4.Parameters.AddWithValue("@pr1", Convert.ToDouble(bottomTable2.Rows[0].Cells[2].Value));
                    comm4.Parameters.AddWithValue("@pr2", Convert.ToDouble(bottomTable2.Rows[1].Cells[2].Value));
                    comm4.Parameters.AddWithValue("@pr3", Convert.ToDouble(bottomTable2.Rows[2].Cells[2].Value));
                    comm4.Parameters.AddWithValue("@pp1", Convert.ToDouble(bottomTable2.Rows[0].Cells[3].Value));
                    comm4.Parameters.AddWithValue("@pp2", Convert.ToDouble(bottomTable2.Rows[1].Cells[3].Value));
                    comm4.Parameters.AddWithValue("@pp3", Convert.ToDouble(bottomTable2.Rows[2].Cells[3].Value));

                    comm4.ExecuteNonQuery();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }

            }

            mode = "add";

            if (odt[2].Rows.Count > 0) mode = "update";

            SqlCommand comm5 = new SqlCommand("PSoil_M", conn);

            try
            {
                comm5.CommandType = CommandType.StoredProcedure;
                comm5.Parameters.AddWithValue("@mode", mode);
                comm5.Parameters.AddWithValue("@Tes_Id", testId);
                comm5.Parameters.AddWithValue("@sc", Convert.ToDouble(bottomTable3.Rows[0].Cells[3].Value));
                comm5.Parameters.AddWithValue("@sfc", Convert.ToDouble(bottomTable3.Rows[1].Cells[3].Value));
                comm5.Parameters.AddWithValue("@sfm", Convert.ToDouble(bottomTable3.Rows[2].Cells[3].Value));
                comm5.Parameters.AddWithValue("@sff", Convert.ToDouble(bottomTable3.Rows[3].Cells[3].Value));
                comm5.Parameters.AddWithValue("@ss", Convert.ToDouble(bottomTable3.Rows[4].Cells[3].Value));

                comm5.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n\n" + ex);
            }

            conn.Close();
        }

        public void getTableData(int testId)
        {

            if (conn.State == ConnectionState.Closed) conn.Open();
                
            SqlDataAdapter[] sda = new SqlDataAdapter[8];
            DataTable[] dt = new DataTable[8];

            for (int i = 0; i < 8; i++)
            {
                sda[i] = new SqlDataAdapter("getTest1D", conn);
                dt[i] = new DataTable();
                try
                {
                    sda[i].SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda[i].SelectCommand.Parameters.AddWithValue("@mode", i);
                    sda[i].SelectCommand.Parameters.AddWithValue("@Tes_Id", testId);

                    sda[i].Fill(dt[i]);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }

            }

            //secondTable data

            if (dt[0].Rows.Count > 0)
            {
                foreach (DataRow row in dt[0].Rows)
                {
                    secondtable.Rows[0].Cells[1].Value = row["MassR1"].ToString().Trim();
                    secondtable.Rows[1].Cells[1].Value = row["MassR2"].ToString().Trim();
                    secondtable.Rows[2].Cells[1].Value = row["MassR3"].ToString().Trim();
                    secondtable.Rows[3].Cells[1].Value = row["MassR4"].ToString().Trim();
                    secondtable.Rows[4].Cells[1].Value = row["MassR5"].ToString().Trim();
                    secondtable.Rows[5].Cells[1].Value = row["MassR6"].ToString().Trim();
                    secondtable.Rows[6].Cells[1].Value = row["MassR7"].ToString().Trim();
                    secondtable.Rows[7].Cells[1].Value = row["MassR8"].ToString().Trim();
                    secondtable.Rows[8].Cells[1].Value = row["MassR9"].ToString().Trim();
                    secondtable.Rows[9].Cells[1].Value = row["MassR10"].ToString().Trim();
                }
            }

            if (dt[1].Rows.Count > 0)
            {
                foreach (DataRow row in dt[1].Rows)
                {
                    secondtable.Rows[0].Cells[2].Value = row["rfunc1"].ToString().Trim();
                    secondtable.Rows[1].Cells[2].Value = row["rfunc2"].ToString().Trim();
                    secondtable.Rows[2].Cells[2].Value = row["rfunc3"].ToString().Trim();
                    secondtable.Rows[3].Cells[2].Value = row["rfunc4"].ToString().Trim();
                    secondtable.Rows[4].Cells[2].Value = row["rfunc5"].ToString().Trim();
                    secondtable.Rows[5].Cells[2].Value = row["rfunc6"].ToString().Trim();
                    secondtable.Rows[6].Cells[2].Value = 0;
                    secondtable.Rows[7].Cells[2].Value = 0;
                    secondtable.Rows[8].Cells[2].Value = 0;
                    secondtable.Rows[9].Cells[2].Value = 0;
                    secondtable.Rows[10].Cells[2].Value = 0;
                }
            }

            if (dt[2].Rows.Count > 0)
            {
                foreach (DataRow row in dt[2].Rows)
                {
                    secondtable.Rows[0].Cells[3].Value = row["redm1"].ToString().Trim();
                    secondtable.Rows[1].Cells[3].Value = row["redm2"].ToString().Trim();
                    secondtable.Rows[2].Cells[3].Value = row["redm3"].ToString().Trim();
                    secondtable.Rows[3].Cells[3].Value = row["redm4"].ToString().Trim();
                    secondtable.Rows[4].Cells[3].Value = row["redm5"].ToString().Trim();
                    secondtable.Rows[5].Cells[3].Value = row["redm6"].ToString().Trim();
                    secondtable.Rows[6].Cells[3].Value = row["redm7"].ToString().Trim();
                    secondtable.Rows[7].Cells[3].Value = row["redm8"].ToString().Trim();
                    secondtable.Rows[8].Cells[3].Value = row["redm9"].ToString().Trim();
                    secondtable.Rows[9].Cells[3].Value = row["redm10"].ToString().Trim();
                    secondtable.Rows[10].Cells[3].Value = row["redm11"].ToString().Trim();
                }
            }

            if (dt[3].Rows.Count > 0)
            {
                foreach (DataRow row in dt[3].Rows)
                {
                    secondtable.Rows[0].Cells[5].Value = row["Perr1"].ToString().Trim();
                    secondtable.Rows[1].Cells[5].Value = row["Perr2"].ToString().Trim();
                    secondtable.Rows[2].Cells[5].Value = row["Perr3"].ToString().Trim();
                    secondtable.Rows[3].Cells[5].Value = row["Perr4"].ToString().Trim();
                    secondtable.Rows[4].Cells[5].Value = row["Perr5"].ToString().Trim();
                    secondtable.Rows[5].Cells[5].Value = row["Perr6"].ToString().Trim();
                    secondtable.Rows[6].Cells[5].Value = row["Perr7"].ToString().Trim();
                    secondtable.Rows[7].Cells[5].Value = row["Perr8"].ToString().Trim();
                    secondtable.Rows[8].Cells[5].Value = row["Perr9"].ToString().Trim();
                    secondtable.Rows[9].Cells[5].Value = row["Perr10"].ToString().Trim();
                    secondtable.Rows[10].Cells[5].Value = row["Perr11"].ToString().Trim();
                }
            }

            if (dt[4].Rows.Count > 0)
            {
                foreach (DataRow row in dt[4].Rows)
                {
                    secondtable.Rows[0].Cells[4].Value = row["perp1"].ToString().Trim();
                    secondtable.Rows[1].Cells[4].Value = row["perp2"].ToString().Trim();
                    secondtable.Rows[2].Cells[4].Value = row["perp3"].ToString().Trim();
                    secondtable.Rows[3].Cells[4].Value = row["perp4"].ToString().Trim();
                    secondtable.Rows[4].Cells[4].Value = row["perp5"].ToString().Trim();
                    secondtable.Rows[5].Cells[4].Value = row["perp6"].ToString().Trim();
                    secondtable.Rows[6].Cells[4].Value = row["perp7"].ToString().Trim();
                    secondtable.Rows[7].Cells[4].Value = row["perp8"].ToString().Trim();
                    secondtable.Rows[8].Cells[4].Value = row["perp9"].ToString().Trim();
                    secondtable.Rows[9].Cells[4].Value = row["perp10"].ToString().Trim();
                    secondtable.Rows[10].Cells[4].Value = row["perp11"].ToString().Trim();
                }
            }

            //test1 massof data

            if (dt[5].Rows.Count > 0)
            {
                foreach(DataRow row in dt[5].Rows)
                {
                    //first table data
                    rfbox.Rows[0].Cells[1].Value = row["oven_dried"].ToString().Trim();
                    rfbox.Rows[1].Cells[1].Value = row["rf"].ToString().Trim();
                    rfbox.Rows[2].Cells[1].Value = row["md_rf"].ToString().Trim();
                    rfbox.Rows[0].Cells[3].Value = row["sPassing"].ToString().Trim();
                    rfbox.Rows[1].Cells[3].Value = row["riffled"].ToString().Trim();

                    //side Table data
                    sideTable.Rows[0].Cells[1].Value = row["mPassing"].ToString().Trim();
                    sideTable.Rows[1].Cells[1].Value = row["totalmpassing"].ToString().Trim();
                    sideTable.Rows[2].Cells[1].Value = row["redSam"].ToString().Trim();

                    //difference data
                    sideTable2.Rows[0].Cells[1].Value = row["diff"].ToString().Trim();

                    //side Table 3 data
                    sideTable3.Rows[0].Cells[1].Value = row["finesused"].ToString().Trim();
                    sideTable3.Rows[1].Cells[1].Value = row["massR"].ToString().Trim();

                    //grading data
                    bottomTable.Rows[0].Cells[1].Value = row["grading"].ToString().Trim();
                    
                }
            }

            //soil martar data
            int soiId = 0;

            if (dt[6].Rows.Count > 0)
            {
                foreach (DataRow row in dt[6].Rows)
                {
                    bottomTable2.Rows[0].Cells[1].Value = row["md6"].ToString().Trim();
                    bottomTable2.Rows[1].Cells[1].Value = row["md7"].ToString().Trim();
                    bottomTable2.Rows[2].Cells[1].Value = row["md8"].ToString().Trim();
                    soiId = Convert.ToInt32(row["Soi_Id"]);
                }
            }

            //psoil martar data

            if (dt[7].Rows.Count > 0)
            {
                foreach (DataRow row in dt[7].Rows)
                {
                    bottomTable3.Rows[0].Cells[3].Value = row["sc"].ToString().Trim();
                    bottomTable3.Rows[1].Cells[3].Value = row["sfc"].ToString().Trim();
                    bottomTable3.Rows[2].Cells[3].Value = row["sfm"].ToString().Trim();
                    bottomTable3.Rows[3].Cells[3].Value = row["sff"].ToString().Trim();
                    bottomTable3.Rows[4].Cells[3].Value = row["ss"].ToString().Trim();
                }
            }

            SqlDataAdapter[] sqlda = new SqlDataAdapter[2];
            DataTable[] dtbl = new DataTable[4];

            for(int i = 0; i < 2; i++)
            {
                sqlda[i] = new SqlDataAdapter("test1PsD", conn);
                dtbl[i] = new DataTable();

                try
                {
                    sqlda[i].SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlda[i].SelectCommand.Parameters.AddWithValue("@mode", i);
                    sqlda[i].SelectCommand.Parameters.AddWithValue("@Soi_Id", soiId);

                    sqlda[i].Fill(dtbl[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error \n\n" + ex);
                }

            }

            if (dtbl[0].Rows.Count > 0)
            {
                foreach(DataRow row in dtbl[0].Rows)
                {
                    bottomTable2.Rows[0].Cells[2].Value = row["pr1"].ToString().Trim();
                    bottomTable2.Rows[1].Cells[2].Value = row["pr2"].ToString().Trim();
                    bottomTable2.Rows[2].Cells[2].Value = row["pr3"].ToString().Trim();
                }
            }

            if (dtbl[1].Rows.Count > 0)
            {
                foreach (DataRow row in dtbl[1].Rows)
                {
                    bottomTable2.Rows[0].Cells[3].Value = row["pp1"].ToString().Trim();
                    bottomTable2.Rows[1].Cells[3].Value = row["pp2"].ToString().Trim();
                    bottomTable2.Rows[2].Cells[3].Value = row["pp3"].ToString().Trim();
                }
            }


        }

        public void scTable(ref SqlCommand comm, int c, int mode,int tst)
        {
            SqlDataAdapter sda = new SqlDataAdapter("getTest1D",conn);
            DataTable dt = new DataTable();

            string sel = "add";

            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@mode", mode);
                sda.SelectCommand.Parameters.AddWithValue("@Tes_Id", tst);

                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error \n\n" + ex);
            }

            if (dt.Rows.Count > 0) sel = "update"; 


            try
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@select", sel);
                comm.Parameters.AddWithValue("@mode",mode);
                comm.Parameters.AddWithValue("@test", tst);  
                comm.Parameters.AddWithValue("@dt1", Convert.ToDouble(secondtable.Rows[0].Cells[c].Value));
                comm.Parameters.AddWithValue("@dt2", Convert.ToDouble(secondtable.Rows[1].Cells[c].Value));
                comm.Parameters.AddWithValue("@dt3", Convert.ToDouble(secondtable.Rows[2].Cells[c].Value));
                comm.Parameters.AddWithValue("@dt4", Convert.ToDouble(secondtable.Rows[3].Cells[c].Value));
                comm.Parameters.AddWithValue("@dt5", Convert.ToDouble(secondtable.Rows[4].Cells[c].Value));
                comm.Parameters.AddWithValue("@dt6", Convert.ToDouble(secondtable.Rows[5].Cells[c].Value));
                if (c != 2) comm.Parameters.AddWithValue("@dt7", Convert.ToDouble(secondtable.Rows[6].Cells[c].Value));
                else comm.Parameters.AddWithValue("@dt7", 0);
                if (c != 2) comm.Parameters.AddWithValue("@dt8", Convert.ToDouble(secondtable.Rows[7].Cells[c].Value));
                else comm.Parameters.AddWithValue("@dt8", 0);
                if (c != 2) comm.Parameters.AddWithValue("@dt9", Convert.ToDouble(secondtable.Rows[8].Cells[c].Value));
                else comm.Parameters.AddWithValue("@dt9", 0);
                if (c != 2) comm.Parameters.AddWithValue("@dt10", Convert.ToDouble(secondtable.Rows[9].Cells[c].Value));
                else comm.Parameters.AddWithValue("@dt10", 0);

                if (c > 1)
                {
                    if (c != 2) comm.Parameters.AddWithValue("@dt11", Convert.ToDouble(secondtable.Rows[10].Cells[c].Value));
                    else comm.Parameters.AddWithValue("@dt11", 0);
                }
                comm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at " + (c) + "\n\n" + ex);
            }
        }

        private void secondtable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sideTable2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sideTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sideTable3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
