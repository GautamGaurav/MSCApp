using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCCommon
{
    public class TimeZones : Response
    {
        public int id { get; set; }
        public int wId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string utcOffset { get; set; }

        public TimeZones() { }

        public TimeZones(int _id, int _wId, string _name, string _code, string _countryCode, string _countryName, string _utcOffset)
        {
            id = _id;
            wId = _wId;
            name = _name;
            code = _code;
            countryCode = _countryCode;
            countryName = _countryName;
            utcOffset = _utcOffset;
        }
    }
}
