using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using FileHelpers;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AcademyScraper
{
    class RecordCreator
    {

        public static List<Record> getRecords()
        {

            string url = "http://www.reddishvulcans.com/uk_tournament_database.asp";
            var Webget = new HtmlWeb();
            var doc = Webget.Load(url);

            var root = doc.DocumentNode;


            var names = root.SelectNodes("//div[@class='infobox']/table/tr/td[1]/a");
            var dates = root.SelectNodes("//div[@class='infobox']/table/tr[3]/td[2]");

            List<Record> recordList = new List<Record>();
            List<String> tournamentNames = new List<String>();
            List<String> tournamentDates = new List<String>();
            List<String> tournamentAddresses = new List<String>();
            List<String> tournamentSpaces = new List<String>();
            List<String> tournamentPerSide = new List<String>();
            List<String> tournamentGenders = new List<String>();
            List<String> tournamentAges = new List<String>();



            foreach (var tag in names)
            {
                if (tag.InnerText != "View Available Space and Book Online")
                {
                    String title = tag.InnerText.Replace(",", "");
                    title = title.Replace("=-", "");
                    tournamentNames.Add(title);
                }
            }

            foreach (var tag in dates)
            {
                
                    String date = tag.InnerText.Replace(",", "");
                    date = date.Replace("&nbsp;", "");
                    date = date.Replace(System.Environment.NewLine, "");
                    date = date.Replace("    ", "");
                tournamentDates.Add(date);
        
            }

          


            for(var i = 0; i < tournamentNames.Count(); i++)
            {
                recordList.Add(new Record()
                {
                    NAME = tournamentNames[i],
                    DATE = tournamentDates[i],
                    ADDRESS = "",
                    AGE_GROUPS = "",
                    NUM_PER_SIDE = "",
                    GENDER = "",
                    LINK = "",
                    TEAMS = ""
                });
            }









            return recordList;


        }
    }
}
