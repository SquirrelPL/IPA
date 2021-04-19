using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPA
{
    public partial class IPA : Form
    {
        public string ip;
        public string mask;
        public string subnet;
        public bool vlsm;
        private string temporaryIp, temporaryMaks, temporarySubnet;
        private string[] temporaryIpp, temporaryMakss, temporarySubnett;
        public List<string> list;

        public IPA()
        {
            InitializeComponent();
        }

        public void GetInputs()
        {
            ip = IP.Text;
            mask = Mask.Text;
            subnet = Subnets.Text;
            vlsm = VLSMCheckBox.Checked;
        }


        private void Pass_Click(object sender, EventArgs e)
        {
            GetInputs();
            if (IsIdiotSystem())
            {
                if (VLSMCheckBox.Checked)
                {
                    var Vlsm = new Vlsm(ip, mask, subnet, vlsm);
                    Vlsm.FormClosing += delegate { this.Show(); };
                    Vlsm.Show();
                    this.Hide();
                }
                else
                {
                    Output output = new Output(ip, mask, subnet, vlsm, list);
                    output.Location = this.Location;
                    output.StartPosition = FormStartPosition.Manual;
                    output.FormClosing += delegate { this.Show(); };
                    output.Show();
                    this.Hide();
                }
            }


        }

        public bool IsIdiotSystem()
        {
            int sum = 0;
            if (chceckIP())
                sum += 1;
            else
                IPFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            if (chceckMask())
                sum += 1;
            else
                MaskFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            if (chceckSubnet())
                sum += 1;
            else
                SubnetsFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

            if (sum == 3)
            {
                IPFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
                MaskFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
                SubnetsFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
                return true;
            }
                
            else
                return false;
        }

        public bool chceckIP()
        {
            temporaryIp = ip;

            int dotsIP = 0;
            char lastChar = 'x';
            int octetChceck = 0;
            bool isLetter = false;

            foreach (var comp in temporaryIp)
            {
                if (char.IsLetter(comp))
                    isLetter = true;
                if (comp == '.' && lastChar >= 0 || lastChar <= 9)
                    dotsIP += 1;
                lastChar = comp;
            }
            //////////////////Sprawdzanie ip
            if (dotsIP == 3 && !isLetter)
            {
                temporaryIpp = ip.Split('.');
                for (int i = 0; i < 4; i++)
                    if (Convert.ToInt32(temporaryIpp[i]) >= 0 && Convert.ToInt32(temporaryIpp[i]) <= 255)
                        octetChceck += 1;
                if (octetChceck == 4)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }


        ////////////////////////////////////Sprawdzanie Maski
        public bool chceckMask()
        {
            bool isLetter = false;
            temporaryMaks = mask;
            string temporaryMask = "";
            string[] octets;

            if (mask.Length == 1 || mask.Length == 2 || mask.Length == 3)
            {
                foreach (var comp in temporaryMaks)
                {
                    if (comp == '/')
                        temporaryMaks = temporaryMaks.Remove(0,1);
                    isLetter = char.IsLetter(comp);
                }

                if (Convert.ToInt32(temporaryMaks) > 32 || Convert.ToInt32(temporaryMaks) < 1)
                    return false;
                for(int i = 0; i<Convert.ToInt32(temporaryMaks); i++)
                    temporaryMask += "1";
                for(int i = 0; i<32-Convert.ToInt32(temporaryMaks); i++)
                    temporaryMask += "0";

                temporaryMask = Regex.Replace(temporaryMask, ".{8}", "$0.");
                temporaryMask = temporaryMask.Remove(35,1);
                octets = temporaryMask.Split('.');
                for (int i = 0; i < 4; i++)
                    octets[i] = Convert.ToInt32(octets[i], 2).ToString();
                mask = octets[0] + "." + octets[1] + "." + octets[2] + "." + octets[3];
                temporaryMaks = mask;
            }
            int dotsMask = 0;
            char lastChar = 'x';
            int octetChceck = 0;
            isLetter = false;

            foreach (var comp in temporaryMaks)
            {
                if (char.IsLetter(comp))
                    isLetter = true;
                if (comp == '.' && lastChar >= 0 || lastChar <= 9)
                    dotsMask += 1;
                lastChar = comp;
            }
            //////////////////Sprawdzanie Maski
            if (dotsMask == 3 && !isLetter)
            {
                lastChar = 'x';
                temporaryMakss = mask.Split('.');
                string binMask = Calc(temporaryMakss[0]) + Calc(temporaryMakss[1]) + Calc(temporaryMakss[2]) + Calc(temporaryMakss[3]);
                foreach(var comp in binMask)
                {
                    if (comp == '1' && lastChar == '0')
                        return false;
                    lastChar = comp;
                }
                return true;
            }
            else
                return false;
        }

        public bool chceckSubnet()
        {
            temporarySubnet = subnet;

            foreach (var comp in temporarySubnet)
                if (char.IsLetter(comp))
                    return false;
            return true;
        }


        private void IPA_Load(object sender, EventArgs e)
        {

        }

        #region Mashines
        //////////////////////////////////////////////////Mashines
        ///Calc is calculating system '10' to '2'
        public string Calc(string octet)
        {
            int intOctet = Convert.ToInt32(octet);
            string temporaryOctet = "";
            int loops = 0;
            while (intOctet != 0)
            {
                if (intOctet % 2 == 0)
                {
                    intOctet /= 2;
                    temporaryOctet += "0";
                }
                else
                {
                    intOctet -= 1;
                    intOctet /= 2;
                    temporaryOctet += "1";
                }
                loops += 1;
            }
            for (int i = 0; i < 8 - loops; i++)
                temporaryOctet += "0";
            temporaryOctet = StrFliper(temporaryOctet);
            return temporaryOctet;
        }
        ///

        ///StrFlipper is Reversing any strings
        public string StrFliper(string str)
        {
            string flip = "";
            int count = Convert.ToInt32(str.Length);
            foreach (int element in str)
            {
                flip += str[count - 1];
                count -= 1;
            }
            return flip;
        }
        ///
        ///////////////////////////////////////////////////////////

        #endregion
    }
}
