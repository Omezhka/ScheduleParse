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
using System.Windows.Forms;


namespace ScheduleParse
{
    public static class MethodsClassFullTimeEdu
   {
        static readonly string path = System.Windows.Forms.Application.StartupPath + @"\documents\";
        static readonly string pathOutput = System.Windows.Forms.Application.StartupPath + @"\outputDocuments\";

        static readonly string pathSavePrepods = pathOutput + @"Преподаватели\";
        static readonly string pathSavePrepodsFullTimeEdu = pathSavePrepods + @"Очная форма обучения\";
        private static readonly string pathSaveJSON = path + @"json\";

        static string newFileName = String.Empty;

       static string headerDocFullTimeEdu = String.Empty;
        static string headerDocForGeneralSchedule = String.Empty;

        /// <summary>
        /// Создание исходного дока, конвертирование в .txt, создание и заполнение списка notifications, настройка position и форматирование вывода фамилии
        /// </summary>
        public static void GenerateDocAppFullTimeEdu(List<string> izv, List<NotificationFullTimeEdu> notifications, IProgress<int> progress, string filePath)
        {

            if (filePath != String.Empty)
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application
                {
                    Visible = false
                };

                Document doc = app.Documents.OpenNoRepairDialog(filePath);
                try
                {
                   newFileName = MethodsGeneralClass.Convert2txt(doc,path);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                app.ActiveDocument.Close();

                string filenametxt = path + newFileName;

                using (StreamReader sr = new StreamReader(filenametxt, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        izv.Add(line);

                    }
                }


                headerDocFullTimeEdu = (izv[2].Trim() + " " + izv[3].Trim()).ToUpper();

                headerDocForGeneralSchedule = (izv[2].Trim() + " " + izv[3].Trim()).Replace("расписания Ваших занятий", String.Empty).ToUpper();

                //MessageBox.Show(headerDocFullTimeEdu);
                //MessageBox.Show(headerDocForGeneralSchedule);

                File.WriteAllText(path + "saveHeaderDocFullTimeEdu.txt", headerDocFullTimeEdu);
                File.WriteAllText(path + "saveheaderDocForGeneralSchedule.txt", headerDocForGeneralSchedule);

                CreateNotificationsFullTimeEdu(izv, notifications, progress);

                SettingsFieldNotificationsFullTimeEdu(notifications);
            }
        }

