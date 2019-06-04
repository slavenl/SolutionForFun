using System.ComponentModel.DataAnnotations;

namespace WebApiService.Contracts.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public EmployeeData EmployeeData { get; set; }
    }

    public class EmployeeData
    {

        public int EmployeeDataId { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Gender { get; set; }

        public int EmployeeId { get; set; }

    }

}
