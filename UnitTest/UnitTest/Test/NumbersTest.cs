using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Test
{
    public class NumbersTest
    {
        public static void Numbers_CheckNumber_ReturnString()
        {
            try
            {
                //Arrange
                Numbers numbers = new Numbers();
                int num = 0;

                //Act
                string Result = numbers.CheckNumber(num);

                //Asset
                if (Result == "is zero")
                {
                    Console.WriteLine("PASSED: Numbers_CheckNumber_ReturnString");
                }
                else
                {
                    Console.WriteLine("FAIL: Numbers_CheckNumber_ReturnString");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
