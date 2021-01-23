using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace BorWCF_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(BorWCF_Szerver.BorService)))
            {
                host.Open();
                Console.WriteLine("Szerver elindult ekkor: "+DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
