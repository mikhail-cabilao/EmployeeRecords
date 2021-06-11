using EmployeeRecords.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.Data
{
    public static class DataSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData
                (
                    new Employee { Id = 1, FirstName = "Juan", MiddleName = "Tamad", LastName = "Dela Cruz" },
                    new Employee { Id = 2, FirstName = "Pedro", MiddleName = "Tamad", LastName = "De Lion" }
                );
        }
    }
}
