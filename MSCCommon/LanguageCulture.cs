using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCCommon
{
    public class LanguageCulture : Response
    {
        public int id { get; set; }
        public string cultureName { get; set; }
        public string displayName { get; set; }
        public string cultureCode { get; set; }
        public string iso639xValue { get; set; }

        public LanguageCulture() { }

        public LanguageCulture(int _id, string _cultureName, string _displayName, string _cultureCode, string _iso639xValue)
        {
            id = _id;
            cultureName = _cultureName;
            displayName = _displayName;
            cultureCode = _cultureCode;
            iso639xValue = _iso639xValue;
        }
    }
}
