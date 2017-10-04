using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCCommon
{
    public class AppData : Response
    {
        public int batchCount { get; set; }
        public int courseCount { get; set; }
        public int sessionCount { get; set; }
        public int studentCount { get; set; }
        public int tutorCount { get; set; }

        public AppData() { }

        public AppData(int _batchCount, int _courseCount, int _sessionCount, int _studentCount, int _tutorCount)
        {
            batchCount = _batchCount;
            courseCount = _courseCount;
            sessionCount = _sessionCount;
            studentCount = _studentCount;
            tutorCount = _tutorCount;
        }

    }
}
