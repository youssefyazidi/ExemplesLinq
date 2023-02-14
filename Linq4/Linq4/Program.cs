using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq4
{
    class Program
    {
   // Create a data source by using a collection initializer.
static List<Student> students = new List<Student>
{
   new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
   new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
   new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
   new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
   new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
   new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
   new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
   new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
   new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
   new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
   new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
   new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
};
  
      /*  bool (Student st)
        {
            return st.Scores[0] > 80;
        }*/

 //Score du premier test >80
  static void ScoreSup80()
      {
            //Creation de la requete
            var studentQuery =
                     from student in students
                     where student.Scores[0] > 80
                     select student;

           /* var studentQuery = students.Where(
                st => st.Scores[0]>80 
                ).Select(st=>st);*/
            //expression lambda
            //lambda = fonction anonyme 

            
     //Execution de la requete
            foreach (var student in studentQuery)
     Console.WriteLine("nom = {0}, prenom = {1}, score = {2}",
         student.Last, student.First,student.Scores[0]);
      }
        static void ScoreEntre80et90()
        {
            //Creation de la requete
            // && || !
            var studentQuery =
                     from student in students
                     where student.Scores[0] > 80 && student.Scores[0] < 90
                     select student;

            //Execution de la requete
            foreach (var student in studentQuery)
                Console.WriteLine("nom = {0}, prenom = {1}, score = {2}",
                    student.Last, student.First, student.Scores[0]);
        }

        static void ListeEtudiantsTriee()
        {
            //Creation de la requete
            // trier : ascending (default) ou descending(obligatoire)
            var studentQuery =
                     from student in students
                     orderby student.Last descending 
                     select student;

            //Execution de la requete
            foreach (var student in studentQuery)
                Console.WriteLine("nom = {0}, prenom = {1}, score = {2}",
                    student.Last, student.First, student.Scores[0]);
        }
        static void grouperEtudiantParAlphabet()
        {
            //Creation de la requete
            // trier : ascending (default) ou descending(obligatoire)
            var studentQuery =
                     from student in students
                     group student by student.Last[0] into varGroup
                     orderby varGroup.Key
                     select varGroup
                     ;

            //Execution de la requete
            foreach (var groupe in studentQuery)
            {
                Console.WriteLine(groupe.Key);
                foreach(var student in groupe)
                Console.WriteLine(
                    "   nom = {0}, prenom = {1}, score = {2}",
                    student.Last, student.First, student.Scores[0]);
            }
        }

        static void listeEtudiantsScore1supMoyenne()
        {
            //Creation de la requete
            // trier : ascending (default) ou descending(obligatoire)
            var studentQuery =
                     from student in students
                     let avg=(student.Scores[0]+ student.Scores[1]
                     + student.Scores[2]+ student.Scores[3])/4.0
                     where student.Scores[0] > avg
                     select student
                     ;

            //Execution de la requete
            foreach (var student in studentQuery)
            {
             Console.WriteLine(
              "   nom = {0}, prenom = {1}, score = {2}, moyenne = {3}",
               student.Last, student.First, student.Scores[0], 
               student.Scores.Average());
            }
        }

        static void statistiques()
        {
            //Creation de la requete
            var studentQuery1 =
                     from student in students
                     select student;
            //Execution de la requete
       // foreach (var student in studentQuery)
      Console.WriteLine("nombre des étudiants = {0}",
                    studentQuery1.Count());
       var studentQuery2 =
                 from student in students
                 select student.Scores.Average();
    Console.WriteLine("La moyenne  max  = {0}",
                    studentQuery2.Max());
   Console.WriteLine("La moyenne  min  = {0}",
                    studentQuery2.Min());

    Console.WriteLine("Le moyenne de la classe  = {0}",
                  studentQuery2.Average());

        }
        static void Main(string[] args)
        {
            statistiques();
            Console.ReadKey();
        }
    }
}
