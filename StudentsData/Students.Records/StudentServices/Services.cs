using Students.Records.ServiceInterfaces;
using Students.Records.StudentDtos;
using Students.Records.StudentModel;
using Students.Records.StudentRepo;

namespace Students.Records.StudentServices
{
    public class Services(StudentData studentData) : IServices
    {
        private int studentID = 1;
        public void AddStudent(AddStudentDto newStudent)
        {
            var addStudent = new Student
            {
                Id = studentID++,
                Name = newStudent.Name,
                Age = newStudent.Age,
                Grade = newStudent.Grade,
            };

            studentData.studentsData.Add(addStudent);
        }
        public void UpdateStudent(UpdateStudentDto updatedStudent, int id)
        {
            var student = studentData.studentsData.FirstOrDefault(s => s.Id == id);
            if (student is null)
            {
                Console.WriteLine($"No student with Id:{id} found");
                return;
            }
            else
            {
                student.Id = id;
                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.Grade = updatedStudent.Grade;
            }
        }
        public void DeleteStudent(int id)
        {
            var student = studentData.studentsData.FirstOrDefault(s => s.Id == id);

            if (student is null)
            {
                Console.WriteLine($"No student with Id:{id} found");
            }
            else
            {
                studentData.studentsData.Remove(student);
                Console.WriteLine("Student removed successfully.");
            }
        }
        public void ViewStudent(int? id)
        {
            var student = studentData.studentsData.FirstOrDefault(s => s.Id == id);

            if (student is null || id is null)
            {
                foreach (var studentData in studentData.studentsData)
                {
                    Console.WriteLine($"Student ID : {studentData.Id}");
                    Console.WriteLine($"Name       : {studentData.Name}");
                    Console.WriteLine($"Age        : {studentData.Age}");
                    Console.WriteLine($"Grade      : {studentData.Grade}");
                    Console.WriteLine("=======================");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Student ID : {student.Id}");
                Console.WriteLine($"Name       : {student.Name}");
                Console.WriteLine($"Age        : {student.Age}");
                Console.WriteLine($"Grade      : {student.Grade}");
                Console.WriteLine("=======================");

            }

        }
    }
}
