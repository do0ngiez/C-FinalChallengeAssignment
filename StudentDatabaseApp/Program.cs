using System;

namespace StudentDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentContext())
            {
                // Create a database if it doesn't exist yet
                context.Database.EnsureCreated();

                // Add a new student
                var student = new Student
                {
                    Name = "John Doe",
                    DateOfBirth = new DateTime(2000, 1, 1), //date
                    Email = "johndoe@example.com",
                    EnrollmentDate = DateTime.Now // get the current date
                };

                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Student added to the database.");

                // Check if the student was added in the database by printing it in the console
                
                var students = context.Students.ToList(); //retrieve the students from the database

                Console.WriteLine("\nStudents in the database:");
                foreach (var s in students)
                {
                    Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}, Date of Birth: {s.DateOfBirth.ToShortDateString()}, Email: {s.Email}, Enrollment Date: {s.EnrollmentDate.ToShortDateString()}");
                }

            }
        }
    }
}
