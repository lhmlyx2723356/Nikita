using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Core.Sample
{
    interface ICalendar
    { /// <summary> 

        /// Gets or sets a description for the <see cref="ICalendar" /> instance - may be

        /// useful for remembering/displaying the purpose of the calendar, though

        /// the description has no meaning to Quartz.

        /// </summary>

        string Description { get; set; }



        /// <summary>

        /// Set a new base calendar or remove the existing one.

        /// Get the base calendar.

        /// </summary>

        ICalendar CalendarBase { set; get; }



        /// <summary>

        /// Determine whether the given time  is 'included' by the

        /// Calendar.

        /// </summary>

        bool IsTimeIncluded(DateTime time);



        /// <summary>

        /// Determine the next time that is 'included' by the

        /// Calendar after the given time.

        /// </summary>

        DateTime GetNextIncludedTime(DateTime time);

    }

}