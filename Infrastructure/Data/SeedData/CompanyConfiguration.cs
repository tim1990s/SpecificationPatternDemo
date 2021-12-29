using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.SeedData
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Company Name 1",
                    Address = "Address 1",
                    Country = "Country 1"
                },
                new Company
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991871"),
                    Name = "Company Name 2",
                    Address = "Address 2",
                    Country = "Country 2"
                },
                new Company
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991873"),
                    Name = "Company Name 3",
                    Address = "Address 3",
                    Country = "Country 3"
                },
                new Company
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991874"),
                    Name = "Company Name 4",
                    Address = "Address 4",
                    Country = "Country 3"
                });
        }
    }
}
