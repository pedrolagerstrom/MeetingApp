using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.Model.Model;
using WPF.EmployeeManagement.UI.Model;
using WPF.EmployeeManagement.UI.ViewModel;

namespace WPF.EmployeeManagement.UI.WrapperClasses
{
    public class MeetingWrapper : ViewModelPropertyChangedNotifier
    {
        public Meeting Model { get; }
        public MeetingWrapper(Meeting model)
        {
            Model = model;
        }

        public int Id { get { return Model.Id; } }
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public DateTime StartDate { get; set; }        
        public DateTime EndDate { get; set; }
        public ICollection<Employee> EmployeesAttendingMeeting { get; set; }
    }
}
