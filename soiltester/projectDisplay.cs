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
    public partial class projectDisplay : UserControl
    {
        int proId = 0;

        public projectDisplay()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void projectDisplay_Load(object sender, EventArgs e)
        {

        }

        public void setValues(int id, string proname,string cliname,string desc)
        {
            proId = id;
            lblProName.Text = proname;
            lblCliName.Text = cliname;
            lblDesc.Text = desc;
        }

        public int returnID()
        {
            return proId;
        }

        public string returnValue(int vl)
        {
            switch (vl)
            {
                case 1:
                    return lblProName.Text;
                case 2:
                    return lblCliName.Text;
                default:
                    return lblDesc.Text;  

            }
        }
    }
}
