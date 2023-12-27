using System.Drawing;
using System.Windows.Forms;

namespace Laboratorul4ex2
{
    partial class Form1
    {
         
        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnback = new System.Windows.Forms.ToolStripButton();
            this.btnfoward = new System.Windows.Forms.ToolStripButton();
            this.txturl = new System.Windows.Forms.ToolStripTextBox();
            this.btngo = new System.Windows.Forms.ToolStripButton();
            this.AdaugăCuvant = new System.Windows.Forms.ToolStripButton();
            this.comboBoxKeywords = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 27);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1206, 447);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnback,
            this.btnfoward,
            this.txturl,
            this.btngo,
            this.AdaugăCuvant});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1206, 27);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Blue;
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(44, 24);
            this.btnback.Text = "Back";
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnfoward
            // 
            this.btnfoward.BackColor = System.Drawing.Color.Red;
            this.btnfoward.ForeColor = System.Drawing.Color.White;
            this.btnfoward.Name = "btnfoward";
            this.btnfoward.Size = new System.Drawing.Size(62, 24);
            this.btnfoward.Text = "Foward";
            this.btnfoward.Click += new System.EventHandler(this.btnfoward_Click);
            // 
            // txturl
            // 
            this.txturl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(300, 27);
            this.txturl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txturl_KeyPress);
            // 
            // btngo
            // 
            this.btngo.BackColor = System.Drawing.Color.Red;
            this.btngo.ForeColor = System.Drawing.Color.White;
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(34, 24);
            this.btngo.Text = "GO";
            this.btngo.Click += new System.EventHandler(this.btngo_Click_1);
            // 
            // AdaugăCuvant
            // 
            this.AdaugăCuvant.BackColor = System.Drawing.Color.Blue;
            this.AdaugăCuvant.ForeColor = System.Drawing.Color.White;
            this.AdaugăCuvant.Name = "AdaugăCuvant";
            this.AdaugăCuvant.Size = new System.Drawing.Size(110, 24);
            this.AdaugăCuvant.Text = "AdaugăCuvant";
            this.AdaugăCuvant.Click += new System.EventHandler(this.AdaugăCuvant_Click);
            // 
            // comboBoxKeywords
            // 
            this.comboBoxKeywords.Location = new System.Drawing.Point(110, 110);
            this.comboBoxKeywords.Name = "comboBoxKeywords";
            this.comboBoxKeywords.Size = new System.Drawing.Size(200, 24);
            this.comboBoxKeywords.TabIndex = 2;
            this.comboBoxKeywords.Text = "Text";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(591, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 474);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.comboBoxKeywords);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnback;
        private System.Windows.Forms.ToolStripButton btnfoward;
        private System.Windows.Forms.ToolStripTextBox txturl;
        private System.Windows.Forms.ToolStripButton btngo;
        private ToolStripButton AdaugăCuvant;
        private System.Windows.Forms.ComboBox comboBoxKeywords;
        private ComboBox comboBox1;
    }
}