        /// <summary>
        /// Замена сокращенных position на полные и форматирование вывода фио преподавателей
        /// </summary>
        private static void SettingsFieldNotificationsFullTimeEdu(List<NotificationFullTimeEdu> notifications)
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
            }
        }


        /// <summary>
        /// Создание и заполнение списка notifications
        /// </summary>
        private static void CreateNotificationsFullTimeEdu(List<string> izv, List<NotificationFullTimeEdu> notifications, IProgress<int> progress)
        {
            var regHeader = new Regex(Pattern.header);
            int i = 0;

            int footerIndex = 0;
            var izvItem = new List<string>();

            while (i < izv.Count)
            {
                if (regHeader.IsMatch(izv[i]))
                {
                    var izvHeaderCathedra = regHeader.Match(izv[i]).Groups["cathedra"].ToString(); // берём название кафедры из заголовка
                    
                    
                    if (izvHeaderCathedra == "Информационных технологий и за") // сравниваем название кафедры с нужной, и если совпало - добавляем в список распарщеных извещений
                    {
                        izvItem.Clear();
                        while (!izv[i].Contains("ОУП и ККО"))
                        {
                            izvItem.Add(izv[i]);
                            i++;
                        }

                        notifications.Add(new NotificationFullTimeEdu(izvItem));
                    }
                }
                i++;   

                progress.Report(i /1498);
            }

            for (var j = izvItem.Count - 1; j > 0; j--)
            {
                if (izvItem[j].Contains("----¦"))
                {
                    footerIndex = j + 1;

                    break;
                }
                //break;
            }

            if (File.Exists(path + "saveFooterDocFullTimeEdu.txt"))
            {
                File.Delete(path + "saveFooterDocFullTimeEdu.txt");
                for (var j = footerIndex; j <= izvItem.Count - 1; j++)
                {
                    File.AppendAllText(path + "saveFooterDocFullTimeEdu.txt", izvItem[j] + "\r\n");
                }

            } else
            {
                for (var j = footerIndex; j <= izvItem.Count - 1; j++)
                {
                    File.AppendAllText(path + "saveFooterDocFullTimeEdu.txt", izvItem[j] + "\r\n");
                }
            }
           
        }

        /// <summary>
        /// Парсинг в json
        /// </summary>
        public static void JsonParseFullTimeEdu(List<NotificationFullTimeEdu> notifications, string formEdu, Form1 form)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            if (notifications.Count != 0) {
                var json = JsonSerializer.Serialize(notifications, options);

                DirectoryInfo dirInfo = new DirectoryInfo(pathSaveJSON);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }

                var writePathJSON = pathSaveJSON + formEdu + ".txt";

                try
                {
                    using (StreamWriter sw = new StreamWriter(writePathJSON, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(json);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                FillingComboBoxFullTimeEdu(JsonParseDesFullTimeEdu(formEdu), formEdu, form);
            } else
            {
                MessageBox.Show("Вы не выбрали ни одного файла!");
            }
        }

        /// <summary>
        /// Заполнение comboBox
        /// </summary>
        static public void FillingComboBoxFullTimeEdu(List<NotificationFullTimeFromJson> notificationFullTimeFromJson, string formEdu, Form1 form)
        {

            if (notificationFullTimeFromJson.Count == 0) { notificationFullTimeFromJson = JsonParseDesFullTimeEdu(formEdu); }

            foreach (var item in notificationFullTimeFromJson)
            {
                if (!form.comboBox1.Items.Contains(item.teacher.fullname.ToString()))
                {
                    form.comboBox1.Items.Add(item.teacher.fullname.ToString());
                }
            }
            form.comboBox1.Enabled = true;
            form.comboBox1.SelectedItem = form.comboBox1.Items[0];


            DateTime fileCreatedDate = File.GetLastWriteTime(pathSaveJSON + formEdu+ ".txt");
            if (fileCreatedDate.Date.ToShortDateString() != "01.01.1601")
                form.label2.Text = fileCreatedDate.Date.ToShortDateString(); 
            else form.label2.Text = "-";
           
        }
        
        /// <summary>
        /// Десериализация
        /// </summary>
        public static List<NotificationFullTimeFromJson> JsonParseDesFullTimeEdu(string formEdu)
        {
            List<NotificationFullTimeFromJson> notificationFullTimeFromJson = new List<NotificationFullTimeFromJson>();

            if (File.Exists(pathSaveJSON + formEdu + ".txt"))
            {
                var JSONtxt = File.ReadAllText(pathSaveJSON + formEdu + ".txt", Encoding.Default);

                notificationFullTimeFromJson = JsonSerializer.Deserialize<List<NotificationFullTimeFromJson>>(JSONtxt);

            }
                       
            return notificationFullTimeFromJson;
        }

        /// <summary>
        /// Создание общего расписания для стенда
        /// </summary>
        public static void CreateGeneralSchedule(Microsoft.Office.Interop.Word.Application app, List<NotificationFullTimeFromJson> notificationFullTimeFromJson, IProgress<int> progress)
        {

            var teacherCount = notificationFullTimeFromJson.Count();
            //тут создаю новый док, задаю ему альбомную ориентацию
            Document docTable = app.Documents.Add();
            PageSetupOrientational(docTable);
            // тут какие-то замуты с параграфами, я не до конца выкупила, но если строчку ниже убрать,
            // то таблица принимает стили текста перед таблицей 
            
            docTable.Paragraphs.Add();

            Range rng = docTable.Paragraphs[1].Range;

            var headerDocForGeneralSchedule = File.ReadAllText(path + "saveheaderDocForGeneralSchedule.txt", Encoding.UTF8);
            var saveFooterDocFullTimeEdu = File.ReadAllText(path + "saveFooterDocFullTimeEdu.txt", Encoding.UTF8);
            rng.InsertBefore("РАСПИСАНИЕ ЗАНЯТИЙ ПРЕПОДАВАТЕЛЕЙ КАФЕДРЫ " +
                "ИНФОРМАЦИОННЫХ ТЕХНОЛОГИЙ И ЗАЩИТЫ ИНФОРМАЦИИ " +
                headerDocForGeneralSchedule);
            rng.InsertParagraphAfter();
            //собсна, стили текста выше
            SettingsTitle(rng);
            //добавление таблицы в третий параграф, кол-во строк = кол-во нотификейшнов, 7 столбцов, дальше какие-то настройки таблицы
            rng.Tables.Add(docTable.Paragraphs[3].Range, teacherCount + 1, 7, WdDefaultTableBehavior.wdWord9TableBehavior, WdAutoFitBehavior.wdAutoFitWindow);

            //тут всё закручено на Range
            Table tbl = docTable.Tables[1];
            SettingsFieldTables(tbl);
           
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
                tbl.Cell(i, 1).Range.Text = $"{notificationFullTimeFromJson[i - 2].teacher.position}\r\n{notificationFullTimeFromJson[i - 2].teacher.fullname}";
                i++;
                SettingsFirstColumn(tbl, i);
            }
            
            for (int i = 0; i < teacherCount; i++) //столбец
            {
                for (var k = 0; k < notificationFullTimeFromJson[i].scheduleList.Count; k++) // строка
                {
                    //int indexDayPosition = 0;

                    int indexDayPosition = week().IndexOf(notificationFullTimeFromJson[i].scheduleList[k].days);

                    tbl.Cell(i + 2, indexDayPosition + 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                    if (notificationFullTimeFromJson[i].scheduleList[k].Week)
                    {
                        tbl.Cell(i + 2, indexDayPosition + 2).Range.InsertAfter($"{"чет: "}" +
                                                                                $"{notificationFullTimeFromJson[i].scheduleList[k].classhours } " +
                                                                                $"{notificationFullTimeFromJson[i].scheduleList[k].group } " +
                                                                                $"{"a." + notificationFullTimeFromJson[i].scheduleList[k].audience }\r\n");
                    }
                    else
                    {
                        tbl.Cell(i + 2, indexDayPosition + 2).Range.InsertAfter($"{"нечет: "}" +
                                                                                $"{notificationFullTimeFromJson[i].scheduleList[k].classhours } " +
                                                                                $"{notificationFullTimeFromJson[i].scheduleList[k].group } " +
                                                                                $"{"a." + notificationFullTimeFromJson[i].scheduleList[k].audience }\r\n");
                    }
                    
                }
                
                progress.Report(i*4);
            }

            object oEndOfDoc = "\\endofdoc";
            Microsoft.Office.Interop.Word.Paragraph oPara2;
           
            object oRng = docTable.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara2 = docTable.Content.Paragraphs.Add(ref oRng);

            oPara2.Range.Font.Size = 9;
            oPara2.Range.Font.Name = "Times New Roman";
            //oPara2.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            oPara2.Range.Text = saveFooterDocFullTimeEdu;
            
        }

        /// <summary>
        /// Список с сокращенными днями недели для заполнения расписания
        /// </summary>
        public static List<string> week()
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
        public static void CreatePersonalScheduleFullTimeEdu(Microsoft.Office.Interop.Word.Application app, List<NotificationFullTimeFromJson> notificationFullTimeFromJson, IProgress<int> progress)
        {
            //app.Visible = false;
            List<string> classhours = Classhours();
            var saveFooterDocFullTimeEdu = File.ReadAllText(path + "saveFooterDocFullTimeEdu.txt", Encoding.UTF8);
            int c = 0;

            if (c <= notificationFullTimeFromJson.Count)
            {
                foreach (var variable in notificationFullTimeFromJson)
                {
                    Document teacherScheduleTable = app.Documents.Add();

                    PageSetupOrientational(teacherScheduleTable);

                    teacherScheduleTable.Paragraphs.Add();

                    Range rngtst = teacherScheduleTable.Paragraphs[1].Range;

                    var headerDoc = File.ReadAllText(path + "saveHeaderDocFullTimeEdu.txt", Encoding.UTF8);

                    rngtst.InsertBefore(headerDoc);
                    rngtst.InsertParagraphAfter();

                    SettingsTitle(rngtst);

                    rngtst.Tables.Add(teacherScheduleTable.Paragraphs[3].Range, classhours.Count + 1, 7, WdDefaultTableBehavior.wdWord9TableBehavior, WdAutoFitBehavior.wdAutoFitWindow);

                    Table tbltst = teacherScheduleTable.Tables[1];
                    SettingsFieldTables(tbltst);

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

                    InsertDataInPersonalTeacherSchedule(notificationFullTimeFromJson, classhours, c, tbltst);

                    object oEndOfDoc = "\\endofdoc";
                    Microsoft.Office.Interop.Word.Paragraph oPara2;

                    object oRng = teacherScheduleTable.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara2 = teacherScheduleTable.Content.Paragraphs.Add(ref oRng);

                    oPara2.Range.Font.Size = 9;
                    oPara2.Range.Font.Name = "Times New Roman";
                    //oPara2.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    oPara2.Range.Text = saveFooterDocFullTimeEdu;

                    DirectoryInfo dirInfo = new DirectoryInfo(pathSavePrepodsFullTimeEdu);
                    if (!dirInfo.Exists)
                    {
                        dirInfo.Create();
                    }

                    teacherScheduleTable.SaveAs2(pathSavePrepodsFullTimeEdu + notificationFullTimeFromJson[c].teacher.fullname + " очка" + ".docx");
                    progress.Report(c * 4);
                    app.ActiveDocument.Close(WdSaveOptions.wdDoNotSaveChanges);
                    c++;


                }

            }

           

            //app.Quit();
        }

        private static List<string> Classhours()
        {
            return new List<string>
            {
                    "08.30-10.00",
                    "10.10-11.40",
                    "11.50-13.20",
                    "13.50-15.20",
                    "15.30-17.00",
                    "17.10-18.40"
            };
        }

        private static void SettingsFieldTables(Table tbltst)
        {
            tbltst.Range.Font.Size = 9;
            tbltst.Range.Font.Name = "Times New Roman";
            tbltst.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
        }

        /// <summary>
        /// Настройки текста перед таблицей
        /// </summary>
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
        private static void InsertDataInPersonalTeacherSchedule(List<NotificationFullTimeFromJson> notificationFullTimeFromJson,  List<string> classhours, int c, Table tbltst)
        {
            for (var k = 0; k < notificationFullTimeFromJson[c].scheduleList.Count; k++) //столбец
            {
                int indexDayPosition = week().IndexOf(notificationFullTimeFromJson[c].scheduleList[k].days);
                int indexClasshoursPosition = classhours.IndexOf(notificationFullTimeFromJson[c].scheduleList[k].classhours);

                tbltst.Cell(indexClasshoursPosition + 2, indexDayPosition + 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                if (notificationFullTimeFromJson[c].scheduleList[k].Week)
                {
                    tbltst.Cell(indexClasshoursPosition + 2, indexDayPosition + 2).Range.InsertAfter($"{"чет:"} " +                                                                                                     $"{notificationFullTimeFromJson[c].scheduleList[k].group } " +
                                                                                                     $"{"a." + notificationFullTimeFromJson[c].scheduleList[k].audience }\r\n");
                }
                else
                {
                    tbltst.Cell(indexClasshoursPosition + 2, indexDayPosition + 2).Range.InsertAfter($"{"нечет:"} " +
                                                                                                     $"{notificationFullTimeFromJson[c].scheduleList[k].group } " +
                                                                                                     $"{"a." + notificationFullTimeFromJson[c].scheduleList[k].audience }\r\n");
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
    }
}
