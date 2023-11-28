using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soiltester
{
    internal class S1Fomulas
    {
        //first table
        private double md = 0.0;
        private double md1 = 0.0;
        private double md2 = 0.0;

        //side table 1
        private double mPass = 0.0;
        private double md3 = 0.0;

        //side table 2
        private double md4A = 0.0;
        private double md5 = 0.0;

        //second table
        private double[] MassRet = new double[10];

        //bottom table
        private double md6 = 0.0;
        private double md7 = 0.0;
        private double md8 = 0.0;

        private double md9 = 0.0;


        //first table functions
        public double RF()
        {
            double rf = 0;
            try
            {
                rf = md2 / md1;
            }
            catch(Exception e)
            {
                MessageBox.Show(" " + e);
                return 0;
            }
            return (rf);
        }

        public double redMassTest()
        {
            return (md * RF());
        }

        //sec table functions
        public double[] redMass(double[] redm)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i < 6) redm[i] = MassRet[i] * RF();
                else redm[i] = MassRet[i];
            }

            return redm;
        }

        //side table 1
        public double md9Cal(double[] redm)
        {
            double sum = 0;

            for (int i = 0; i < 11; i++) sum += redm[i];

            md9 = sum + md3;

            return md9;
        }

        public double Diff()
        {
            double df = 0;

            try
            {
                df = ((md - md9) / md9) * 100;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return df;
        }

        public double[] perRet(double[] redm, double[] pRet)
        {
            for (int i = 0; i < 11; i++) pRet[i] = (redm[i]/md9)*100;

            return pRet;
        }

        public double[] perPas(double[] pRet, double[] pPas)
        {
            pPas[0] = 100 - pRet[0];

            for (int i = 1; i < 11; i++) pPas[i] = pPas[i - 1] - pRet[i];

            return pPas;
        }

        public double corrPret(double[] pRet, double[] pPas)
        {
            pRet[10] = (pPas[9] * md5) / 100;

            return pRet[10];
        }

        public double GM(double[] pPas)
        {
            double sum = 0.0;

            for (int i = 8; i < 11; i++) sum += pPas[i];

            return ((300 - sum) / 100);
            
        }

        //botton table 2 
        public double[] prper(double[] prp,double pPas9)
        {
            prp[0] = (md6 * pPas9) / md4A;

            prp[1] = (md7 * pPas9) / md4A;

            prp[2] = (md8 * pPas9) / md4A;

            return prp;
        }

        public double[] ppper(double[] ppp, double[] prp, double pPas9)
        {
            ppp[0] = pPas9 - prp[0];

            for (int i = 1; i < 3; i++) ppp[i] = ppp[i-1] - prp[i];

            return ppp;
        }

        public double[] soilM(double[] sMortar,double[] pPas,double[] ppp)
        {
            sMortar[0] = ((pPas[8] - pPas[9]) / pPas[8])*100;

            sMortar[1] = ((pPas[9] - ppp[0]) / pPas[8])*100;

            sMortar[2] = ((ppp[0] - ppp[1]) / pPas[8]) * 100;

            sMortar[3] = ((ppp[1] - ppp[2]) / pPas[8]) * 100;

            sMortar[4] = (ppp[2]/ pPas[8]) * 100;

            return sMortar;
        }

        public void setMdtoMd2(double Md, double Md1, double Md2)
        {
            md = Md;
            md1 = Md1;
            md2 = Md2;
        }

        public void setMassRet(double[] MRet)
        {
            MassRet = MRet;
        }

        public void setsideTable(double mp, double Md3)
        {
            mPass = mp;
            md3 = Md3;
        }

        public void setMd4to5(double Md4a,double Md5)
        {
            md4A = Md4a;
            md5 = Md5;
        }

        public void setMd6to8(double Md6, double Md7, double Md8)
        {
            md6 = Md6;
            md7 = Md7;
            md8 = Md8;
        }


    }
}
