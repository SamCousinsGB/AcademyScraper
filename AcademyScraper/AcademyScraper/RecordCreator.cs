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

            var addresses = root.SelectNodes("//div[@class='infobox']/table/tr/td[1]");

            var spaces = root.SelectNodes("//div[@class='infobox']/table/tr[2]/td");
            var perside = root.SelectNodes("//div[@class='infobox']/table/tr[3]/td[2]");
            var genders = root.SelectNodes("//div[@class='infobox']/table/tr[3]/td[2]");

            var ages = root.SelectNodes("//div[@class='infobox']/table/tr[5]/td/img");

            var links = root.SelectNodes("//div[@class='infobox']/table/tr/td[1]/a");

            List<Record> recordList = new List<Record>();
            List<String> tournamentNames = new List<String>();
            List<String> tournamentDates = new List<String>();
            List<String> tournamentAddresses = new List<String>();
            List<String> tournamentSpaces = new List<String>();
            List<String> tournamentPerSide = new List<String>();
            List<String> tournamentGenders = new List<String>();
            List<String> tournamentAges = new List<String>();
            List<String> tournamentLinks = new List<String>();

            foreach (var tag in names)
            {
                if (tag.InnerText != "View Available Space and Book Online")
                {
                    String title = tag.InnerText.Replace(",", "");
                    title = title.Replace(" =-", "");
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

            foreach (var tag in addresses)
            {

                tournamentAddresses.Add("1");

            }

            String ageGroups = "";

            foreach (var tag in ages)
            {
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u6_Yes.gif")
                {
                    ageGroups += " U6 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u7_Yes.gif")
                {
                    ageGroups += " U7 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u8_Yes.gif")
                {
                    ageGroups += " U8 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u9_Yes.gif")
                {
                    ageGroups += " U9 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u10_Yes.gif")
                {
                    ageGroups += " U10 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u11_Yes.gif")
                {
                    ageGroups += " U11 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u12_Yes.gif")
                {
                    ageGroups += " U12 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u13_Yes.gif")
                {
                    ageGroups += " U13 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u14_Yes.gif")
                {
                    ageGroups += " U14 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u15_Yes.gif")
                {
                    ageGroups += " U15 ";
                    continue;
                }
                if (tag.GetAttributeValue("src", "nope") == "images/2016/u16_Yes.gif")
                {
                    ageGroups += " U16 ";
                    continue;
                }
                if(ageGroups != "")
                {
                    tournamentAges.Add(ageGroups);
                }
               
                ageGroups = "";
            }
           
           



            foreach (var tag in links)
            {

                string link = tag.GetAttributeValue("href", "N/A");
                link = link.Replace("&nbsp;", "");
                link = link.Replace(System.Environment.NewLine, "");
                link = link.Replace("    ", "");
                link = "http://www.reddishvulcans.com/" + link;
                tournamentLinks.Add(link);

            }

            foreach (var tag in spaces)
            {
                String space = tag.InnerText.Replace(",","");
                tournamentSpaces.Add(space);

            }

            

            for (var i = 0; i < tournamentNames.Count(); i++)
            {
                recordList.Add(new Record()
                {
                    NAME = tournamentNames[i],
                    DATE = tournamentDates[i],
                    ADDRESS = tournamentAddresses[i],
                    AGE_GROUPS = tournamentAges[i],
                    NUM_PER_SIDE = "",
                    GENDER = "",
                    LINK = tournamentLinks[i],
                    SPACES = tournamentSpaces[i]
                });
            }

            return recordList;

        }
    }
}
