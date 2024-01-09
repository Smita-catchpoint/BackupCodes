using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class Numbers
    {
        public string CheckNumber(int num)
        {
            if (num == 0)
                return "is zero";
            else
                return "Not Zero";
        }
    }
}
