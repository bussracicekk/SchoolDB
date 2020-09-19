using SchoolProject.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Facade.StudentFacade
{
    interface IStudentFacade
    {
        Students AddNewStudent(Students student);
        Students EditStudent(Students student);
        Students DeleteStudent(int id);
        IEnumerable<Students> GetAllStudents();
        IEnumerable<Students> GetAllStudents(int id);

    }
}
