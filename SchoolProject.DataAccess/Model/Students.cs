using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.DataAccess.Model
{
    public class Students
    {
        [Key]
        public int Id { get; set; }//Primary Key
        public string NameSurname { get; set; }
        public int OrganizationId { get; set; }//Foreign Key
        public Organizations Organization { get; set; }
    }
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.HasOne(navigationExpression: o => o.Organization)
                .WithMany(navigationExpression: s => s.Students)
                .HasForeignKey(i => i.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
