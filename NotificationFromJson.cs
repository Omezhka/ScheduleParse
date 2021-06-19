using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ScheduleParse
{
    /// <summary>
    /// собственно извещение, у него свойство препод , которое берётся из заголовка
    /// </summary>
    public class NotificationFromJson
    { 
        public NotificationFromJson() { }
        /// <summary>
        /// препод
        /// </summary>
        public Teacher teacher { get; set; }
        /// <summary>
        /// список строк из извещения
        /// </summary>
        public List<Schedule> scheduleList { get; set; }

    }
}
