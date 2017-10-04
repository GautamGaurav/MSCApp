using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCServices
{
    public class Utils
    {
        public static string CheckForBlank(string input)
        {
            string output = String.IsNullOrEmpty(input) ? "" : input;
            return output;
        }
    }
}
