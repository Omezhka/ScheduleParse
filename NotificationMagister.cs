using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ScheduleParse
{
    /// <summary>
    /// собственно извещение, у него свойство препод , которое берётся из заголовка
    /// </summary>
    public class NotificationMagister
    {
        public NotificationMagister(List<string> izvItem)
        {
            int i = 0;

            // добавляем преподавателя из заголовка извещения

            var regTeacher = new Regex(Pattern.headerMagistr);
            var regSchdlItem = new Regex(Pattern.scheduleItemMagistr);

            teacher = new Teacher()
            {
                position = regTeacher.Match(izvItem[i]).Groups["position"].ToString(),
                fullname = regTeacher.Match(izvItem[i]).Groups["fullname"].ToString(),
                cathedra = regTeacher.Match(izvItem[i]).Groups["cathedra"].ToString(),
            };

            //наполняем расписание

            scheduleList = new List<ScheduleMagister>();

            i = 8; // пропускаем неинтересные строчки

            while (i < izvItem.Count)
            {
                if (Regex.IsMatch(izvItem[i],Pattern.scheduleItemMagistr)) 
                {
                    scheduleList.Add(new ScheduleMagister(izvItem[i]) 
                    {
                        Week = false
                    });
                }
                i++;
            }
        }
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
