﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.EmployeeManagement.UI.ViewModel
{
    public interface IMeetingViewModel
    {
        Task LoadMeetingById(int meetingId);
    }
}
