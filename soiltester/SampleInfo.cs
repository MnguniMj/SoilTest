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
    public partial class SampleInfo : Form
    {
        static Form1 fst = new Form1();
        newProject np;
        viewProject vp;

        int user = 0;
        int pID = 0;
        int chc = 0; //choice...

        public SampleInfo(newProject np1,int user1,int proID)
        {
            InitializeComponent();
            user = user1;
            np = np1;
            pID = proID;
        }

        public SampleInfo(viewProject vp1, int user1, int proID, int choice)
        {
            InitializeComponent();
            user = user1;
            vp = vp1;
            pID = proID;
            chc = choice;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void create_Click(object sender, EventArgs e)
        {
            bool proceed = false;

            if (chc == 0)
            {
                if (name.Text == "" || number.Text == "")
                {
                    MessageBox.Show("Some field are not filled, please try again");
                }
                else
                {
                    try
                    {
                        np.setSample(Convert.ToInt32(number.Text));

                        np.newSample(name.Text, Convert.ToInt32(number.Text));

                        proceed = true;
                        number.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("You entered an invalid number, please try again \n\n" + ex);
                    }
                }
            }
            else
            {
                if (name.Text == "" || number.Text == "")
                {
                    MessageBox.Show("Some field are not filled, please try again");
                }
                else
                {
                    try
                    {
                        vp.setSample(Convert.ToInt32(number.Text));

                        vp.newSample(name.Text, Convert.ToInt32(number.Text));

                        proceed = true;
                        number.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: \n\n" + ex);
                    }

                }

             }

            if (proceed) 
            {
                this.Close();
            }
        }
    }
}
