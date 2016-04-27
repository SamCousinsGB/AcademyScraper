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
            var ages = root.SelectNodes("//div[@class='infobox']/table/tr[5]/td/img");
            //    var perside = root.SelectNodes("//div[@class='infobox']/table/tr/td[1]/strong");
            var perside = root.SelectNodes(".//div[@class='infobox']/table/tr[4]/td[1]");
            var genders = root.SelectNodes("//div[@class='infobox']/table/tr[3]/td[2]");
            var links = root.SelectNodes("//div[@class='infobox']/table/tr/td[1]/a");
            var spaces = root.SelectNodes("//div[@class='infobox']/table/tr[2]/td");

            List<Record> recordList = new List<Record>();
            List<String> tournamentNames = new List<String>();
            List<String> tournamentDates = new List<String>();
            List<String> tournamentAddresses = new List<String>();
            List<String> tournamentAges = new List<String>();
            List<String> tournamentPerSide = new List<String>();
            List<String> tournamentGenders = new List<String>();
            List<String> tournamentLinks = new List<String>();
            List<String> tournamentSpaces = new List<String>();
           
            #region Names - Done


            foreach (var tag in names)
            {
                if (tag.InnerText != "View Available Space and Book Online" && tag.InnerText != "Check Availability & Book Online")
                {
                    String title = tag.InnerText.Replace(",", "");
                    title = title.Replace("=", "");
                    tournamentNames.Add(title);
                }
            }

            #endregion 

            #region Dates - Done

            foreach (var tag in dates)
            {
                String date = tag.InnerText.Replace(",", "");
                date = date.Replace("&nbsp;", "");
                date = date.Replace(System.Environment.NewLine, "");
                date = date.Replace("    ", "");
                tournamentDates.Add(date);
            }

            #endregion // Done

            #region Addresses

            foreach (var tag in addresses)
            {
                tournamentAddresses.Add("1");
            }

            #endregion

            #region Ages - Done

            List<String> recordAges = new List<String>();

            foreach (var age in ages)
            {
                
                if (age.GetAttributeValue("src", "nope") == "images/2016/u6_Yes.gif")
                {
                    recordAges.Add(" U6 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u6_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u7_Yes.gif")
                {
                    recordAges.Add(" U7 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u7_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u8_Yes.gif")
                {
                    recordAges.Add(" U8 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u8_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u9_Yes.gif")
                {
                    recordAges.Add(" U9 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u9_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u10_Yes.gif")
                {
                    recordAges.Add(" U10 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u10_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u11_Yes.gif")
                {
                    recordAges.Add(" U11 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u11_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u12_Yes.gif")
                {
                    recordAges.Add(" U12 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u12_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u13_Yes.gif")
                {
                    recordAges.Add(" U13 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u13_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u14_Yes.gif")
                {
                    recordAges.Add(" U14 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u14_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u15_Yes.gif")
                {
                    recordAges.Add(" U15 ");
                    continue;
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u15_.gif")
                {
                    continue;
                }

                if (age.GetAttributeValue("src", "nope") == "images/2016/u16_Yes.gif")
                {
                    recordAges.Add(" U16 ");
                
                }
                else if (age.GetAttributeValue("src", "nope") == "images/2016/u16_.gif")
                {
           
                }

                String final = "";
                foreach (String record in recordAges)
                {
                    final += record;
                }

                tournamentAges.Add(final);
                recordAges.Clear();

            }

            #endregion

            #region Perside



            foreach (var tag in perside)
            {
                HtmlNode node = tag.SelectSingleNode(".//img[4]");
                if (node != null)
                {
                    tournamentPerSide.Add(node.GetAttributeValue("title", "none"));
                }
                else
                {
                    tournamentPerSide.Add("");
                }   
            }
    
            #endregion

            #region Genders

            #endregion

            #region Links
            foreach (var tag in links)
            {

               


                if(tag.InnerText != "View Available Space and Book Online" && tag.InnerText != "Check Availability & Book Online")
                {
                    string link = tag.GetAttributeValue("href", "N/A");
                    link = link.Replace("&nbsp;", "");
                    link = link.Replace(System.Environment.NewLine, "");
                    link = link.Replace("    ", "");
                    link = "http://www.reddishvulcans.com/" + link;
                    tournamentLinks.Add(link);
                }
                

            }

            #endregion

            #region Spaces
            foreach (var tag in spaces)
            {
                String space = tag.InnerText.Replace(",","");
                tournamentSpaces.Add(space);

            }
            #endregion

            #region Build Record List
            for (var i = 0; i < tournamentDates.Count(); i++)
            {
                recordList.Add(new Record()
                {
                    NAME = tournamentNames[i],
                    DATE = tournamentDates[i],
                    ADDRESS = tournamentAddresses[i],
                    AGE_GROUPS = tournamentAges[i],
                    NUM_PER_SIDE = tournamentPerSide[i],
                    GENDER = "",
                    LINK = tournamentLinks[i],
                    SPACES = tournamentSpaces[i]
                });
            }

            return recordList;
            #endregion

        }


    }
}
