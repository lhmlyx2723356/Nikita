using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;

namespace Nikita.Core.Sample
{
    public partial class FrmQuartzNetDemo2 : Form
    {
        public FrmQuartzNetDemo2()
        {
            InitializeComponent();
        }

        private void btnTest1_Click(object sender, EventArgs e)
        { 

            HolidayCalendar cal = new HolidayCalendar();
            cal.AddExcludedDate(DateTime.UtcNow);
             
            // construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory(); 
            // get a scheduler
            IScheduler sched = schedFact.GetScheduler();
            sched.AddCalendar("myHolidays", cal, false,false);


            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            ITrigger t = TriggerBuilder.Create()
                .WithIdentity("myTrigger")
                .ForJob("myJob")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(9, 30)) // execute job daily at 9:30
                .ModifiedByCalendar("myHolidays") // but not on holidays
                .Build();

            // .. schedule job with trigger


            // define the job and tie it to our HelloJob class
            IJobDetail job2 = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob2", "group1")
                .Build();



            ITrigger t2 = TriggerBuilder.Create()
                .WithIdentity("myTrigger2")
                .ForJob("myJob2")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(11, 30)) // execute job daily at 11:30
                .ModifiedByCalendar("myHolidays") // but not on holidays
                .Build();


            // .. schedule job with trigger2 





            sched.ScheduleJob(job, t);
            sched.ScheduleJob(job, t2);
               
        }
    }
}
