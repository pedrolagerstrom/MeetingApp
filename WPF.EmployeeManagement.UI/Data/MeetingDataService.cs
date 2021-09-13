using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.DataAccess;
using WPF.EmployeeManagement.Model.Model;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.UI.Data
{
    public class MeetingDataService : IMeetingDataService
    {
        private readonly Func<EmployeeDbContext> _dbContext;
        public MeetingDataService(Func<EmployeeDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Meeting>> GetMeetings()
        {
            using (var context = _dbContext())
            {
                return await context.Meetings.Include(e => e.EmployeesAttendingMeeting).ToListAsync();
            }
        }

        public async Task<Meeting> GetMeetingById(int meetingId)
        {
            using (var context = _dbContext())
            {
                return await context.Meetings.SingleAsync(m => m.Id == meetingId);
            }
        }

        public async Task SaveAsync(Meeting meeting)
        {
            using (var context = _dbContext())
            {
                //Attach Entity to Context so it is aware of the instance
                context.Meetings.Attach(meeting);
                //Context is aware of the Entity's existence but remains unmodified
                context.Entry(meeting).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task AddEmployeeToMeeting(Meeting meeting, Employee employee)
        {
            using (var context = _dbContext())
            {
                var employeeEntity = context.Employees.Include(e => e.Meeting).First(e => e == employee);
                var meetingEntity = context.Meetings.Include(m => m.EmployeesAttendingMeeting).First(m => m == meeting);

                try
                {
                    meetingEntity.EmployeesAttendingMeeting.Add(employeeEntity);
                    await context.SaveChangesAsync();
                }
                catch { return; }
            }
            
        }


    }
}
