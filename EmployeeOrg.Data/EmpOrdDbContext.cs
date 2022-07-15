using EmployeeOrg.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeOrg.Data
{
    public class EmpOrdDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public EmpOrdDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0LKSRK2;Database=EmporgDB;Trusted_Connection=True;");
        }

    }
}