using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ResourceAutoHeight
{
    public class ViewModel : NotificationObject
    {
        private ScheduleAppointmentCollection events;

        private ObservableCollection<object> resources;

        private ObservableCollection<SolidColorBrush> brushes;

        public ViewModel()
        {
            GetBrushCollection();
            InitializeResources();
            GenerateRandomAppointments();
            DisplayDate = DateTime.Now.Date.AddHours(9);
        }

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

        /// <summary>
        /// Gets or sets resource collection.
        /// </summary>
        public ObservableCollection<object> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
                this.RaisePropertyChanged("Resources");
            }
        }

        private void InitializeResources()
        {
            this.Resources = new ObservableCollection<object>();
            var nameCollection = new List<string>()
            {
                "Sophia",
                "Daniel",
                "James William",
                "Kinsley Ruby",
                "Emilia William",
                "Stephen",
                "Zoey Addison",
            };

            for (int i = 0; i <6; i++)
            {
                SchedulerResource employee = new SchedulerResource();
                employee.Name = nameCollection[i];
                employee.Background = this.brushes[i];
                employee.Foreground = Brushes.White;
                employee.Id = i.ToString();
                Resources.Add(employee);
            }
        }

        private void GenerateRandomAppointments()
        {
            var subjectCollection = new List<string>();
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Performance Check");
            subjectCollection.Add("Yoga Therapy");
            subjectCollection.Add("Auditing");
            subjectCollection.Add("Conference");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Status mail");

            Random randomTime = new Random();
            Events = new ScheduleAppointmentCollection();
            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);
            DateTime dateRangeStart = DateTime.Now.AddDays(-70);
            DateTime dateRangeEnd = DateTime.Now.AddDays(70);

			for (date = dateFrom; date < dateTo; date = date.AddDays(1))
			{
				if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
				{
					for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 8; additionalAppointmentIndex++)
					{
						ScheduleAppointment meeting = new ScheduleAppointment();
						meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 15), 0, 0);
						meeting.EndTime = meeting.StartTime.AddHours(randomTime.Next(1, 3));
						meeting.Subject = subjectCollection[randomTime.Next(9)];
						meeting.AppointmentBackground = this.brushes[randomTime.Next(9)];
						meeting.IsAllDay = false;

						var coll = new ObservableCollection<object>
							{
								(resources[randomTime.Next(Resources.Count)] as SchedulerResource).Id
							};
						meeting.ResourceIdCollection = coll;

						this.Events.Add(meeting);
					}

					for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 8; additionalAppointmentIndex++)
					{
						ScheduleAppointment meeting = new ScheduleAppointment();
						meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(10, 12), 0, 0);
						meeting.EndTime = meeting.StartTime.AddHours(randomTime.Next(1, 3));
						meeting.Subject = subjectCollection[randomTime.Next(9)];
						meeting.AppointmentBackground = this.brushes[randomTime.Next(9)];
						meeting.IsAllDay = false;

						var coll = new ObservableCollection<object>
							{
								(resources[randomTime.Next(Resources.Count)] as SchedulerResource).Id
							};
						meeting.ResourceIdCollection = coll;

						this.Events.Add(meeting);
					}
				}
				else
				{
					ScheduleAppointment meeting = new ScheduleAppointment();
					meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 23), 0, 0);
					meeting.EndTime = meeting.StartTime.AddDays(2).AddHours(1);
					meeting.Subject = subjectCollection[randomTime.Next(9)];
					meeting.AppointmentBackground = this.brushes[randomTime.Next(9)];
					meeting.IsAllDay = true;
					var coll = new ObservableCollection<object>
							{
								(resources[randomTime.Next(Resources.Count)] as SchedulerResource).Id
							};
					meeting.ResourceIdCollection = coll;
					this.Events.Add(meeting);
				}
			}

            ScheduleAppointment meeting3 = new ScheduleAppointment();
            meeting3.StartTime = DateTime.Now.Date.AddHours(11);
            meeting3.EndTime = meeting3.StartTime.AddHours(2);
            meeting3.Subject = subjectCollection[randomTime.Next(9)];
            meeting3.AppointmentBackground = this.brushes[1];
            var col3 = new ObservableCollection<object>
                            {
                                "1"
							};
            meeting3.ResourceIdCollection = col3;
            this.Events.Add(meeting3);

            ScheduleAppointment meeting4 = new ScheduleAppointment();
            meeting4.StartTime = DateTime.Now.Date.AddHours(10);
            meeting4.EndTime = meeting4.StartTime.AddHours(2);
            meeting4.Subject = subjectCollection[randomTime.Next(9)];
            meeting4.AppointmentBackground = this.brushes[1];
            var col4 = new ObservableCollection<object>
                            {
                                "1"
							};
            meeting4.ResourceIdCollection = col4;
            this.Events.Add(meeting4);
        }

        private void GetBrushCollection()
		{
            brushes = new ObservableCollection<SolidColorBrush>()
            {
                new SolidColorBrush(Color.FromRgb(157, 101, 201)),
                new SolidColorBrush(Color.FromRgb(240, 138, 93)),
                new SolidColorBrush(Color.FromRgb(103, 155, 155)),
                new SolidColorBrush(Color.FromRgb(141,34,45)),
                new SolidColorBrush(Color.FromRgb(22,146,22)),
                new SolidColorBrush(Color.FromRgb(12,22,216)),
                new SolidColorBrush(Color.FromRgb(216,145,12)),
                new SolidColorBrush(Color.FromRgb(177,7,191)),
                new SolidColorBrush(Color.FromRgb(39,170,254))
            };
        }
    }
}
