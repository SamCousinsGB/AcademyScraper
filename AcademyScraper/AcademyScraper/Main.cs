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

            string url = "http://www.reddishvulcans.com/uk_tournament_database.asp";
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);

            var root = doc.DocumentNode;
            var nodes = root.Descendants();
            foreach (HtmlNode node in doc.DocumentNode.SelectSingleNode("//div[@class='infobox']").Descendants()) 
            {
                if(node.InnerHtml.Trim() != "" && node.OuterHtml.Trim() != "" && node.InnerHtml.Trim() != null && node.OuterHtml.Trim() != null)
                {
                    MessageBox.Show(node.InnerHtml.Trim());
                }
                
               
            }

        }
    }
}
