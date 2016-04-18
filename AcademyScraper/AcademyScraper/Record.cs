using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
namespace AcademyScraper
{
    [DelimitedRecord(",")]
    public class Record
    {
        public string NAME;

        public string DATE;

        public string ADDRESS;

        public string AGE_GROUPS;

        public string NUM_PER_SIDE;

        public string GENDER;

        public string LINK;

        public string TEAMS;
    }
}
