using System;

namespace API.Dtos
{
    public class EmployeeToReturnDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }

        public string CompanyName { get; set; }
    }
}
