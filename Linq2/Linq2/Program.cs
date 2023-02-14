using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Source de données
            XElement livres = XElement.Load(@"D:\d1\books.xml");

            //2. Creation de la requete
            var query = from element in livres.Elements()
                        let nom = element.Element("auteur")
                        where (double)element.Element("price") < 1000
                        select element.Element("titre");

            //3. execution de la requete

            foreach(var item in query)
            {
                Console.WriteLine(item.Value);
            }

            Console.ReadKey();
        }
    }
}
