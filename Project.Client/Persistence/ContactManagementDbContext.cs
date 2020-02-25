using Microsoft.EntityFrameworkCore;
using Project.Client.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Client.Persistence
{
    public sealed class ContactManagementDbContext: DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=RATANA;Initial Catalog=contact_management;User ID=sa");
        }
    }
}
