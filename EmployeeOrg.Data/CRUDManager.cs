using EmployeeOrg.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeOrg.Data
{
    public class CRUDManager
    {
        EmpOrdDbContext empOrdDbContext = new EmpOrdDbContext();

        #region ORGANIZATION-CRUD

       // first-approach to insert data
        public void InsertInOrgs(List<Organization> OrgList)
        {
            empOrdDbContext.Organizations.AddRange(OrgList);
            empOrdDbContext.SaveChanges();
        }

        //second approach 

        //public void InsertInOrgs(Employee employee, List<Organization> OrgList)
        //{

        //    var objEmployee = new Employee
        //    {
        //        Name = employee.Name,
        //        Address = employee.Address,
        //        OrganizationList = OrgList

        //    };
        //    empOrdDbContext.Employees.Add(objEmployee);
        //    empOrdDbContext.SaveChanges();
        //}

        #endregion

        //Read crud-operation
        public List<Employee> ReadEmployeeWithOrgs()
        {
            var listItem = empOrdDbContext.Employees.Include(emp => emp.OrganizationList).ToList();
            return listItem;
        }

        //Update crud operation

        public void UpdateEmpOrgs(int employeeId, Employee employee, List<Organization> UpdatedList)
        {
            var eachEmployee = empOrdDbContext.Employees.Where(emp => emp.ID == employeeId).Include(empProps => empProps.OrganizationList).First(); 
            if(eachEmployee != null)
            {
                eachEmployee.Name = employee.Name;
                eachEmployee.Address = employee.Address;
                eachEmployee.OrganizationList = UpdatedList;
            }
            else
            {
                Console.WriteLine("Cann't find employee id.");
            }
            empOrdDbContext.Employees.Update(eachEmployee);
            empOrdDbContext.SaveChanges();
        }

        public void DeleteImpOrg(int empId)
        {
            var removeEmp = empOrdDbContext.Employees.Where(emp => emp.ID == empId).Include(empProp => empProp.OrganizationList).First();
            if (removeEmp != null)
            {
                empOrdDbContext.Employees.Remove(removeEmp);
                removeEmp.OrganizationList.Clear();
                empOrdDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"No Record Found With This Id : {empId}");
            }
        }
    } 
}