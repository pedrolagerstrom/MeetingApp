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
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly Func<EmployeeDbContext> _dbContext;

        public EmployeeDataService(Func<EmployeeDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            using (var context = _dbContext())
            {
                return  await context.Employees.ToListAsync();
            }
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            using(var context = _dbContext())
            {
                return await context.Employees.SingleAsync(e => e.Id == employeeId);
            }
        }

        public async Task SaveAsync(Employee employee)
        {
            using(var context = _dbContext())
            {
                //Attach Entity to Context so it is aware of the instance
                context.Employees.Attach(employee);
                //Context is aware of the Entity's existence but remains unmodified
                context.Entry(employee).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }


        public async Task<List<Meeting>> GetMeetings()
        {
            using (var context = _dbContext())
            {
                return await context.Meetings.ToListAsync();
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


        //public IEnumerable<Employee> GetEmployees()
        //{
        //    using (var context = _dbContext)
        //    {
        //        return context.Employees.ToList();
        //    }
        //}



        //public IEnumerable<Employee> GetEmployees()
        //{
        //    yield return new Employee { Id = 1, Firstname = "Rafael", Lastname = "Milanes", Email = "johnny@gmail.com", Department = Department.IT };
        //    yield return new Employee { Id = 2, Firstname = "Johnny", Lastname = "Cage", Email = "Juan@gmail.com", Department = Department.IT };
        //    yield return new Employee { Id = 3, Firstname = "Anna", Lastname = "Lindgren", Email = "Anna@gmail.com", Department = Department.Agriculture };
        //    yield return new Employee { Id = 4, Firstname = "Juanete", Lastname = "Pérez", Email = "John@gmail.com", Department = Department.Education };
        //    yield return new Employee { Id = 5, Firstname = "New", Lastname = "SuperNew", Email = "new@gmail.com", Department = Department.Education };
        //}

    }
}
