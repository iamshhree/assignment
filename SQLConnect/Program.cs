using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            Console.ReadKey();
        }
    }
}
