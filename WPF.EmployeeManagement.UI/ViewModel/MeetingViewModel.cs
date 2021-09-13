using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Data;
using WPF.EmployeeManagement.UI.Event;
using System.Diagnostics;
using System.Windows.Input;
using WPF.EmployeeManagement.Model.Model;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public class MeetingViewModel : ViewModelPropertyChangedNotifier, IMeetingViewModel
    {
        private readonly IMeetingDataService _meetingDataService;
        private readonly IEventAggregator _eventAggregator;

        public MeetingViewModel(IMeetingDataService meetingDataService, IEventAggregator eventAggregator)
        {
            _meetingDataService = meetingDataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Subscribe(HandleMeetingSelectedEvent);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private async void OnSaveExecute()
        {
            await _meetingDataService.SaveAsync(Meeting);
            _eventAggregator.GetEvent<AfterSavedEvent>().Publish(
                new InfoAboutChangedEntityArgs
                {
                    Id = Meeting.Id,
                    Title = Meeting.Title
                });
        }

        private async void HandleMeetingSelectedEvent(int meetingId)
        {
            Debug.WriteLine("SUBSCRIBER " + meetingId);
            await LoadMeetingById(meetingId);
        }

        public async Task LoadMeetingById(int meetingId)
        {
            Meeting = await _meetingDataService.GetMeetingById(meetingId);


        }

        private Meeting _meeting;

        public Meeting Meeting
        {
            get { return _meeting; }
            set
            {
                _meeting = value;
                OnPropertyChanged(nameof(Meeting));
            }
        }

        public ICommand SaveCommand { get; }
        
    }
}
