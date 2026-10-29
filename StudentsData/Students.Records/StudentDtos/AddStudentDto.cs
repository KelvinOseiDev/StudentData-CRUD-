using System;

namespace Students.Records.StudentDtos
{
    public class AddStudentDto
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Grade { get; set; }
    }
}
