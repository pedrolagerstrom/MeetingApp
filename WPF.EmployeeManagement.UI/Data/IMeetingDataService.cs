using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.Model.Model;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.Data
{
    public interface IMeetingDataService
    {
        Task<IEnumerable<Meeting>> GetMeetings();
        Task<Meeting> GetMeetingById(int meetingId);
        Task SaveAsync(Meeting meeting);
        Task AddEmployeeToMeeting(Meeting meeting, Employee employee);
    }
}
