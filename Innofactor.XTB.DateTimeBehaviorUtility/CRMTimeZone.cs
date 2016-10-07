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
        public float Offset { get; private set; }

        public CRMTimeZone(int timeZoneCode, string region, float offset)
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
}
