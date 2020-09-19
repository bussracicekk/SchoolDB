using Microsoft.EntityFrameworkCore;
using SchoolProject.DataAccess;
using SchoolProject.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolProject.Facade.StudentFacade
{
    public class StudentFacade:IStudentFacade
    {
        ISchoolDBContext _context;

        public Students AddNewStudent(Students student)//We can add a new student
        {
            try
            {
                var result = _context.Student.Add(student);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
        public Students EditStudent(Students student)//We can edit a student
        {
            try
            {
                var _student = _context.Student.Where(a => a.Id == student.Id).FirstOrDefault();
                if (_student != null)
                {
                    _context.Entry(_student).State = EntityState.Modified;
                    _context.SaveChanges();
                    return _student;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
        public Students DeleteStudent(int id)//We can delete a student
        {
            try
            {
                var _student = _context.Student.Where(a => a.Id == id).FirstOrDefault();
                if (_student != null)
                {
                    _context.Entry(_student).State = EntityState.Deleted;
                    _context.SaveChanges();
                    return _student;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }

        }
        public IEnumerable<Students> GetAllStudents()//We can see all students
        {
            try
            {
                var result = _context.Student
                    .Select(a => new Students
                    {
                        Id = a.Id,
                        NameSurname = a.NameSurname,
                        OrganizationId = a.OrganizationId
                    })
                    .OrderBy(a => a.NameSurname).ToList();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        public IEnumerable<Students> GetAllStudents(int id)
        {
            try
            {
                var result = _context.Student.Where(a => a.Id == id)
                    .Select(a => new Students
                    {
                        Id = a.Id,
                        NameSurname = a.NameSurname,
                        OrganizationId = a.OrganizationId
                    })
                    .OrderBy(a => a.NameSurname).ToList();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
    }
}
