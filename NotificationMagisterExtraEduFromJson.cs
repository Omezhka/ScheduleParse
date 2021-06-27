using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleParse
{
   public class NotificationMagisterExtraEduFromJson
    {
        public NotificationMagisterExtraEduFromJson() { }
        /// <summary>
        /// препод
        /// </summary>
        public Teacher teacher { get; set; }
        /// <summary>
        /// список строк из извещения
        /// </summary>
        public List<ScheduleMagister> scheduleList { get; set; }
    }
}
