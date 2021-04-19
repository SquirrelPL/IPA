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
    public partial class Vlsm : Form
    {
        public static string ip, mask, subnet;
        public static bool vlsm;
        ListBox listBox = new ListBox();
        private int itemSelected;
        private System.Windows.Forms.TextBox editBox;
        public event EventHandler DoubleClick;
        //List<string> list = new List<string>();
        public Vlsm(string ip, string mask, string subnet, bool vlsm)
        {
            Vlsm.ip = ip;
            Vlsm.mask = mask;
            Vlsm.subnet = subnet;
            Vlsm.vlsm = vlsm;
            InitializeComponent();
        }

        private void Vlsm_Load(object sender, EventArgs e)
        {

            listBox.Location = new Point(0, 0);
            listBox.Size = new Size(200,400);
            listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            listBox.ForeColor = System.Drawing.Color.White;
            listBox.BorderStyle = BorderStyle.Fixed3D;
            listBox.DoubleClick += new EventHandler(this.listBox_DoubleClick);
            for (int i = 0; i < Convert.ToInt32(subnet); i++)
            {
                listBox.Items.Add((i + 1).ToString() + ":   " + "100");
            }

            this.Controls.Add(listBox);

            editBox = new System.Windows.Forms.TextBox();
            editBox.Location = new System.Drawing.Point(0, 0);
            editBox.Size = new System.Drawing.Size(0, 0);
            editBox.Hide();
            listBox.Controls.AddRange(new System.Windows.Forms.Control[]{ this.editBox });
            editBox.Text = "";
            editBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            editBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            editBox.ForeColor = System.Drawing.Color.White;
            editBox.BorderStyle = BorderStyle.FixedSingle;

        }

        private void listBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                CreateEditBox(sender);
        }
        private void listBox_DoubleClick(object sender, System.EventArgs e)
        {
            CreateEditBox(sender);
        }

        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
                CreateEditBox(sender);
        }
        private void CreateEditBox(object sender)
        {
            listBox = (ListBox)sender;
            itemSelected = listBox.SelectedIndex;
            Rectangle r = listBox.GetItemRectangle(itemSelected);
            string itemText = (string)listBox.Items[itemSelected];
            editBox.Location = new System.Drawing.Point(r.X + 30, r.Y);
            editBox.Size = new System.Drawing.Size(r.Width - 150, r.Height - 20);
            editBox.MaxLength = 6;
            editBox.Show();
            listBox.Controls.AddRange(new Control[] { this.editBox });
            editBox.Text = itemText.Remove(0,5);
            editBox.Focus();
            editBox.SelectAll();
            editBox.KeyPress += new KeyPressEventHandler(this.EditOver);
            editBox.LostFocus += new EventHandler(this.FocusOver);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            List<int> listInt = new List<int>();

            foreach (var item in listBox.Items)
            {
                //list.Add((item.ToString()).Remove(0, 5));
                listInt.Add(Convert.ToInt32((item.ToString()).Remove(0, 5)));
            }


            listInt.Sort();
            for (int i = 0; i<listInt.Count; i++)
                list.Add(listInt[i].ToString());
            list.Reverse();
            Output output = new Output(ip, mask, subnet, vlsm, list);
            output.Location = this.Location;
            output.StartPosition = FormStartPosition.Manual;
            output.FormClosing += delegate { this.Show(); };
            output.Show();
            this.Hide();
        }

        private void FocusOver(object sender, EventArgs e)
        {
            listBox.Items[itemSelected] = (itemSelected + 1).ToString() + ":   " + editBox.Text;
            editBox.Hide();
        }

        private void EditOver(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                listBox.Items[itemSelected] = (itemSelected+1).ToString() + ":   " + editBox.Text;
                editBox.Hide();
            }
        }


    }
}
