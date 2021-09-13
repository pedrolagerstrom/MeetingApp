using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.UI.Data;
using WPF.EmployeeManagement.UI.Event;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public class NavMeetingViewModel : ViewModelPropertyChangedNotifier, INavMeetingViewModel
    {
        private readonly IMeetingDataService _meetingDataService;
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<NavigationItemViewModel> Meetings { get; }

        public NavMeetingViewModel(IMeetingDataService meetingDataService, IEventAggregator eventAggregator)
        {
            _meetingDataService = meetingDataService;
            _eventAggregator = eventAggregator;
            Meetings = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterSavedEvent>().Subscribe(AfterSavedEventHandler);
        }

        private void AfterSavedEventHandler(InfoAboutChangedEntityArgs obj)
        {
            var item = Meetings.FirstOrDefault(m => m.Id == obj.Id);
            var itemsIndex = Meetings.IndexOf(item);
            Meetings[itemsIndex].DisplayMember = obj.Title;
        }

        public async Task LoadMeetings()
        {
            var meetings = await _meetingDataService.GetMeetings();
            Meetings.Clear();
            foreach (var meeting in meetings)
            {
                Debug.WriteLine(meeting.Title);
                Meetings.Add(new NavigationItemViewModel(meeting.Id, meeting.Title));
            }
        }

        private NavigationItemViewModel _selectedMeeting;

        public NavigationItemViewModel SelectedMeeting
        {
            get { return _selectedMeeting; }
            set
            {
                _selectedMeeting = value;

                OnPropertyChanged(nameof(SelectedMeeting));
                Debug.WriteLine("PUBLISHER " + _selectedMeeting.Id);
                Debug.WriteLine("PUBLISHER " + _selectedMeeting.DisplayMember);
                _eventAggregator.GetEvent<OpenObjectDetailsEvent>().Publish(_selectedMeeting.Id);
            }
        }
    }
}
