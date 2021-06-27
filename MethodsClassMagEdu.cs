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

namespace ScheduleParse
{
    class MethodsClassMagEdu
    {
        static string path = System.Windows.Forms.Application.StartupPath + @"\documents\";
        static string pathOutput = System.Windows.Forms.Application.StartupPath + @"\outputDocuments\";

        static string pathSavePrepods = pathOutput + @"Преподаватели\";     
        static string pathSavePrepodsMagistr = pathSavePrepods + @"Магистратура\";
        static string pathSaveJSON = path + @"json\";

        static string newFileName = String.Empty;


        /// <summary>
        /// Создание исходного дока, конвертирование в .txt, создание и заполнение списка notifications, настройка position и форматирование вывода фамилии
        /// </summary>
        public static void GenerateDocAppMagEdu(List<string> izv, List<NotificationMagister> notificationsMag, IProgress<int> progress, string filePath)
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
                    newFileName = MethodsGeneralClass.Convert2txt(doc, path);
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

                var headerDocMagEdu = (izv[4].Trim() + " " + izv[5].Trim() + " " + izv[6].Trim()).ToUpper();

                File.WriteAllText(path + "saveHeaderDocMagEdu.txt", headerDocMagEdu);

                CreateNotificationsMagEdu(izv, notificationsMag, progress);

                SettingsFieldNotificationsMagEdu(notificationsMag);

                app.Quit();
            }
        }

        /// <summary>
        /// Замена сокращенных position на полные и форматирование вывода фио преподавателей
        /// </summary>
        private static void SettingsFieldNotificationsMagEdu(List<NotificationMagister> notificationsMag)
        {
            foreach (var z in notificationsMag)
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
        private static void CreateNotificationsMagEdu(List<string> izv, List<NotificationMagister> notificationsMag, IProgress<int> progress)
        {
            var regHeader = new Regex(Pattern.headerMagistr);
            int i = 0;

            while (i < izv.Count)
            {
                if (regHeader.IsMatch(izv[i]))
                {
                    var izvHeaderCathedra = regHeader.Match(izv[i]).Groups["cathedra"].ToString(); // берём название кафедры из заголовка
                    var izvItem = new List<string>();
                    while (!izv[i].Contains("ОУП и ККО"))
                    {
                        izvItem.Add(izv[i]);
                        i++;
                    }
                    if (izvHeaderCathedra == "Информационных технологий и за") // сравниваем название кафедры с нужной, и если совпало - добавляем в список распарщеных извещений
                    {
                        notificationsMag.Add(new NotificationMagister(izvItem));
                    }
                }
                i++;
                progress.Report(i / 1498);
            }
        }



        /// <summary>
        /// Парсинг в json
        /// </summary>
        public static void JsonParseMagEdu(List<NotificationMagister> notificationsMag, string formEdu, Form1 form)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(notificationsMag, options);

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

            FillingComboBoxMagEdu(JsonParseDesMagEdu(formEdu), formEdu, form);

        }

        static public void FillingComboBoxMagEdu(List<NotificationMagisterFromJson> notificationMagEduFromJson, string formEdu, Form1 form)
        {

            if (notificationMagEduFromJson.Count == 0) { notificationMagEduFromJson = JsonParseDesMagEdu(formEdu); }

            foreach (var item in notificationMagEduFromJson)
            {
                form.comboBoxMagEdu.Items.Add(item.teacher.fullname.ToString());
            }
            form.comboBoxMagEdu.Enabled = true;
            form.comboBoxMagEdu.SelectedItem = form.comboBoxMagEdu.Items[0];


            DateTime fileCreatedDate = File.GetLastWriteTime(pathSaveJSON + formEdu + ".txt");
            if (fileCreatedDate.Date.ToShortDateString() != "01.01.1601")
                form.label6.Text = fileCreatedDate.Date.ToShortDateString();
            else form.label6.Text = "-";

        }

        public static List<NotificationMagisterFromJson> JsonParseDesMagEdu(string formEdu)
        {
            List<NotificationMagisterFromJson> notificationMagEduFromJson = new List<NotificationMagisterFromJson>();

            if (File.Exists(pathSaveJSON + formEdu + ".txt"))
            {
                var JSONtxt = File.ReadAllText(pathSaveJSON + formEdu + ".txt", Encoding.Default);

                notificationMagEduFromJson = JsonSerializer.Deserialize<List<NotificationMagisterFromJson>>(JSONtxt);

            }

            return notificationMagEduFromJson;
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
        public static void CreatePersonalScheduleMagEdu(Application app, List<NotificationMagisterFromJson> notificationMagEduFromJson, IProgress<int> progress)
        {
            app.Visible = false;
            List<string> classhours = Classhours();

            int c = 0;

            if (c <= notificationMagEduFromJson.Count)
            {
                foreach (var variable in notificationMagEduFromJson)
                {
                    Document teacherScheduleTable = app.Documents.Add();

                    PageSetupOrientational(teacherScheduleTable);

                    teacherScheduleTable.Paragraphs.Add();

                    Range rngtst = teacherScheduleTable.Paragraphs[1].Range;

                    var headerDoc = File.ReadAllText(path + "saveHeaderDocMagEdu.txt", Encoding.UTF8);

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

                    InsertDataInPersonalTeacherSchedule(notificationMagEduFromJson, classhours, c, tbltst);
                    DirectoryInfo dirInfo = new DirectoryInfo(pathSavePrepodsMagistr);
                    if (!dirInfo.Exists)
                    {
                        dirInfo.Create();
                    }

                    teacherScheduleTable.SaveAs2(pathSavePrepodsMagistr + notificationMagEduFromJson[c].teacher.fullname + ".docx");
                    progress.Report(c * 3);
                    app.ActiveDocument.Close(WdSaveOptions.wdDoNotSaveChanges);
                    c++;
                }

            }

            app.Quit();
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
                    "17.10-18.40",
                    "18.45-20.15"
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
        private static void InsertDataInPersonalTeacherSchedule(List<NotificationMagisterFromJson> notificationMagEduFromJson, List<string> classhours, int c, Table tbltst)
        {
            for (var k = 0; k < notificationMagEduFromJson[c].scheduleList.Count; k++) //столбец
            {
                int indexDayPosition = week().IndexOf(notificationMagEduFromJson[c].scheduleList[k].days);
                int indexClasshoursPosition = classhours.IndexOf(notificationMagEduFromJson[c].scheduleList[k].classhours);

                tbltst.Cell(indexClasshoursPosition + 2, indexDayPosition + 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;


                tbltst.Cell(indexClasshoursPosition + 2, indexDayPosition + 2).Range.InsertAfter($"{notificationMagEduFromJson[c].scheduleList[k].date} {notificationMagEduFromJson[c].teacher.fullname } " +
                                                                                                 $"{notificationMagEduFromJson[c].scheduleList[k].group } " +
                                                                                                 $"{"a." + notificationMagEduFromJson[c].scheduleList[k].audience }\r\n");

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
