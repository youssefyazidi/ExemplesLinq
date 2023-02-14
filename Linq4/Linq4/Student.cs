using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq4
{
    //Classe entité (regroupe des infos)
   public  class Student
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public List<int> Scores { get; set; }
    }
}
