using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption_testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string Hash;
        string pText;
        string cipherResult = "";
        string selectedFileName;
        private void btnEnc_Click(object sender, EventArgs e)
        {
            Hash = lblHash.Text;
            pText = lblPt.Text;

            int num;
            int icHash = 0;

            for (int i = 0; i < (pText.Length); i++)
            {
                num = Convert.ToInt32(pText[i]) + Convert.ToInt32(Hash[icHash]);

                cipherResult = cipherResult + Convert.ToChar(num);

                //range would be set to however large the hash is
                if (icHash >= Hash.Length)
                {
                    icHash = 0;
                }
                else
                {
                    icHash += 1;
                }
            }

            rtbOut.Text = cipherResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            int icHash = 0;
            string res = "";
            for (int i = 0; i < (cipherResult.Length); i++)
            {
                num = Convert.ToInt32(cipherResult[i]) - Convert.ToInt32(Hash[icHash]);

                res = res + Convert.ToChar(num);

                if (icHash >= Hash.Length)
                {
                    icHash = 0;
                }
                else
                {
                    icHash += 1;
                }
            }

            rtbOutDe.Text = res;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "e:\\";
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFileName = openFileDialog1.FileName;
                lblFileName.Text = selectedFileName;
            }


        }
    }
}
