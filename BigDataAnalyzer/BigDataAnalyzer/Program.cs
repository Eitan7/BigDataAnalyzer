using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;

namespace BigDataAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string m = System.Configuration.ConfigurationManager.AppSettings["Setting1"];
                Mongo x = new Mongo();
                x.Find();
                Thread.Sleep(10000);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Terminate with exception {0}", ex.Message);
            }
        }
    }
}
