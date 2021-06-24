using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleParse
{
    public partial class Form1 : Form
    {

 
       
        List<string> izv = new List<string>();

        List<NotificationFullTimeFromJson> notificationFullTimeFromJson = new List<NotificationFullTimeFromJson>();
        List<NotificationMagisterFromJson> notificationExtraAndMagFromJson = new List<NotificationMagisterFromJson>();

        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

        string jsonFullTimeEdu = "jsonFullTimeEdu";
        string jsonExtraStudEdu = "jsonExtraStudEdu";
        string jsonMagistrEdu = "jsonMagistrEdu";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notificationFullTimeFromJson = MethodsClassFullTimeEdu.JsonParseDesFullTimeEdu(jsonFullTimeEdu);

            if (notificationFullTimeFromJson.Count != 0)
            {
                MethodsClassFullTimeEdu.FillingComboBoxFullTimeEdu(notificationFullTimeFromJson, jsonFullTimeEdu, this);
            }
            else
            {
                comboBox1.Text = "Не загружено расписание";
                comboBox1.Enabled = false;
            }

            notificationExtraAndMagFromJson = MethodsClassExtraAndMag.JsonParseDesExtraAndMag(jsonExtraStudEdu);

            if (notificationExtraAndMagFromJson.Count != 0)
            {
                MethodsClassExtraAndMag.FillingComboBoxExtraAndMag(notificationExtraAndMagFromJson, jsonFullTimeEdu, this);
            }
            else
            {
                comboBoxExtraEdu.Text = "Не загружено расписание";
                comboBoxExtraEdu.Enabled = false;
            }

        }


        private async void toolStripMenuItemFullTimeEdu_Click(object sender, EventArgs e)
        {
            var filePath = MethodsGeneralClass.LoadFiles();
            List<NotificationFullTimeEdu> notifications = new List<NotificationFullTimeEdu>();

            progressBar1.Visible = true;
            var rrogress1 = new Progress<int>();
            
            progressBar1.Value = 0;

            var progress = new Progress<int>(x => progressBar1.Value = x);
            await System.Threading.Tasks.Task.Run(() => MethodsClassFullTimeEdu.GenerateDocAppFullTimeEdu(izv, notifications, progress, filePath));
            progressBar1.Value = 100;

            MethodsClassFullTimeEdu.JsonParseFullTimeEdu(notifications, jsonFullTimeEdu, this);

        }

        private async void toolStripMenuItemExtraStud_Click(object sender, EventArgs e)
        {
            var filePath = MethodsGeneralClass.LoadFiles();
            List<NotificationMagister> notificationsMag = new List<NotificationMagister>();

            progressBar1.Visible = true;
            var rrogress1 = new Progress<int>();

            progressBar1.Value = 0;

            var progress = new Progress<int>(x => progressBar1.Value = x);
            await System.Threading.Tasks.Task.Run(() => MethodsClassExtraAndMag.GenerateDocAppExtraAndMag(izv, notificationsMag, progress, filePath));
            progressBar1.Value = 100;

            MethodsClassExtraAndMag.JsonParseExtraAndMag(notificationsMag, jsonExtraStudEdu, this);
        }

        private void toolStripMenuItemMagistr_Click(object sender, EventArgs e)
        {
            MethodsGeneralClass.LoadFiles();
            //label23.Text = DateTime.Now.ToShortDateString();

            //MethodsClassExtraAndMag.JsonParseExtraAndMag(notificationsMag, jsonMagistrEdu, this);
        }



        private async void toolStripMenuItemCreateGeneralSchedule_Click(object sender, EventArgs e)
        {
            app.Visible = true;
            progressBar1.Visible = true;

            progressBar1.Value = 0;

            notificationFullTimeFromJson = MethodsClassFullTimeEdu.JsonParseDesFullTimeEdu(jsonFullTimeEdu);

            var progress = new Progress<int>(x => progressBar1.Value = x);
            await System.Threading.Tasks.Task.Run(() => MethodsClassFullTimeEdu.CreateGeneralSchedule(app, notificationFullTimeFromJson, progress));
            progressBar1.Value = 100;

        }

        private void buttonFindFullTimeEdu_Click(object sender, EventArgs e)
        {
            listViewScheduleTeacher.Clear();

            string result = MethodsGeneralClass.WeekDayShort(this);

            notificationFullTimeFromJson = MethodsClassFullTimeEdu.JsonParseDesFullTimeEdu(jsonFullTimeEdu);

            bool parityOfWeek = MethodsGeneralClass.ParityOfWeek(this);

            var res = notificationFullTimeFromJson.Where(s => s.teacher.fullname == comboBox1.SelectedItem.ToString()).ToList();

            listViewScheduleTeacher.Columns.Add("Время");
            listViewScheduleTeacher.Columns.Add("Группа");
            listViewScheduleTeacher.Columns.Add("Аудитория");
            listViewScheduleTeacher.Columns.Add("Предмет");


            foreach (var r in res)
            {
                for (var i = 0; i < r.scheduleList.Count; i++)
                {
                    if (r.scheduleList[i].days == result && parityOfWeek == r.scheduleList[i].Week)
                    {                 
                            ListViewItem classhoursListViewItem = new ListViewItem(r.scheduleList[i].classhours);
                            ListViewItem groupListViewItem = new ListViewItem(r.scheduleList[i].group);
                            ListViewItem audienceListViewItem = new ListViewItem(r.scheduleList[i].audience);
                            ListViewItem subjectListViewItem = new ListViewItem(r.scheduleList[i].subject);

                            classhoursListViewItem.SubItems.Add(r.scheduleList[i].group);
                            classhoursListViewItem.SubItems.Add(r.scheduleList[i].audience);
                            classhoursListViewItem.SubItems.Add(r.scheduleList[i].subject);

                            listViewScheduleTeacher.Items.AddRange(new ListViewItem[] { classhoursListViewItem }); 
                    }
                }
                listViewScheduleTeacher.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private async void ToolStripMenuItemFullTimeEduPersSch_Click(object sender, EventArgs e)
        {

            app.Visible = false;

            progressBar1.Visible = true;
            progressBar1.Value = 0;

            notificationFullTimeFromJson = MethodsClassFullTimeEdu.JsonParseDesFullTimeEdu(jsonFullTimeEdu);

            var progress = new Progress<int>(x => progressBar1.Value = x);
            await System.Threading.Tasks.Task.Run(() => MethodsClassFullTimeEdu.CreatePersonalScheduleFullTimeEdu(app, notificationFullTimeFromJson, progress));
            progressBar1.Value = 100;

        }

        private void buttonFindExtraEdu_Click(object sender, EventArgs e)
        {
            listViewExtraEdu.Clear();

            string result = MethodsGeneralClass.WeekDayShort(this);

            notificationExtraAndMagFromJson = MethodsClassExtraAndMag.JsonParseDesExtraAndMag(jsonExtraStudEdu);

            //bool parityOfWeek = MethodsGeneralClass.ParityOfWeek(this);

            var res = notificationExtraAndMagFromJson.Where(s => s.teacher.fullname == comboBoxExtraEdu.SelectedItem.ToString()).ToList();

            listViewExtraEdu.Columns.Add("Время");
            listViewExtraEdu.Columns.Add("Группа");
            listViewExtraEdu.Columns.Add("Аудитория");
            listViewExtraEdu.Columns.Add("Предмет");

            var dateExtraLes = dateTimePickerExtraEdu.Value.Date.ToShortDateString();  /*dateTimePickerExtraEdu.Value.Day.ToString() + "." + dateTimePickerExtraEdu.Value.Month.ToString();*/
            dateExtraLes = dateExtraLes.Replace("." + dateTimePickerExtraEdu.Value.Year.ToString(), String.Empty);
           // MessageBox.Show(dateExtraLes);

            foreach (var r in res)
            {
                for (var i = 0; i < r.scheduleList.Count; i++)
                {
                    if (/*r.scheduleList[i].days == result && */dateExtraLes == r.scheduleList[i].date)
                    {
                        ListViewItem classhoursListViewItem = new ListViewItem(r.scheduleList[i].classhours);
                        ListViewItem groupListViewItem = new ListViewItem(r.scheduleList[i].group);
                        ListViewItem audienceListViewItem = new ListViewItem(r.scheduleList[i].audience);
                        ListViewItem subjectListViewItem = new ListViewItem(r.scheduleList[i].subject);

                        classhoursListViewItem.SubItems.Add(r.scheduleList[i].group);
                        classhoursListViewItem.SubItems.Add(r.scheduleList[i].audience);
                        classhoursListViewItem.SubItems.Add(r.scheduleList[i].subject);

                        listViewExtraEdu.Items.AddRange(new ListViewItem[] { classhoursListViewItem });
                    }
                }
                listViewExtraEdu.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
    }         
}
