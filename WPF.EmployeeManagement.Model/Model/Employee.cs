using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WPF.EmployeeManagement.Model.Model;

namespace WPF.EmployeeManagement.UI.Model
{
    public class Employee
    {

        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public Department Department { get; set; }
        public Meeting Meeting { get; set; }



    }
}
