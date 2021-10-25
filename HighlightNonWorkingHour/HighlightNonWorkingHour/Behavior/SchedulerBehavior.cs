using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HighlightNonWorkingHour
{
    public class SchedulerBehavior : Behavior<Grid>
    {
        Grid grid;
        SfScheduler scheduler;
        protected override void OnAttached()
        {
            grid = this.AssociatedObject as Grid;
            scheduler = grid.Children[0] as SfScheduler;
            scheduler.DaysViewSettings.SpecialTimeRegions.Add(new SpecialTimeRegion
            {
                StartTime = DateTime.MinValue.AddHours(0),
                EndTime = DateTime.MinValue.AddHours(9),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1"
            });

            scheduler.DaysViewSettings.SpecialTimeRegions.Add(new SpecialTimeRegion
            {
                StartTime = DateTime.MinValue.AddHours(18),
                EndTime = DateTime.MinValue.AddHours(23),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1"
            });
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            grid = null;
            scheduler = null;
        }
    }
}
