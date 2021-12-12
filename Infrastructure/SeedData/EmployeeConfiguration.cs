using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.SeedData
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Employee 1",
                    Age = 21,
                    Position = "Tester",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Employee
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4b"),
                    Name = "Employee 2",
                    Age = 22,
                    Position = "Developer",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991871")
                },
                new Employee
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4c"),
                    Name = "Employee 3",
                    Age = 23,
                    Position = "Project Manager",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991873")
                });
        }
    }
}
