using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soiltester
{
    public partial class clientDisplay : UserControl
    {

        string sname = "";
        int id = 0;

        public clientDisplay()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void getDetails(int id1,string n, string no, string sn, string ad)
        {
            id = id1;
            clientName.Text = n;
            clientNo.Text = no;
            sname = sn;
            clientAdd.Text = ad;
        }

        public string returnValus(int vl)
        {
            switch (vl)
            {
                case 1:
                    return clientName.Text;

                case 2:
                    return sname;

                case 3:
                    return clientNo.Text;

                default:
                    return clientAdd.Text;
            }
        }

        public int getId()
        {
            return id;
        }

        private void clientDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}
