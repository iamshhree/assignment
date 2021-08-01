using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLib
{
    public class Class1
    {
        public void Sample()
        {

             string a = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; 

        }
    }
}
