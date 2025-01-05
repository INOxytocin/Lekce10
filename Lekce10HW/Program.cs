using System.Collections.Generic;

namespace Lekce10HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Úkol2 - Výchozí kód
            var random = new Random();
            var names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Edward", "Fiona", "George", "Hannah", "Ian", "Julia" };

            var students = new List<Student>();

            for (int i = 0; i < 100; i++)
            {

                var student = new Student
                {
                    Name = names[random.Next(names.Count)] + i,
                    Age = random.Next(18, 25),
                    Grades = new List<int>
                    {
                        random.Next(20, 100),
                        random.Next(50, 100),
                        random.Next(70, 100)
                    }
                };
                students.Add(student);


            }

            //Úkol3 - LINQ metody
            Console.WriteLine("A)___________________________________________________________________________________________");
            // a)
            List<string> studentNames = students.Select(student => student.Name).ToList();
            foreach (var name in studentNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("B)___________________________________________________________________________________________");
            // b)
            List<Student> excelentStudents = students.Where(student => student.Grades.Any(grade => grade >= 90)).ToList();
            foreach (Student student in excelentStudents)
            {
                Console.WriteLine(student.Name);
                foreach (var grade in student.Grades)
                {
                    Console.WriteLine(grade);
                }
            }
            Console.WriteLine("C)___________________________________________________________________________________________");

            // c) - Radši bych použil .All, ale tohle je alespoň elegantní
            foreach (Student student in students)
            {
                if (!student.Grades.Any(grade => grade < 90))
                {
                    Console.WriteLine(student.Name);
                    foreach (int grade in student.Grades)
                    {
                        Console.WriteLine(grade);
                    }
                }
            }
            Console.WriteLine("D)___________________________________________________________________________________________");
            // d)
            List<int> allGrades = students.SelectMany(student => student.Grades).ToList();
            foreach (int grade in allGrades)
            {
                Console.WriteLine(grade);
            }
            Console.WriteLine("\nJsou zde skutečně všechny známky?? Zde je count. Pokud jich je 300, tak je vše OK" +
                              "\nCount = " + allGrades.Count);
            Console.WriteLine("E)___________________________________________________________________________________________");
            // e)
            List<Student> studentsOrderedByAge = students.OrderBy(student => student.Age).ToList();
            foreach (Student student in studentsOrderedByAge)
            {
                Console.WriteLine(student.Name + " " + student.Age);
            }
        }
    }
}