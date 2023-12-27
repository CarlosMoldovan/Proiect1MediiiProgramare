using Proiect1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Laboratorul4ex2
{
    public partial class Form1 : Form
    {
        private List<string> lstBlock = new List<string> { "sport", "facebook" };
        Database database;
        bool ok = false;

        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            this.database = new Database();

            Trace.Listeners.Add(new TextWriterTraceListener(@"C:\Users\c2476\Desktop\INFORMATICA\Laboratoare\Medii de programare\Proiect1\log.txt"));
            Trace.AutoFlush = true;
            Trace.Indent();

            this.FormClosing += Form1_FormClosing;
        }
              

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Trace.Flush();
        }

        private void WriteToFile(string message)
        {
            Trace.WriteLine(message);
            Trace.Flush();
        }

        private void btngo_Click_1(object sender, EventArgs e)
        {
            this.webBrowser.Navigate(txturl.Text);
        }

        private void txturl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.webBrowser.Navigate(txturl.Text);
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
             
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.ToString();

            var res = Task.Run(() => AsyncCheckBlock(url));
            res.Wait();

            if (res.Result)
            {
                e.Cancel = true;
                MessageBox.Show("Url Blocat");
            }
        }

        /*private async Task<bool> AsyncCheckBlock(string url)
        {
            bool rez = await Task.Run(
                   async () =>
                   {
                       return (from x in lstBlock
                               where url.Contains(x)
                               select x).Count() > 0;
                   }
                );
            return rez;
        }*/

        /*private async Task<bool> AsyncCheckBlock(string url)
        {
            bool rez = await Task.Run(
                async () =>
                {
                    bool isBlocked = (from x in lstBlock
                                      where url.Contains(x)
                                      select x).Count() > 0;

                    if (isBlocked)
                    {
                        string message = $"Blocked URL: {url}";
                        await Task.Run(() => WriteToFile(message));
                    }

                    return isBlocked;
                }
            );
            return rez;
        }*/


        private async Task<bool> AsyncCheckBlock(string url)
        {
            bool rez = await Task.Run(
                async () =>
                {
                    DataTable keywordsTable = this.database.GetData();

                    foreach (DataRow row in keywordsTable.Rows)
                    {
                        string keyword = row["CuvântCheie"].ToString();
                        if (url.Contains(keyword))
                        {
                            string message = $"Blocked URL: {url}";
                            await Task.Run(() => WriteToFile(message));
                            return true;
                        }
                    }

                    return false;
                }
            );

            return rez;
        }



        private void btnfoward_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward)
            {
                webBrowser.GoForward();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack)
            {
                webBrowser.GoBack();
            }
        }

        public void UpdateComboBox()
        {
            Console.WriteLine("UpdateComboBox called");
            comboBox1.DataSource = null;
            comboBox1.DataSource = lstBlock;
            comboBox1.SelectedIndex = -1;
        }

        private void AdaugăCuvant_Click(object sender, EventArgs e)
        {
            using (AddKeywordForm addKeywordForm = new AddKeywordForm(lstBlock))
            {
                DialogResult result = addKeywordForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string newKeyword = addKeywordForm.Keyword;
                    if (!string.IsNullOrWhiteSpace(newKeyword))
                    {
                        lstBlock.Add(newKeyword);
                        this.database.InsertData(newKeyword);
                        UpdateComboBox();
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKeyword = comboBox1.SelectedItem.ToString();
            this.database.Cautare(selectedKeyword);
        }
    }
}
