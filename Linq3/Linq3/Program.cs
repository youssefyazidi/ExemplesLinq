using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Le contexte LINQ 
            // un factory = les normes de codage
            // Toutes les operations sur les données
            //doivent passer oar le contexte
            //1. Source de données
            DataBiblioDataContext contexte = 
                new DataBiblioDataContext();

            contexte.Log = Console.Out;
            //2.la requete
            var query =
                from livre in contexte.Livre
                where livre.NbExemplaires > 2
                select livre;

            //3.execution

            foreach (var item in query)
            {
                Console.WriteLine(item.Titre + " : "+item.NbExemplaires);
            }

            Console.ReadKey();

         }
    }
}
