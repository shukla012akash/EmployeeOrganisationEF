using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeOrg.Data.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]

        public int ID { get; set; }

        
        public string? Name { get; set; }

        public string? Address { get; set; }

        public ICollection<Organization> OrganizationList { get; set; }
    }
}
