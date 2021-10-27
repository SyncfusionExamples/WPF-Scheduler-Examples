using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace TimeIntervalAndTimeIntervalHeight
{
    public class SchedulerViewModel : NotificationObject
    {
        public SchedulerViewModel()
        {
            Events = GenerateRandomAppointments();
            DisplayDate = DateTime.Now.Date.AddHours(9);
        }

        private ScheduleAppointmentCollection events;

        public ObservableCollection<string> CalendarTypes { get; set; }

        public DateTime DisplayDate { get; set; }

        public ScheduleAppointmentCollection Events
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyChanged("Events");
            }
        }

        private ScheduleAppointmentCollection GenerateRandomAppointments()
        {
            var WorkWeekSubjects = new ObservableCollection<string>()
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Project Status Discussion",
                                                             "Auditing", "Client Meeting", "Generate Report", "Target Meeting", "General Meeting" };

            var brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromRgb(133, 81, 242)));
            brush.Add(new SolidColorBrush(Color.FromRgb(140, 245, 219)));
            brush.Add(new SolidColorBrush(Color.FromRgb(83, 99, 250)));
            brush.Add(new SolidColorBrush(Color.FromRgb(255, 222, 133)));
            brush.Add(new SolidColorBrush(Color.FromRgb(45, 153, 255)));
            brush.Add(new SolidColorBrush(Color.FromRgb(253, 183, 165)));
            brush.Add(new SolidColorBrush(Color.FromRgb(198, 237, 115)));
            brush.Add(new SolidColorBrush(Color.FromRgb(253, 185, 222)));
            brush.Add(new SolidColorBrush(Color.FromRgb(255, 222, 133)));

            Random ran = new Random();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
                today = today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
                today = today.AddMonths(1);
            }

            DateTime startMonth = new DateTime(today.Year, today.Month - 1, 1, 0, 0, 0);
            int day = (int)startMonth.DayOfWeek;
            DateTime CurrentStart = startMonth.AddDays(-day);
            var appointments = new ScheduleAppointmentCollection();

            for (int i = 0; i < 50; i++)
            {
                DateTime date = CurrentStart.AddDays(i).Date.AddHours(ran.Next(9, 17));
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[i % brush.Count],
                    Subject = WorkWeekSubjects[i % WorkWeekSubjects.Count]
                });
            }

            return appointments;
        }
    }
}