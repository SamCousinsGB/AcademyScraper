using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using FileHelpers;



namespace AcademyScraper
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            using (var client = new System.Net.WebClient())
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                var filename = System.IO.Path.GetTempFileName();

                client.DownloadFile("http://www.reddishvulcans.com/uk_tournament_database.asp", filename);

                
                doc.Load(filename);



                var root = doc.DocumentNode;

                var a_nodes = root.Descendants("a").ToList();

                foreach (var a_node in a_nodes)
                {
                   
                    MessageBox.Show(a_node.GetAttributeValue("href", ""));
                    MessageBox.Show(a_node.InnerText.Trim());
                }
            }
        }
    }
}
