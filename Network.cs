using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPA
{
    public class Network
    {
        public string netAddress1 = "", netAddress2 = "", netAddress3 = "", netAddress4 = "";
        public string broadcastAddress1 = "", broadcastAddress2 = "", broadcastAddress3 = "", broadcastAddress4 = "";
        public string firstAddress1 = "", firstAddress2 = "", firstAddress3 = "", firstAddress4 = "";
        public string lastAddress1 = "", lastAddress2 = "", lastAddress3 = "", lastAddress4 = "";
        public string mask1 = "", mask2 = "", mask3 = "", mask4 = "";
        public string hosts = "";
        public string clas = "";
        public int itest;
        public Network(string[] n, string[] b, string[] f, string[] l, string h, string c, string[] m, int i)
        {
            
            netAddress1 = n[0];
            netAddress2 = n[1];
            netAddress3 = n[2];
            netAddress4 = n[3];
            broadcastAddress1 = b[0];
            broadcastAddress2 = b[1];
            broadcastAddress3 = b[2];
            broadcastAddress4 = b[3];
            firstAddress1 = f[0];
            firstAddress2 = f[1];
            firstAddress3 = f[2];
            firstAddress4 = f[3];
            lastAddress1 = l[0];
            lastAddress2 = l[1];
            lastAddress3 = l[2];
            lastAddress4 = l[3];
            hosts = h;
            clas = c;
            mask1 = m[0];
            mask2 = m[1];
            mask3 = m[2];
            mask4 = m[3];
            itest = i;
        }
        
    }
}
