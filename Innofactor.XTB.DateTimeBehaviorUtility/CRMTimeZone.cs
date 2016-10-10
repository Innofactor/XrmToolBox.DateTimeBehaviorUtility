using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innofactor.XTB.DateTimeBehaviorUtility
{
    internal class CRMTimeZone
    {
        public int TimeZoneCode { get; private set; }
        public string Region { get; private set; }
        public double Offset { get; private set; }

        public CRMTimeZone(int timeZoneCode, string region, double offset)
        {
            TimeZoneCode = timeZoneCode;
            Region = region;
            Offset = offset;
        }

        public override string ToString()
        {
            return $"{Region} ({Offset})";
        }
    }

    internal class CRMTimeZoneList : List<CRMTimeZone>
    {
        public CRMTimeZoneList()
        {
            Add(new CRMTimeZone(0, "Dateline Time", -12));
            Add(new CRMTimeZone(1, "Samoa Time", -11));
            Add(new CRMTimeZone(2, "Hawaiian Time", -10));
            Add(new CRMTimeZone(3, "Alaskan Time", -9));
            Add(new CRMTimeZone(4, "Pacific Time", -8));
            Add(new CRMTimeZone(10, "Mountain Time", -7));
            Add(new CRMTimeZone(13, "Mexico2 Time", -7));
            Add(new CRMTimeZone(15, "US Mountain Time", -7));
            Add(new CRMTimeZone(20, "Central Time", -6));
            Add(new CRMTimeZone(25, "Canada Central Time", -6));
            Add(new CRMTimeZone(30, "Mexico Time", -6));
            Add(new CRMTimeZone(33, "Central America Time", -6));
            Add(new CRMTimeZone(35, "Eastern Time", -5));
            Add(new CRMTimeZone(40, "US Eastern Time", -5));
            Add(new CRMTimeZone(45, "SA Pacific Time", -5));
            Add(new CRMTimeZone(50, "Atlantic Time", -4));
            Add(new CRMTimeZone(55, "SA Western Time", -4));
            Add(new CRMTimeZone(56, "Pacific SA Time", -4));
            Add(new CRMTimeZone(60, "Newfoundland Time", -3.5));
            Add(new CRMTimeZone(65, "E. South America Time", -3));
            Add(new CRMTimeZone(70, "SA Eastern Time", -3));
            Add(new CRMTimeZone(73, "Greenland Time", -3));
            Add(new CRMTimeZone(75, "Mid-Atlantic Time", -2));
            Add(new CRMTimeZone(80, "Azores Time", -1));
            Add(new CRMTimeZone(83, "Cape Verde Time", -1));
            Add(new CRMTimeZone(85, "GMT Time", 0));
            Add(new CRMTimeZone(90, "Greenwich Time", 0));
            Add(new CRMTimeZone(95, "Central Europe Time", 1));
            Add(new CRMTimeZone(100, "Central European Time", 1));
            Add(new CRMTimeZone(105, "Romance Time", 1));
            Add(new CRMTimeZone(110, "W. Europe Time", 1));
            Add(new CRMTimeZone(113, "W. Central Africa Time", 1));
            Add(new CRMTimeZone(115, "E. Europe Time", 2));
            Add(new CRMTimeZone(120, "Egypt Time", 2));
            Add(new CRMTimeZone(125, "FLE Time", 2));
            Add(new CRMTimeZone(130, "GTB Time", 2));
            Add(new CRMTimeZone(135, "Jerusalem Time", 2));
            Add(new CRMTimeZone(140, "South Africa Time", 2));
            Add(new CRMTimeZone(145, "Russian Time", 3));
            Add(new CRMTimeZone(150, "Arab Time", 3));
            Add(new CRMTimeZone(155, "E. Africa Time", 3));
            Add(new CRMTimeZone(158, "Arabic Time", 3));
            Add(new CRMTimeZone(160, "Iran Time", 3.5));
            Add(new CRMTimeZone(165, "Arabian Time", 4));
            Add(new CRMTimeZone(170, "Caucasus Time", 4));
            Add(new CRMTimeZone(175, "Afghanistan Time", 4.5));
            Add(new CRMTimeZone(180, "Ekaterinburg Time", 5));
            Add(new CRMTimeZone(185, "West Asia Time", 5));
            Add(new CRMTimeZone(190, "India Time", 5.5));
            Add(new CRMTimeZone(193, "Nepal Time", 5.75));
            Add(new CRMTimeZone(195, "Central Asia Time", 6));
            Add(new CRMTimeZone(200, "Sri Lanka Time", 6));
            Add(new CRMTimeZone(201, "N. Central Asia Time", 6));
            Add(new CRMTimeZone(203, "Myanmar Time", 6.5));
            Add(new CRMTimeZone(205, "SE Asia Time", 7));
            Add(new CRMTimeZone(207, "North Asia Time", 7));
            Add(new CRMTimeZone(210, "China Time", 8));
            Add(new CRMTimeZone(215, "Malay Peninsula Time", 8));
            Add(new CRMTimeZone(220, "Taipei Time", 8));
            Add(new CRMTimeZone(225, "W. Australia Time", 8));
            Add(new CRMTimeZone(227, "North Asia East Time", 8));
            Add(new CRMTimeZone(230, "Korea Time", 9));
            Add(new CRMTimeZone(235, "Tokyo Time", 9));
            Add(new CRMTimeZone(240, "Yakutsk Time", 9));
            Add(new CRMTimeZone(245, "AUS Central Time", 9.5));
            Add(new CRMTimeZone(250, "Cen. Australia Time", 9.5));
            Add(new CRMTimeZone(255, "AUS Eastern Time", 10));
            Add(new CRMTimeZone(260, "E. Australia Time", 10));
            Add(new CRMTimeZone(265, "Tasmania Time", 10));
            Add(new CRMTimeZone(270, "Vladivostok Time", 10));
            Add(new CRMTimeZone(275, "West Pacific Time", 10));
            Add(new CRMTimeZone(280, "Central Pacific Time", 11));
            Add(new CRMTimeZone(285, "Fiji Islands Time", 12));
            Add(new CRMTimeZone(290, "New Zealand Time", 12));
            Add(new CRMTimeZone(300, "Tonga Time", 13));
            Add(new CRMTimeZone(360, "Coordinated Universal Time (UTC)", 0));
        }
    }
}