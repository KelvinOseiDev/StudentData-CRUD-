using Students.Records.StudentDtos;
using System;

namespace Students.Records.ServiceInterfaces
{
    public interface IServices
    {
        void AddStudent(AddStudentDto newStudent);
        void UpdateStudent(UpdateStudentDto updatedStudent, int id);
        void DeleteStudent(int id);
        void ViewStudent(int? id);
    }
}
