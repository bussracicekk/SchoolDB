using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolProject.DataAccess.Model
{
    public class Organizations
    {
        [Key]
        public int Id { get; set; }//Primary Key
        public string Name { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}
