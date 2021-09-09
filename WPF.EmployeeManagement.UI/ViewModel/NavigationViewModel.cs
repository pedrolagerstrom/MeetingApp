using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Data;
using WPF.EmployeeManagement.UI.Event;
using WPF.EmployeeManagement.UI.Model;
using WPF.EmployeeManagement.UI.WrapperClasses;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public class NavigationViewModel : ViewModelPropertyChangedNotifier, INavigationViewModel
    {
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<NavigationItemViewModel> Employees { get; }

        public NavigationViewModel(IEmployeeDataService employeeDataService, IEventAggregator eventAggregator)
        {
            _employeeDataService = employeeDataService;
            _eventAggregator = eventAggregator;
            Employees = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterSavedEvent>().Subscribe(AfterSavedEventHandler);
        }

        private void AfterSavedEventHandler(InfoAboutChangedEntityArgs obj)
        {
            var item = Employees.FirstOrDefault(e => e.Id == obj.Id);
            var itemsIndex = Employees.IndexOf(item);
            Employees[itemsIndex].DisplayMember = obj.Firstname;
        }

        public async Task LoadEmployees()
        {
            //Returnerar alla employees (Model);
            var employees = await _employeeDataService.GetEmployees();
            Employees.Clear();
            foreach (var employee in employees)
            {
                Debug.WriteLine(employee.Firstname);
                Employees.Add(new NavigationItemViewModel(employee.Id, employee.Firstname));
            }
        }

        private NavigationItemViewModel _selectedEmployee;

        public NavigationItemViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                
                OnPropertyChanged(nameof(SelectedEmployee));
                Debug.WriteLine("PUBLISHER " + _selectedEmployee.Id);
                Debug.WriteLine("PUBLISHER " + _selectedEmployee.DisplayMember);
                _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Publish(_selectedEmployee.Id);
            }
        }



    }
}
