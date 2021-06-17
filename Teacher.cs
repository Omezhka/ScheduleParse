using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleParse
{
    public class Teacher

    {
        /// <summary>
        /// должность: доцент, профессор, старший препод и тд. 
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// / Фамилия И.О.
        /// </summary>
        public string fullname { get; set; }
        /// <summary>
        /// кафедра
        /// </summary>
        public string cathedra { get; set; }

    }
}
