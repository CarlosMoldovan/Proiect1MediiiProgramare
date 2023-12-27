using Laboratorul4ex2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1
{
    public partial class AddKeywordForm : Form
    {
        public string Keyword { get; private set; }

        private List<string> lstBlock;

        public AddKeywordForm(List<string> existingKeywords)
        {
            InitializeComponent();
            lstBlock = existingKeywords;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Keyword = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                lstBlock.Add(Keyword);
                ((Form1)Owner)?.UpdateComboBox();
            }
            this.Close();
        }
    }
}
