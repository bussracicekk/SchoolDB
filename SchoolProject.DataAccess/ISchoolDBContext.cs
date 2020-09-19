using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolProject.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.DataAccess
{
    public interface ISchoolDBContext
    {
        public DbSet<Students> Student { get; set; }//Students Table
        public DbSet<Organizations> Organization { get; set; }//Organizations Table

        int SaveChanges();
        EntityEntry Entry(object entity);
    }
}
