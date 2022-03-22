using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RecurringScheduleAppointment
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
        public ScheduleAppointmentCollection RecursiveAppointmentCollection { get; set; }

        public DateTime SelectedDate { get; set; }

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveAppointments()
        {
            this.RecursiveAppointmentCollection = new ScheduleAppointmentCollection();

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            ScheduleAppointment dailyEvent = new ScheduleAppointment
            {
                Subject = "Daily recurring meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                AppointmentBackground = new SolidColorBrush((Color.FromArgb(255, 191, 235, 97))),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=100",
            };

            RecursiveAppointmentCollection.Add(dailyEvent);

            ScheduleAppointment weeklyEvent = new ScheduleAppointment
            {
                Subject = "Weekly recurring meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                AppointmentBackground = new SolidColorBrush((Color.FromArgb(255, 45, 216, 175))),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,WE,FR;INTERVAL=1;COUNT=20",
            };

            RecursiveAppointmentCollection.Add(weeklyEvent);

            ScheduleAppointment monthlyEvent = new ScheduleAppointment
            {
                Subject = "Monthly recurring Meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 14, 0, 0),
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 255, 222, 133)),
                RecurrenceRule = "FREQ=MONTHLY;BYDAY=TU;BYSETPOS=1;INTERVAL=1;COUNT=50",
            };

            RecursiveAppointmentCollection.Add(monthlyEvent);

            ScheduleAppointment yearlyEvent = new ScheduleAppointment
            {
                Subject = "Yearly recurring Meeting",
                StartTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 2, 0, 0),
                EndTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 3, 0, 0),
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 198, 237, 115)),
                RecurrenceRule = "FREQ=YEARLY;BYMONTHDAY=3;BYMONTH=5;INTERVAL=1;COUNT=50",
            };

            RecursiveAppointmentCollection.Add(yearlyEvent);
        }
    }
}
