using System;
using System.Collections.Generic;
using System.Text;
using SchoolProject.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

/*Summary
 * This is a code first project
 * when you make a migration, will be create a database as SchoolDB
 * and this database has two table as students and organizations
 * students has a foreign key for organizations table.
 */
 /*
  *For migration we should use SchoolDBContext... example: Add-Migration SchoolDBContext
  */
namespace SchoolProject.DataAccess
{
    public class SchoolDBContext: DbContext, ISchoolDBContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public override int SaveChanges()
        {
            var x = base.SaveChanges();
            return x;
        }
        public DbSet<Students> Student { get; set; }//Students Table
        public DbSet<Organizations> Organization { get; set; }//Organizations Table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
        }
    }
}
