using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeOrg.Data.Entities
{
    public class Organization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int ID { get; set; }

       
        public string? OrgName { get; set; }

        //cross reference : every organization must have a employeeid/emp
        public Employee? Employee { get; set; }
    }
}
