using System.Windows.Forms;

namespace IPA
{
    partial class IPA
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPA));
            this.IP = new System.Windows.Forms.TextBox();
            this.IPFooter = new System.Windows.Forms.Label();
            this.MaskFooter = new System.Windows.Forms.Label();
            this.Mask = new System.Windows.Forms.TextBox();
            this.SubnetsFooter = new System.Windows.Forms.Label();
            this.Subnets = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.Button();
            this.VLSMCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // IP
            // 
            this.IP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.IP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IP.ForeColor = System.Drawing.Color.White;
            this.IP.Location = new System.Drawing.Point(127, 61);
            this.IP.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.IP.MaxLength = 15;
            this.IP.MinimumSize = new System.Drawing.Size(200, 20);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(249, 38);
            this.IP.TabIndex = 0;
            this.IP.Text = "192.168.1.0";
            this.IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IPFooter
            // 
            this.IPFooter.AutoSize = true;
            this.IPFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
            this.IPFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IPFooter.Location = new System.Drawing.Point(126, 99);
            this.IPFooter.MinimumSize = new System.Drawing.Size(250, 1);
            this.IPFooter.Name = "IPFooter";
            this.IPFooter.Size = new System.Drawing.Size(250, 2);
            this.IPFooter.TabIndex = 1;
            // 
            // MaskFooter
            // 
            this.MaskFooter.AutoSize = true;
            this.MaskFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
            this.MaskFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaskFooter.Location = new System.Drawing.Point(100, 192);
            this.MaskFooter.MinimumSize = new System.Drawing.Size(300, 1);
            this.MaskFooter.Name = "MaskFooter";
            this.MaskFooter.Size = new System.Drawing.Size(300, 2);
            this.MaskFooter.TabIndex = 3;
            // 
            // Mask
            // 
            this.Mask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Mask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.Mask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Mask.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Mask.ForeColor = System.Drawing.Color.White;
            this.Mask.Location = new System.Drawing.Point(101, 152);
            this.Mask.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.Mask.MaxLength = 15;
            this.Mask.MinimumSize = new System.Drawing.Size(250, 20);
            this.Mask.Name = "Mask";
            this.Mask.Size = new System.Drawing.Size(299, 38);
            this.Mask.TabIndex = 2;
            this.Mask.Text = "255.255.255.192";
            this.Mask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SubnetsFooter
            // 
            this.SubnetsFooter.AutoSize = true;
            this.SubnetsFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
            this.SubnetsFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SubnetsFooter.Location = new System.Drawing.Point(215, 283);
            this.SubnetsFooter.MinimumSize = new System.Drawing.Size(80, 1);
            this.SubnetsFooter.Name = "SubnetsFooter";
            this.SubnetsFooter.Size = new System.Drawing.Size(80, 2);
            this.SubnetsFooter.TabIndex = 5;
            // 
            // Subnets
            // 
            this.Subnets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Subnets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.Subnets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Subnets.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Subnets.ForeColor = System.Drawing.Color.White;
            this.Subnets.Location = new System.Drawing.Point(216, 247);
            this.Subnets.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.Subnets.MaxLength = 3;
            this.Subnets.MinimumSize = new System.Drawing.Size(50, 20);
            this.Subnets.Name = "Subnets";
            this.Subnets.Size = new System.Drawing.Size(79, 38);
            this.Subnets.TabIndex = 4;
            this.Subnets.Text = "4";
            this.Subnets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pass
            // 
            this.Pass.FlatAppearance.BorderSize = 0;
            this.Pass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pass.Image = global::IPA.Properties.Resources.PassButton3;
            this.Pass.Location = new System.Drawing.Point(695, 185);
            this.Pass.Margin = new System.Windows.Forms.Padding(0);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(50, 50);
            this.Pass.TabIndex = 6;
            this.Pass.TabStop = false;
            this.Pass.UseVisualStyleBackColor = true;
            this.Pass.Click += new System.EventHandler(this.Pass_Click);
            // 
            // VLSMCheckBox
            // 
            this.VLSMCheckBox.AutoSize = true;
            this.VLSMCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.VLSMCheckBox.ForeColor = System.Drawing.Color.White;
            this.VLSMCheckBox.Location = new System.Drawing.Point(200, 309);
            this.VLSMCheckBox.Name = "VLSMCheckBox";
            this.VLSMCheckBox.Size = new System.Drawing.Size(108, 33);
            this.VLSMCheckBox.TabIndex = 7;
            this.VLSMCheckBox.Text = "VLSM";
            this.VLSMCheckBox.UseVisualStyleBackColor = true;
            // 
            // IPA
            // 
            this.AcceptButton = this.Pass;
            this.AllowDrop = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.VLSMCheckBox);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.SubnetsFooter);
            this.Controls.Add(this.Subnets);
            this.Controls.Add(this.MaskFooter);
            this.Controls.Add(this.Mask);
            this.Controls.Add(this.IPFooter);
            this.Controls.Add(this.IP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IPA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPA";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.IPA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox IP;
        private Label IPFooter;
        private Label MaskFooter;
        private TextBox Mask;
        private Label SubnetsFooter;
        private TextBox Subnets;
        private Button Pass;
        private CheckBox VLSMCheckBox;
    }
}

