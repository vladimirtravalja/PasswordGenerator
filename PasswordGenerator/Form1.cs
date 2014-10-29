using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Initialize object of Random class
        Random rand = new Random();

        //initialize variables
        int[] special;
        int[] numeric;
        int[] alpha;
        int[] alp1;
        int[] alp2;
        int[] spec1;
        int[] spec2;
        int[] spec3;
        int[] spec4;
        int[] all;
        string pass = "";
        int[] defSpec = { 0 };
        int[] defAlp = { 0 };
        int[] defNum = { 0 };
        int multip = 1;

        #region Button generate event
        private void button1_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked) || (checkBox2.Checked) || (checkBox3.Checked))
            {
                if (checkBox2.Checked)
                {
                    //define numeric character array range 
                    numeric = Enumerable.Range(48, 57-48+1).ToArray();
                }
                else
                {
                    numeric = defNum;
                }

                if (checkBox1.Checked)
                {
                    //define alpabeth character array range
                    alp1 = Enumerable.Range(65, 90 - 65 + 1).ToArray();
                    alp2 = Enumerable.Range(97, 122 - 97 + 1).ToArray();
                    alpha = alp1.Concat(alp2).ToArray();
                }
                else
                {
                    alpha = defAlp;
                }

                if (checkBox3.Checked)
                {
                    //define special character array range
                    spec1 = Enumerable.Range(33, 47 - 33 + 1).ToArray();
                    spec2 = Enumerable.Range(58, 64 - 58 + 1).ToArray();
                    spec3 = Enumerable.Range(91, 96 - 91 + 1).ToArray();
                    spec4 = Enumerable.Range(123, 126 - 123 + 1).ToArray();
                    special = spec1.Concat(spec2).Concat(spec3).Concat(spec4).ToArray();
                }
                else 
                { 
                    special = defSpec;
                }
                    //concat arrays
                    all = alpha.Concat(numeric).Concat(special).Distinct().ToArray();
                    //remove arrays with 0 values
                    all = all.Except(new int[] { 0 }).ToArray();

                    //call getRandom number method
                    getPass(all);
                    //reset array to null
                    all = null;
            }
            else
                MessageBox.Show("One of ASCII codes must be selected...!");
                    return;
        }

        #endregion
        #region check for generating multiple passwds 
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                numericUpDown2.Visible = true;
                multip = Convert.ToInt32(numericUpDown2.Value);
            }
            else
            {
                numericUpDown2.Visible = false;
            }
        }
        #endregion
        #region generate passwords method using random number from array
        public void getPass(int[] inp)
        {
            if (multip == 1)
            {
                textBox1.Text = "";
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    int val = all[rand.Next(all.Length)];
                    pass += (char)val;
                }

                textBox1.Text = pass;
                pass = "";
            }
            else
            {
                textBox1.Text = "";
                for (int i = 0; i < numericUpDown2.Value; i++)
                {
                    for (int j = 0; j < numericUpDown1.Value; j++)
                    {
                        int val = all[rand.Next(all.Length)];
                        pass += (char)val;
                    }
                    textBox1.Text += pass + "\r\n";
                    pass = "";
                }
            }
        }
        #endregion


        private void getInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show(this);
        }
    }
}
