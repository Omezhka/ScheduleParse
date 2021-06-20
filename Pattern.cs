using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleParse
{
    public static class Pattern
    {
        /// <summary>
        ///  шаблон заголовка извещения
        /// </summary>
        public static string header = @"\w*И\sЗ\sВ\sЕ\sЩ\sЕ\sН\sИ\sЕ\s*(?<position>([\w*\.]+)\.)(?<fullname>(.*)\.)\s(?<cathedra>.*)";
        /// <summary>
        /// шаблон заголовка извещения для магистров/заочки
        /// </summary>
        public static string headerMagistr = @"\s*(?<position>([\w*\.]+)\.)(?<fullname>(.*)\.)\s(?<cathedra>.*)";
        /// <summary>
        /// шаблон одной записи в извещении
        /// </summary>
        public static string scheduleItem = @"\u00A6\s(?<subject>[\w,\W]*)\u00A6\s(?<days>\w\w\w)\s\u00A6(?<classhours>.*)\s*\u00A6(?<audience>.*)\s*\u00A6(?<group>.*)\s*\u00A6";
        /// <summary>
        /// шаблон одной записи в извещении для магистратуры/заочки
        /// </summary>
        public static string scheduleItemMagistr = @"\u00A6\s(?<subject>[\w,\W]*)\u00A6(?<date>\d\d\.\d\d)\u00A6\s(?<days>\w\w\w)\s\u00A6(?<classhours>.*)\s*\u00A6(?<audience>.*)\s*\u00A6(?<group>.*)\s*\u00A6";
    }
}
