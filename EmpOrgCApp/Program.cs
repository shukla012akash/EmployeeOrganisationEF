using EmployeeOrg;
using EmployeeOrg.Data;
using EmployeeOrg.Data.Entities;

public class Program
{
   public static  CRUDManager crud = new CRUDManager();
    public static void Main()
    {


        //One to many: An employee id can have more then one organization values
        //Insert crud-operation
        #region First-approach

        //Employee employee = new Employee { Name = "Akash", Address = "LKO" };

        //List<Organization> orgList = new List<Organization>();
        //orgList.Add(new Organization
        //{
        //    OrgName = "Cognizant",
        //    //passing the employee object also when we try to save data in Organizations Table
        //    Employee = employee
        //});
        //orgList.Add(new Organization
        //{
        //    OrgName = "TCS",
        //    Employee = employee
        //});

        //crud.InsertInOrgs(orgList);
        #endregion





      //  update employee with organizationslist

        List<Organization> OrgList = new List<Organization>();
        OrgList.Add(new Organization { OrgName = "Accenture" });
        OrgList.Add(new Organization { OrgName = "Citymall" });
        OrgList.Add(new Organization { OrgName = "Spacex" });

        crud.UpdateEmpOrgs(3, new Employee { Name = "Abhay", Address = "Sitapur" }, OrgList);
        Console.ReadKey();


       // delete crud
       // crud.DeleteImpOrg(6);


    }

    public static void ShowAllEmpOrgsDetails()
    {
        foreach(Employee item in crud.ReadEmployeeWithOrgs())
        {
            Console.Write($"EId: {item.ID}\tEName: {item.Name}\tEAddress: {item.Address}\t");
            foreach(Organization Oitem in item.OrganizationList)
            {
                Console.WriteLine($"OId: {Oitem.ID}\tOName: {Oitem.OrgName}");
            }
        }
    }
}
