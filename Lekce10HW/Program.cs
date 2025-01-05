using System.Collections.Generic;

namespace Lekce10HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Edward", "Fiona", "George", "Hannah", "Ian", "Julia" };

            var students = new List <Student>();
            
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

        }
    }
}
