using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string PhoneNo { get; set; }

        [Column(TypeName = "varchar(200)")]
        [DisplayName("Address")]
        public string Address { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
