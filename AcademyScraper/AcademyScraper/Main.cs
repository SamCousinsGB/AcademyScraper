using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using FileHelpers;



namespace AcademyScraper
{
    public partial class Main : Form
    {



        public Main()
        {
            InitializeComponent();
            savePathTB.Text = "C:/Users/" + Environment.UserName + "/Desktop/scrape.csv";
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {



            List<Record> recordList = RecordCreator.getRecords();

           

          

            var engine = new FileHelperAsyncEngine<Record>();

            engine.HeaderText = engine.GetFileHeader();

            try
            {
                using (engine.BeginWriteFile(savePathTB.Text))
                {
                    foreach (Record rec in recordList)
                    {
                        engine.WriteNext(rec);
                    }
                }
                DialogResult result;
                result = MessageBox.Show("Done! Open file?", "File generated.", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(savePathTB.Text);
                }

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }




        }


    }
}
