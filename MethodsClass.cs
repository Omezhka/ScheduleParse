using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleParse
{
   public static class MethodsClass
   {
        static string path = System.Windows.Forms.Application.StartupPath + @"\documents\";
        static string pathOutput = AppDomain.CurrentDomain.BaseDirectory + @"outputDocuments\";

        static string filePath;

       
        // public static string filePath { get; set; }

        /// <summary>
        /// Открытие проводника и загрузка документов
        /// </summary>
        public static void LoadFiles()
        {
            //filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "doc files (*.doc)|*.doc";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string fileContent = reader.ReadToEnd();
                    }
                }
            }

            MessageBox.Show("load complete", "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        /// <summary>
        /// Создание исходного дока, конвертирование в .txt, создание и заполнение списка notifications, настройка position и форматирование вывода фамилии
        /// </summary>
        public static void GenerateDocApp(List<string> izv, List<Notification> notifications)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application
            {
                Visible = false
            };

            //filePath = string.Empty;

           // if (filePath != null) { }

            Document doc = app.Documents.OpenNoRepairDialog(filePath);
            try
            {
               Convert2txt(doc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            app.ActiveDocument.Close();

            string filenametxt = path + "1.txt";

            using (StreamReader sr = new StreamReader(filenametxt, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    izv.Add(line);

                }
            }

            int i = 0;

            var regHeader = new Regex(Pattern.header);
            var groupHeaderNames = regHeader.GetGroupNames();
            var regScheduleItem = new Regex(Pattern.scheduleItem);
            var groupScheduleItemNames = regScheduleItem.GetGroupNames();

            MethodsClass.CreateNotifications(izv, regHeader, i, notifications);

            MethodsClass.SettingsFieldNotifications(notifications);  
        }
       
        /// <summary>
        /// Замена сокращенных position на полные и форматирование вывода фио преподавателей
        /// </summary>
        private static void SettingsFieldNotifications(List<Notification> notifications)
        {
            foreach (var z in notifications)
            {

                switch (z.teacher.position)
                {
                    case "доц.":
                        z.teacher.position = "Доцент";
                        break;
                    case "ст.пр.":
                        z.teacher.position = "Старший преподаватель";
                        break;
                    case "асс.":
                        z.teacher.position = "Ассистент";
                        break;
                    case "проф.":
                        z.teacher.position = "Профессор";
                        break;
                }

                var teacherfullnameLower = z.teacher.fullname.ToLower();

                TextInfo myTI = new CultureInfo("ru-RU", false).TextInfo;
                z.teacher.fullname = myTI.ToTitleCase(teacherfullnameLower);

                //Console.WriteLine($"{z.teacher.position} {z.teacher.fullname} {z.teacher.cathedra}");
                //foreach (var y in z.scheduleList)
                //{
                //    Console.WriteLine($"{y.group} {y.Week}");
                //}
            }
        }

        /// <summary>
        /// Создание и заполнение списка notifications
        /// </summary>
        private static void CreateNotifications(List<string> izv, Regex regHeader, int i, List<Notification> notifications)
        {
            while (i < izv.Count)
            {
                if (regHeader.IsMatch(izv[i]))
                {
                    var izvHeaderCathedra = regHeader.Match(izv[i]).Groups["cathedra"].ToString(); // берём название кафедры из заголовка
                    var izvItem = new List<string>();
                    while (izv[i] != "         Специалист отдела ОУП и ККО Бусова О.В.")
                    {
                        izvItem.Add(izv[i]);
                        i++;
                    }
                    if (izvHeaderCathedra == "Информационных технологий и за") // сравниваем название кафедры с нужной, и если совпало - добавляем в список распарщеных извещений
                    {
                        notifications.Add(new Notification(izvItem));
                    }
                }
                i++;
            }

            
        }

        /// <summary>
        /// Парсинг в json
        /// </summary>
        private static void JsonParse(List<Notification> notifications)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(notifications, options);

            string writePath = pathOutput + "hta.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(json);
                }

                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Создание общего расписания для стенда
        /// </summary>
        public static void GeneralSchedule(Microsoft.Office.Interop.Word.Application app, List<Notification> notifications)
        {
            var teacherCount = notifications.Count();
            //тут создаю новый док, задаю ему альбомную ориентацию
            Document docTable = app.Documents.Add();
            PageSetupOrientational(docTable);
            // тут какие-то замуты с параграфами, я не до конца выкупила, но если строчку ниже убрать,
            // то таблица принимает стили текста перед таблицей 
            docTable.Paragraphs.Add();

            Range rng = docTable.Paragraphs[1].Range;


            rng.InsertBefore("РАСПИСАНИЕ ЗАНЯТИЙ ПРЕПОДАВАТЕЛЕЙ КАФЕДРЫ " +
                "ИНФОРМАЦИОННЫХ ТЕХНОЛОГИЙ И ЗАЩИТЫ ИНФОРМАЦИИ " +
                "НА 1 - е ПОЛУГОДИЕ 2020 / 2021 УЧЕБНОГО ГОДА");
            rng.InsertParagraphAfter();
            //собсна, стили текста выше
            SettingsTitle(rng);
            //добавление таблицы в третий параграф, кол-во строк = кол-во нотификейшнов, 7 столбцов, дальше какие-то настройки таблицы
            rng.Tables.Add(docTable.Paragraphs[3].Range, teacherCount + 1, 7, WdDefaultTableBehavior.wdWord9TableBehavior, WdAutoFitBehavior.wdAutoFitWindow);

            //тут всё закручено на Range
            Table tbl = docTable.Tables[1];
            tbl.Range.Font.Size = 9;
            tbl.Range.Font.Name = "Times New Roman";
            tbl.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            //это настройки таблицы
            tbl.Columns.DistributeWidth();
            tbl.Rows[1].Range.Font.Bold = 1;

            tbl.Cell(1, 1).Range.Text = "Ф.И.О. преподавателя";
            tbl.Cell(1, 2).Range.Text = "Понедельник";
            tbl.Cell(1, 3).Range.Text = "Вторник";
            tbl.Cell(1, 4).Range.Text = "Среда";
            tbl.Cell(1, 5).Range.Text = "Четверг";
            tbl.Cell(1, 6).Range.Text = "Пятница";
            tbl.Cell(1, 7).Range.Text = "Суббота";

            // этот список для раскидывания занятий по ячейкам соотв. дня недели

            // вывод преподов 

            
            for (int i = 2; i <= teacherCount + 1;)
            {
                tbl.Cell(i, 1).Range.Text = $"{notifications[i - 2].teacher.position}\r\n{notifications[i - 2].teacher.fullname}";
                i++;
                tbl.Cell(i - 1, 1).Range.Font.Bold = 1;
                tbl.Cell(i - 1, 1).Range.Font.Size = 12;
                tbl.Cell(i - 1, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            }

            for (int i = 0; i < teacherCount; i++) //столбец
            {
                for (var k = 0; k < notifications[i].scheduleList.Count; k++) // строка
                {
                    //int indexDayPosition = 0;

                    int indexDayPosition = week().IndexOf(notifications[i].scheduleList[k].days);

                    tbl.Cell(i + 2, indexDayPosition + 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                    if (notifications[i].scheduleList[k].Week)
                    {
                        tbl.Cell(i + 2, indexDayPosition + 2).Range.InsertAfter($"{"чет: "}" +
                                                                                $"{notifications[i].scheduleList[k].classhours } " +
                                                                                $"{notifications[i].scheduleList[k].group } " +
                                                                                $"{"a." + notifications[i].scheduleList[k].audience }\r\n");
                    }
                    else
                    {
                        tbl.Cell(i + 2, indexDayPosition + 2).Range.InsertAfter($"{"нечет: "}" +
                                                                                $"{notifications[i].scheduleList[k].classhours } " +
                                                                                $"{notifications[i].scheduleList[k].group } " +
                                                                                $"{"a." + notifications[i].scheduleList[k].audience }\r\n");
                    }
                }
            }
        }

        /// <summary>
        /// Список с сокращенными днями недели для заполнения расписания
        /// </summary>
        private static List<string> week()
        {
            var week = new List<string>
            {
                 "пнд",
                "втp",
                "сpд",
                "чтв",
                "птн",
                "сбт"

            };

            return week;
        }

        /// <summary>
        /// Создание персонального расписания каждого преподавателя
        /// </summary>
        public static void CreatePersonalSchedule(Microsoft.Office.Interop.Word.Application app, List<Notification> notifications, List<string> week)
        {
            //app.Visible = false;
            var classhours = new List<string>
            {
                    "08.30-10.00",
                    "10.10-11.40",
                    "11.50-13.20",
                    "13.50-15.20",
                    "15.30-17.00",
                    "17.10-18.40"
            };

            int c = 0;

            if (c <= notifications.Count)
            {
                foreach (var variable in notifications)
                {
                    Document teacherScheduleTable = app.Documents.Add();

                    PageSetupOrientational(teacherScheduleTable);

                    teacherScheduleTable.Paragraphs.Add();

                    Range rngtst = teacherScheduleTable.Paragraphs[1].Range;

                    rngtst.InsertBefore("РАСПИСАНИЕ ВАШИХ ЗАНЯТИЙ НА 1 - е ПОЛУГОДИЕ 2020 / 2021 УЧЕБНОГО ГОДА");
                    rngtst.InsertParagraphAfter();

                    SettingsTitle(rngtst);

                    rngtst.Tables.Add(teacherScheduleTable.Paragraphs[3].Range, classhours.Count + 1, 7, WdDefaultTableBehavior.wdWord9TableBehavior, WdAutoFitBehavior.wdAutoFitWindow);

                    Table tbltst = teacherScheduleTable.Tables[1];

                    tbltst.Range.Font.Size = 9;
                    tbltst.Range.Font.Name = "Times New Roman";
                    tbltst.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    tbltst.Columns.DistributeWidth();

                    tbltst.Rows[1].Range.Font.Bold = 1;

                    tbltst.Cell(1, 1).Range.Text = " ";
                    tbltst.Cell(1, 2).Range.Text = "Понедельник";
                    tbltst.Cell(1, 3).Range.Text = "Вторник";
                    tbltst.Cell(1, 4).Range.Text = "Среда";
                    tbltst.Cell(1, 5).Range.Text = "Четверг";
                    tbltst.Cell(1, 6).Range.Text = "Пятница";
                    tbltst.Cell(1, 7).Range.Text = "Суббота";


                    InsertFirstColumnInTable(classhours, tbltst);

                    InsertDataInPersonalTeacherSchedule(notifications, week, classhours, c, tbltst);

                    //teacherScheduleTable.SaveAs2(pathOutput + @"prepods\"+ notifications[c].teacher.fullname + ".docx");
                    c++;
                }
            }
        }

        /// <summary>
        /// Настройки текста перед таблицей
        /// </summary>
        /// <param name="rngtst"></param>
        private static void SettingsTitle(Range rngtst)
        {
            rngtst.Font.Name = "Times New Roman";
            rngtst.Font.Size = 16;
            rngtst.Font.Bold = 1;
            rngtst.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
        }
        /// <summary>
        /// Вставка в таблицу время занятий
        /// </summary>
        private static void InsertFirstColumnInTable(List<string> classhours, Table tbltst)
        {
            for (var i = 2; i <= classhours.Count + 1;)
            {
                tbltst.Cell(i, 1).Range.Text = classhours[i - 2];
                i++;
                SettingsFirstColumn(tbltst, i);
            }
        }
        /// <summary>
        /// Настройки текста для первого столбца таблицы
        /// </summary>
        private static void SettingsFirstColumn(Table tbltst, int i)
        {
            tbltst.Cell(i - 1, 1).Range.Font.Bold = 1;
            tbltst.Cell(i - 1, 1).Range.Font.Size = 12;
            tbltst.Cell(i - 1, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        }

        /// <summary>
        /// Добавление данных в таблицу с индивидуальным расписанием преподавателя
        /// </summary>
        private static void InsertDataInPersonalTeacherSchedule(List<Notification> notifications, List<string> week, List<string> classhours, int c, Table tbltst)
        {
            for (var k = 0; k < notifications[c].scheduleList.Count; k++) //столбец
            {
                var indexDayPosition = 0;
                var indexClasshoursPosition = 0;

                indexDayPosition = week.IndexOf(notifications[c].scheduleList[k].days);
                indexClasshoursPosition = classhours.IndexOf(notifications[c].scheduleList[k].classhours);

                tbltst.Cell(indexClasshoursPosition + 2, indexDayPosition + 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                if (notifications[c].scheduleList[k].Week)
                {
                    tbltst.Cell(indexClasshoursPosition + 2, indexDayPosition + 2).Range.InsertAfter($"{"чет:"} {notifications[c].teacher.fullname } " +
                                                                                                     $"{notifications[c].scheduleList[k].group } " +
                                                                                                     $"{"a." + notifications[c].scheduleList[k].audience }\r\n");
                }
                else
                {
                    tbltst.Cell(indexClasshoursPosition + 2, indexDayPosition + 2).Range.InsertAfter($"{"нечет:"} {notifications[c].teacher.fullname } " +
                                                                                                     $"{notifications[c].scheduleList[k].group } " +
                                                                                                     $"{"a." + notifications[c].scheduleList[k].audience }\r\n");
                }
            }
        }

        /// <summary>
        /// Настройка ориентации таблицы
        /// </summary>
        private static void PageSetupOrientational(Document teacherScheduleTable)
        {
            teacherScheduleTable.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
        }

        /// <summary>
        /// Конвертация документа из .doc в .txt
        /// </summary>
        private static void Convert2txt(Document doc)
        {
            string newFileName = doc.FullName.Replace(".doc", ".txt");
            doc.SaveAs2(path+newFileName, WdSaveFormat.wdFormatText);
        }
    }
}
