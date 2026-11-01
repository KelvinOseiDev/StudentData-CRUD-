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
            string? newName, newAge, newGrade;
            int _newAge, _newFlagGrade;

            Console.WriteLine("Add New Student");
            Console.WriteLine("---------------");
            while (true) { Console.Write("Name : "); newName = Console.ReadLine(); if (string.IsNullOrEmpty(newName)) continue; break; }
            while (true) { Console.Write("Age : "); newAge = Console.ReadLine(); if (string.IsNullOrEmpty(newAge) || !(int.TryParse(newAge, out _newAge))) { Console.WriteLine("Enter a valid number."); continue; } break; }
            while (true) { Console.Write("Grade : "); newGrade = Console.ReadLine(); if (string.IsNullOrEmpty(newGrade) || int.TryParse(newGrade, out _newFlagGrade)) { Console.WriteLine("Enter a valid grade."); continue; }; break; }

            var newStudent = new AddStudentDto
            {
                Name = newName,
                Age = _newAge,
                Grade = newGrade
            };

            services.AddStudent(newStudent);
            Console.WriteLine("Student added successfully.");
        break;

        case "2":
            string? updateName, updateAge, updateGrade, id;
            int _updateAge, _updateFlagGrade, _validId;

            Console.Write("Enter student ID: "); id = Console.ReadLine();

            if (int.TryParse(id, out _validId))
            {
                Console.WriteLine($"Enter a valid id");
                continue;
            }

            Console.WriteLine("Update Student Details");
            Console.WriteLine("----------------------");
            while (true) { Console.Write("Name : "); updateName = Console.ReadLine(); if (string.IsNullOrEmpty(updateName)) continue; break; }
            while (true) { Console.Write("Age : "); updateAge = Console.ReadLine(); if (string.IsNullOrEmpty(updateAge) || !(int.TryParse(updateAge, out _updateAge))) { Console.WriteLine("Enter a valid number."); continue; } break; }
            while (true) { Console.Write("Grade : "); updateGrade = Console.ReadLine(); if (string.IsNullOrEmpty(updateGrade) || int.TryParse(updateGrade, out _updateFlagGrade)) { Console.WriteLine("Enter a valid grade."); continue; }; break; }

            var updatedStudent = new UpdateStudentDto
            {
                Name = updateName,
                Age = _updateAge,
                Grade = updateGrade
            };

            services.UpdateStudent(updatedStudent,_validId);
            Console.WriteLine("Student updated successfully.");
        break;
    }
    
}
while (option != "5");

