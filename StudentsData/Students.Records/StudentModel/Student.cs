using System;

namespace Students.Records.StudentModel
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Grade { get; set; }

    }
}
