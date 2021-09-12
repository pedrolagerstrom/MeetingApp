using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.Model.Model
{
    public class Meeting
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Employee> EmployeesAttendingMeeting { get; set; }
    }
}
