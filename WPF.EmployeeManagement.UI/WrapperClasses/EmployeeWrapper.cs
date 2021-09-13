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
    public class EmployeeWrapper : ViewModelPropertyChangedNotifier
    {
        public Employee Model { get; }
        public EmployeeWrapper(Employee model)
        {
            Model = model;
        }

        public int Id { get { return Model.Id; } }
        private string _firstname;

        public string Firstname
        {
            get { return _firstname; }
            set { 
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
                
            }
        }

        public string Lastname { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public Meeting Meeting { get; set; }


    }
}
