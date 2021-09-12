using Autofac;
using Prism.Events;
using WPF.EmployeeManagement.DataAccess;
using WPF.EmployeeManagement.UI.Data;
using WPF.EmployeeManagement.UI.ViewModel;

namespace WPF.EmployeeManagement.UI
{
    public class AutoFacContainer
    {
        public IContainer Container()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<EmployeeDbContext>().AsSelf();
            builder.RegisterType<EmployeeDataService>().As<IEmployeeDataService>();

            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<EmployeeDetailViewModel>().As<IEmployeeDetailViewModel>();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MeetingViewModel>().As<IMeetingViewModel>();
            builder.RegisterType<NavMeetingViewModel>().As<INavMeetingViewModel>();

            return builder.Build();

        }
    }
}
