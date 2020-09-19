using SchoolProject.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Facade.OrganizationFacade
{
    interface IOrganizationFacade
    {
        Organizations AddNewOrganization(Organizations organization);
        Organizations EditOrganization(Organizations organization);
        Organizations DeleteOrganization(int id);
        IEnumerable<Organizations> GetAllOrganizations();
        IEnumerable<Organizations> GetAllOrganizations(int id);
    }
}
