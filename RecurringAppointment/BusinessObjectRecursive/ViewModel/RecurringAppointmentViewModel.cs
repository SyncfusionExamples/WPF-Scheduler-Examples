using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BusinessObjectRecursive
{
    public class RecurringAppointmentViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleViewModel" /> class.
        /// </summary>
        public RecurringAppointmentViewModel()
        {
            SelectedDate = DateTime.Now.Date.AddHours(9);
            this.CreateRecurrsiveAppointments();
        }

        /// <summary>
        /// Gets or sets recursive appointments.
        /// </summary>
        public ObservableCollection<Event> RecursiveAppointmentCollection { get; set; }

        public DateTime SelectedDate { get; set; }

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveAppointments()
        {
            this.RecursiveAppointmentCollection = new ObservableCollection<Event>();

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            Event dailyEvent = new Event
            {
                EventName = "Daily recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                Color = new SolidColorBrush((Color.FromArgb(255, 191, 235, 97))),
                ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=100",
            };

            RecursiveAppointmentCollection.Add(dailyEvent);

            Event weeklyEvent = new Event
            {
                EventName = "Weekly recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                Color = new SolidColorBrush((Color.FromArgb(255, 45, 216, 175))),
                ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,WE,FR;INTERVAL=1;COUNT=20",
            };

            RecursiveAppointmentCollection.Add(weeklyEvent);

            Event monthlyEvent = new Event
            {
                EventName = "Monthly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 14, 0, 0),
                Color = new SolidColorBrush(Color.FromArgb(255, 253, 183, 165)),
                RecurrenceRule = "FREQ=MONTHLY;BYDAY=TU;BYSETPOS=1;INTERVAL=1;COUNT=50",
            };

            RecursiveAppointmentCollection.Add(monthlyEvent);

            Event yearlyEvent = new Event
            {
                EventName = "Yearly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 2, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 3, 0, 0),
                Color = new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)),
                RecurrenceRule = "FREQ=YEARLY;BYMONTHDAY=3;BYMONTH=5;INTERVAL=1;COUNT=50",
            };

            RecursiveAppointmentCollection.Add(yearlyEvent);
        }
    }
}
