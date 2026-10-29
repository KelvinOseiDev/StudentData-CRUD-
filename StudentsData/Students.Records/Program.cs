// See https://aka.ms/new-console-template for more information

using Students.Records.Menu;
using Students.Records.ServiceInterfaces;
using Students.Records.StudentDtos;
using Students.Records.StudentRepo;
using Students.Records.StudentServices;

StudentData studentData = new StudentData();
IServices services = new Services(studentData);

string? option;
int _option;
do
{
    Menu.DisplayMenu();
    while (true)
    {
        Console.Write("Select an option: "); option = Console.ReadLine();
        if (string.IsNullOrEmpty(option))
            continue;

        if (!(int.TryParse(option, out _option))) { Console.WriteLine($"Enter a valid number (1 - 5)"); continue; }
            
        break;
    }

    Console.WriteLine();

    switch (option)
    {
        case "1":
            string? name, age, grade;
            int _age, _flagGrade;
            Console.WriteLine("Add New Student");
            Console.WriteLine("---------------");
            while (true) { Console.Write("Name : "); name = Console.ReadLine(); if (string.IsNullOrEmpty(name)) continue; break; }
                while (true) { Console.Write("Age : "); age = Console.ReadLine(); if (string.IsNullOrEmpty(age) || !(int.TryParse(age, out _age))) { Console.WriteLine("Enter a valid number."); continue; } break; }
                    while (true) { Console.Write("Grade : "); grade = Console.ReadLine(); if (string.IsNullOrEmpty(grade) || int.TryParse(grade, out _age)) { Console.WriteLine("Enter a valid grade."); continue; }; break; }

            var newStudent = new AddStudentDto
            {
                Name = name,
                Age = int.Parse(age),
                Grade = grade
            };

            services.AddStudent(newStudent);
            Console.WriteLine("Student added successfully.");
        break;
    }
    
}
while (option != "5");

