using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleApp1
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {

            Console.WriteLine(ConfigurationSettings.AppSettings["Name"].ToString());

            Console.ReadKey();
            



        }
    }
}
