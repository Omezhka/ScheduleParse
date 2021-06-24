using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleParse
{
    class MethodsGeneralClass
    {

        /// <summary>
        /// Открытие проводника и загрузка документов
        /// </summary>
        public static string LoadFiles()
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "doc files (*.doc)|*.doc|docx files (*.docx)|*.docx"; 
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }

            return filePath;
        }

        /// <summary>
        /// Сокращение дней недели для поиска  
        /// </summary>
        static public string WeekDayShort(Form1 form)
        {
            string result = "";

            switch (form.dateTimePicker1.Value.DayOfWeek.ToString())
            {
                case "Monday":
                    result = MethodsClassFullTimeEdu.week()[0];
                    break;

                case "Tuesday":
                    result = MethodsClassFullTimeEdu.week()[1];
                    break;

                case "Wednesday":
                    result = MethodsClassFullTimeEdu.week()[2];
                    break;

                case "Thursday":
                    result = MethodsClassFullTimeEdu.week()[3];
                    break;

                case "Friday":
                    result = MethodsClassFullTimeEdu.week()[4];
                    break;

                case "Saturday":
                    result = MethodsClassFullTimeEdu.week()[5];
                    break;
            }

            return result;
        }

        static public bool ParityOfWeek(Form1 form)
        {
            DateTimeFormatInfo dateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dateTimeFormatInfo.Calendar;
            bool parityOfWeek;
            var date = cal.GetWeekOfYear(DateTime.Parse(form.dateTimePicker1.Value.ToString()), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

            if (date % 2 == 0)
            {
                parityOfWeek = true;
            }
            else
            {
                parityOfWeek = false;
            }

            return parityOfWeek;
        }

        /// <summary>
        /// Конвертация документа из .doc в .txt
        /// </summary>
        public static string Convert2txt(Document doc, string path)
        {
            var newFileName = String.Empty;

            if (doc.Name.Contains(".docx"))
            {
                newFileName = doc.Name.Replace(".docx", ".txt");
            }
            else if (doc.Name.Contains(".doc"))
            {
                newFileName = doc.Name.Replace(".doc", ".txt");
            }
            doc.SaveAs2(path + newFileName, WdSaveFormat.wdFormatText);
            return newFileName;
        }
    }
}
