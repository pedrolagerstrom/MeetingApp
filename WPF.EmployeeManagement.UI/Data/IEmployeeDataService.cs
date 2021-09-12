using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.Model.Model;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.Data
{
    public interface IEmployeeDataService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int employeeId);
        Task SaveAsync(Employee employee);

        Task<List<Meeting>> GetMeetings();
        Task<Meeting> GetMeetingById(int meetingId);
        Task SaveAsync(Meeting meeting);
    }
}
