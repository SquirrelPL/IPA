using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPA
{
    public partial class Output : Form
    {
        public static string ip, mask, subnet;
        public static bool vlsm;
        public string[] ip10Octets, ip2Octets, net2Address, net10Address, mask10Octets, mask2Octets, broadcastAddress;
        string[] maskNot = { "", "", "", "" }, notMask = { "", "", "", "" };
        public static List<string> vlsmList = new List<string>();
        private string[] temporaryNetAddress = { "", "", "", "" }, temporaryBroadcastAddress = { "", "", "", "" }, temporaryFirstAddress = { "", "", "", "" },
            temporaryLastAddress = { "", "", "", "" }, temporaryMask = { "", "", "", "" };
        private string temporaryHosts = "", temporaryClass = "";
        int x = 0;
        bool firstTIme = true;
        int displayNetwork = 0;
        int subnetState = 0; //it tells what subnet is now calculating
        List<Network> network = new List<Network>();


        public Output(string ip, string mask, string subnet, bool vlsm, List<string> vlsmList)
        {
            InitializeComponent();
            Output.ip = ip;
            Output.mask = mask;
            Output.subnet = subnet;
            Output.vlsm = vlsm;
            Output.vlsmList = vlsmList;
            //network.Add(new Network());
        }

        private void Output_Load(object sender, EventArgs e)
        {
            IPO.Text = ip;
            MaskO.Text = mask + "/" + MaskTable(mask.Split('.')).ToString();
            SubnetsO.Text = subnet;

            CreatePublicData();
        }

        public void CreatePublicData()
        {
            
            for (subnetState = 0; subnetState< Convert.ToInt32(subnet); subnetState++)
            {
                if (vlsm)
                {
                    mask = SetMask(Convert.ToInt32(vlsmList[subnetState]));
                    temporaryMask = mask.Split('.');
                }

                CreateNetAddress();
                
                network.Add(new Network(temporaryNetAddress,
                        temporaryBroadcastAddress,
                        temporaryFirstAddress,
                        temporaryLastAddress,
                        temporaryHosts,
                        temporaryClass,
                        temporaryMask, subnetState));

                if (firstTIme == true)
                {
                    firstTIme = false;
                    AssignData(0);
                }
            }
        }

        public void AssignData(int dn)
        {
            WhichSubnet.Text = "Subnet: " + (displayNetwork + 1).ToString();
            NetAddress.Text = network[dn].netAddress1 + "." + network[dn].netAddress2 + "." + network[dn].netAddress3 + "." + network[dn].netAddress4;
            BroadcastAddressT.Text = network[dn].broadcastAddress1 + "." + network[dn].broadcastAddress2 + "." + network[dn].broadcastAddress3 + "." + network[dn].broadcastAddress4;
            FirstAddress.Text = network[dn].firstAddress1 + "." + network[dn].firstAddress2 + "." + network[dn].firstAddress3 + "." + network[dn].firstAddress4;
            LastAddress.Text = network[dn].lastAddress1 + "." + network[dn].lastAddress2 + "." + network[dn].lastAddress3 + "." + network[dn].lastAddress4;
            Hosts.Text = network[dn].hosts;
            Class.Text = network[dn].clas;
            if (!vlsm)
                SubnetMask.Text = mask + "/" + MaskTable(mask10Octets);
            else
            {
                string[] maskX = { network[dn].mask1, network[dn].mask2, network[dn].mask3, network[dn].mask4 };
                SubnetMask.Text = network[dn].mask1 + "." + network[dn].mask2 + "." + network[dn].mask3 + "." + network[dn].mask4 + "/" + MaskTable(maskX);
            }
        }

        public void CreateIpAndMaskBin()
        {
            //Creating 4 Octets With Base of ip
            ip10Octets = ip.Split('.');
            ip2Octets = ip.Split('.');
            net2Address = ip.Split('.');
            net10Address = ip.Split('.');
            mask10Octets = mask.Split('.');
            mask2Octets = mask.Split('.');
            broadcastAddress = mask.Split('.');
            //
            for (int i = 0; i < 4; i++)
            {
                ip2Octets[i] = Calc(ip10Octets[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                mask2Octets[i] = Calc(mask10Octets[i]);
            }
        }

        ///CreateNetAddress is calculating NetAddress
        private void CreateNetAddress()
        {
            if (subnetState == 0)
            {

                CreateIpAndMaskBin();
                string[] temporaryOctet = { "", "", "", "" };
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 8; j++)
                        temporaryOctet[i] += (Convert.ToInt32(ip2Octets[i].Substring(j, 1)) * Convert.ToInt32(mask2Octets[i].Substring(j, 1))).ToString();
                for (int i = 0; i < 4; i++)
                    net10Address[i] = (Convert.ToInt32(temporaryOctet[i], 2)).ToString();
                //NetAddress.Text = net10Address[0] + "." + net10Address[1] + "." + net10Address[2] + "." + net10Address[3];
                for(int i = 0; i<4; i++)
                    temporaryNetAddress[i] = net10Address[i];
            }
            else
            {
                //temporaryNetAddress = SetGeneration(temporaryBroadcastAddress, 1);
                temporaryNetAddress[0] = (Convert.ToInt32(temporaryBroadcastAddress[0])).ToString();
                temporaryNetAddress[1] = (Convert.ToInt32(temporaryBroadcastAddress[1])).ToString();
                temporaryNetAddress[2] = (Convert.ToInt32(temporaryBroadcastAddress[2])).ToString();
                temporaryNetAddress[3] = (Convert.ToInt32(temporaryBroadcastAddress[3]) + 1).ToString();
                temporaryNetAddress = SetGeneration(temporaryNetAddress, 0);

            }
            CreateBroadcastAddress();
        }
        ///

        /// CreateBroadcastAddress creates BroadcastAddress 
        private void CreateBroadcastAddress()
        {
            if (subnetState == 0)
            {
                string[] temporaryOctet = { "", "", "", "" };
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if (mask2Octets[i].Substring(j, 1) == "0")
                            maskNot[i] += 1;
                        else
                            maskNot[i] += 0;
                    }
                for (int i = 0; i < 4; i++)
                {
                    notMask[i] = maskNot[i];
                }
                for (int i = 0; i < 4; i++)
                {
                    maskNot[i] = (Convert.ToInt32(maskNot[i], 2)).ToString();
                    broadcastAddress[i] = (Convert.ToInt32(maskNot[i]) + Convert.ToInt32(net10Address[i])).ToString();
                }
                //BroadcastAddressT.Text = broadcastAddress[0] + "." + broadcastAddress[1] + "." + broadcastAddress[2] + "." + broadcastAddress[3];
                for (int i = 0; i < 4; i++)
                    temporaryBroadcastAddress[i] = broadcastAddress[i];
            }
            else if(vlsm)
                temporaryBroadcastAddress = SetGeneration(temporaryBroadcastAddress, Convert.ToInt32((Math.Pow(2, x))));
            else
                temporaryBroadcastAddress = SetGeneration(temporaryBroadcastAddress, (Convert.ToInt32(temporaryHosts)) + (2));

            CreateFirstAndLastAddress();
        }
        ///

        /// CreateFirstAndLastAddress creates First and last Useable Address 
        private void CreateFirstAndLastAddress()
        {
            //FirstAddress.Text = ip10Octets[0] + "." + ip10Octets[1] + "." + ip10Octets[2] + "." + (Convert.ToInt32(ip10Octets[3])+1).ToString();
            //LastAddress.Text = broadcastAddress[0] + "." + broadcastAddress[1] + "." + broadcastAddress[2] + "." + (Convert.ToInt32(broadcastAddress[3])-1).ToString();
            for (int i = 0; i < 3; i++)
            {
                temporaryFirstAddress[i] = ip10Octets[i];
                temporaryLastAddress[i] = broadcastAddress[i];
            }

            for(int i = 0; i<4; i++)
            {
                if (i == 3)
                {
                    try
                    {
                        temporaryFirstAddress[3] = ((Convert.ToInt32(temporaryNetAddress[3]) + 1)).ToString();
                        temporaryLastAddress[3] = ((Convert.ToInt32(temporaryBroadcastAddress[3]) - 1)).ToString();
                    }
                    catch (Exception e)
                    {

                    }
                }
                else
                {
                    try
                    {
                        temporaryLastAddress[i] = ((Convert.ToInt32(temporaryBroadcastAddress[i]))).ToString();
                        temporaryFirstAddress[i] = ((Convert.ToInt32(temporaryNetAddress[i]))).ToString();
                    }
                    catch(Exception e)
                    {

                    }
                }
            }
           

            CreateHosts();
        }
        ///

        ///CreateHosts is counting how many hosts u can have
        private void CreateHosts()
        {
            if (!vlsm)
            {
                int zeroCounter = 0;
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if (notMask[i].Substring(j, 1) == "0")
                            zeroCounter += 1;
                        else { }
                    }
                int multiplier = 32 - zeroCounter;
                temporaryHosts = (Math.Pow(2, multiplier) - 2).ToString();
                //Hosts.Text = (Math.Pow(2,multiplier) - 2).ToString();

            }
            else
            {
                temporaryHosts = (Math.Pow(2, x) - 2).ToString();
            }

            CreateClass();
        }
        ///

        /// Creates Label for ip
        private void CreateClass()
        {

            if (Convert.ToInt32(net10Address[0]) >= 0 && Convert.ToInt32(ip10Octets[0]) <= 128)
                temporaryClass = "A";
            else if (Convert.ToInt32(net10Address[0]) >= 128 && Convert.ToInt32(ip10Octets[0]) <= 192)
                temporaryClass = "B";
            else if (Convert.ToInt32(net10Address[0]) >= 192 && Convert.ToInt32(ip10Octets[0]) <= 224)
                temporaryClass = "C";
            else if (Convert.ToInt32(net10Address[0]) >= 224 && Convert.ToInt32(ip10Octets[0]) <= 240)
                temporaryClass = "D";
            else if (Convert.ToInt32(net10Address[0]) >= 240 && Convert.ToInt32(ip10Octets[0]) <= 255)
                temporaryClass = "E";
        }
        ///


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
                if (intOctet%2==0)
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
            foreach(int element in str)
            {
                flip += str[count-1];
                count -= 1;
            }
            return flip;
        }
        ///
        ///////////////////////////////////////////////////////////

        ///Set Generation is used to chceck if(octet is full) and if is it applying correct values 
        public string[] SetGeneration(string[] adress, int hosts)
        {

            if ((Convert.ToInt32(adress[3]) + hosts) > 255)
            {
                int x = (Convert.ToInt32(adress[3]) + hosts);
                if ((Convert.ToInt32(adress[2]) + (x / 255)) > 255)
                {
                    int y = (Convert.ToInt32(adress[2]) + (x / 255));
                    if ((Convert.ToInt32(adress[1]) + (y / 255)) > 255)
                    {
                        int z = (Convert.ToInt32(adress[2]) + (y / 255));
                        if ((Convert.ToInt32(adress[1]) + (z / 255)) > 255)
                        {
                            adress[0] = "TooMany";
                            adress[1] = "TooMany";
                            adress[2] = "TooMany";
                            adress[3] = "TooMany";
                        }
                        else
                        {
                            adress[0] = (Convert.ToInt32(adress[0]) + (z / 255)).ToString();
                            adress[1] = "0";
                            adress[2] = "0";
                            adress[3] = ((z % 255 )).ToString();
                        }
                    }
                    else
                    {
                        adress[1] = (Convert.ToInt32(adress[1]) + (y / 255)).ToString();
                        adress[2] = "0";
                        adress[3] = ((y % 255)).ToString();
                    }
                }
                else
                {
                    adress[2] = (Convert.ToInt32(adress[2]) + (x / 256)).ToString();
                    adress[3] = ((x % 256)).ToString();
                }
            }
            else
            {
                adress[3] = (Convert.ToInt32(adress[3]) + hosts).ToString();
            }
            return adress;


        }
        /////////////////////////////////////////////////////////////////////////////////////////


        public string MaskTable(string[] mask)
        {
            int maskS = 0;

            foreach (var octet in mask)
            {
                switch (octet)
                {
                    case "0":
                        maskS += 0;
                        break;
                    case "128":
                        maskS += 1;
                        break;
                    case "192":
                        maskS += 2;
                        break;
                    case "224":
                        maskS += 3;
                        break;
                    case "240":
                        maskS += 4;
                        break;
                    case "248":
                        maskS += 5;
                        break;
                    case "252":
                        maskS += 6;
                        break;
                    case "254":
                        maskS += 7;
                        break;
                    case "255":
                        maskS += 8;
                        break;
                }
            }
            
            return maskS.ToString();
        }

        public string SetMask(int vlsmList)
        {
            string mask = "";
            x = 0;
            string binMask = "";
            int i = 0;
            string[] maskL = { "","","",""};


            while (vlsmList > (Math.Pow(2, x)-2))
            {
                x += 1;
            }
            for(i = 0; i<32-x; i++)
            {
                binMask += "1";
                if (i == 7 || i == 15 || i == 23)
                {
                    binMask += ".";
                }
            }
            for (i = i ; i<32; i++ )
            {
                binMask += "0";
                if (i == 7 || i == 15 || i == 23)
                {
                    binMask += ".";
                }
            }
            maskL = binMask.Split('.');
            mask = (Convert.ToInt32(maskL[0], 2)).ToString() + "." + (Convert.ToInt32(maskL[1], 2)).ToString() + "." + (Convert.ToInt32(maskL[2], 2)).ToString() + "." + (Convert.ToInt32(maskL[3], 2)).ToString();
            return mask;
        }


        #endregion

        #region functionality
        /////////////////////////////////////////////////////////////////////////////functionality

        /// Swiching between subnets upwards 
        private void button2_Click(object sender, EventArgs e)
        {
            if (displayNetwork != network.Count-1)
            {
                displayNetwork++;
                AssignData(displayNetwork);
            }
        }
        ///

        /// Swiching between subnets downwards 
        private void button1_Click(object sender, EventArgs e)
        {
            if (displayNetwork != 0)
            {
                displayNetwork--;
                AssignData(displayNetwork);
            }
        }
        ///
        
        private void Pass_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        #endregion
    }
}
