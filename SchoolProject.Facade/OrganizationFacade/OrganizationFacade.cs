using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolProject.DataAccess;
using SchoolProject.DataAccess.Model;

namespace SchoolProject.Facade.OrganizationFacade
{
    public class OrganizationFacade:IOrganizationFacade
    {
        ISchoolDBContext _context;

        public Organizations AddNewOrganization(Organizations organization)//We can add a new organization
        {
            try
            {
                var result = _context.Organization.Add(organization);
                _context.SaveChanges();
                return result.Entity;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
        public Organizations EditOrganization(Organizations organization)//We can update an organization
        {
            try
            {
                var _organization = _context.Organization.Where(a => a.Id == organization.Id).FirstOrDefault();
                if (_organization != null)
                {
                    _context.Entry(_organization).State = EntityState.Modified;
                    _context.SaveChanges();
                    return _organization;
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
        public Organizations DeleteOrganization(int id)//We can delete an organization
        {
            try
            {
                var _organization = _context.Organization.Where(a => a.Id == id).FirstOrDefault();
                if (_organization != null)
                {
                    _context.Entry(_organization).State = EntityState.Deleted;
                    _context.SaveChanges();
                    return _organization;
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
        public IEnumerable<Organizations> GetAllOrganizations()//We can see all organizations
        {
            try
            {
                var result = _context.Organization
                    .Select(a => new Organizations
                    {
                        Id = a.Id,
                        Name = a.Name
                    })
                    .OrderBy(a => a.Name).ToList();
                return result;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
        public IEnumerable<Organizations> GetAllOrganizations(int id)
        {
            try
            {
                var result = _context.Organization.Where(a => a.Id == id)
                    .Select(a => new Organizations
                    {
                        Id = a.Id,
                        Name = a.Name
                    })
                    .OrderBy(a => a.Name).ToList();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
        public Organizations GetOrganizationIByName(string Name)
        {
            try
            {
                var result = _context.Organization.Where(a => a.Name == Name)
                    .Select(a => new Organizations
                    {
                        Id = a.Id
                    }).FirstOrDefault();
                    
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

    }
}
