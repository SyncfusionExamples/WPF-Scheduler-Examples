using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BusinessObject_Exception
{
    public class SchedulerViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleViewModel" /> class.
        /// </summary>
        public SchedulerViewModel()
        {
            SelectedDate = DateTime.Now.Date.AddHours(9);
            this.CreateRecurrsiveExceptionAppointments();
        }

        /// <summary>
        /// Gets or sets recursive exception appointments.
        /// </summary>
        public ObservableCollection<Event> RecursiveExceptionAppointmentCollection { get; set; }

        public DateTime SelectedDate { get; set; }

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveExceptionAppointments()
        {
            this.RecursiveExceptionAppointmentCollection = new ObservableCollection<Event>();

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            Event dailyEvent = new Event
            {
                EventName = "Daily scrum meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                Color = Brushes.RoyalBlue,
                ForegroundColor = Brushes.White,
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=50",
                Id = 1
            };

            RecursiveExceptionAppointmentCollection.Add(dailyEvent);

            //Add ExceptionDates to avoid occurrence on specific dates.
            DateTime changedExceptionDate1 = DateTime.Now.AddDays(-1).Date;
            DateTime changedExceptionDate2 = DateTime.Now.Date.AddDays(4).Date;
            DateTime deletedExceptionDate1 = DateTime.Now.Date.AddDays(2);
            DateTime deletedExceptionDate2 = DateTime.Now.Date.AddDays(6);
            DateTime deletedExceptionDate3 = DateTime.Now.Date.AddDays(8);

            dailyEvent.RecurrenceExceptions = new ObservableCollection<DateTime>()
            {
                changedExceptionDate1,
                changedExceptionDate2,
                deletedExceptionDate1,
                deletedExceptionDate2,
            };

            //Change start time or end time of an occurrence.
            Event changedEvent = new Event
            {
                EventName = "Scrum meeting - Changed Occurrence",
                From = new DateTime(changedExceptionDate1.Year, changedExceptionDate1.Month, changedExceptionDate1.Day, 12, 0, 0),
                To = new DateTime(changedExceptionDate1.Year, changedExceptionDate1.Month, changedExceptionDate1.Day, 13, 0, 0),
                Color = Brushes.DeepPink,
                ForegroundColor = Brushes.White,
                Id = 2,
                RecurrenceId = 1
            };
            RecursiveExceptionAppointmentCollection.Add(changedEvent);

            Event changedEvent1 = new Event
            {
                EventName = "Scrum meeting - Changed Occurrence",
                From = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 12, 0, 0),
                To = new DateTime(changedExceptionDate2.Year, changedExceptionDate2.Month, changedExceptionDate2.Day, 13, 0, 0),
                Color = Brushes.LimeGreen,
                ForegroundColor = Brushes.White,
                Id = 3,
                RecurrenceId = 1
            };
            RecursiveExceptionAppointmentCollection.Add(changedEvent1);
        }
    }
}
