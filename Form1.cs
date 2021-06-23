using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        List<NotificationFullTImeEdu> notifications = new List<NotificationFullTImeEdu>();
        List<string> izv = new List<string>();

        List<NotificationFullTimeFromJson> notificationFromJson = new List<NotificationFullTimeFromJson>();

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
        
            notificationFromJson = MethodsClass.JsonParseDes(jsonFullTimeEdu);

            if (notificationFromJson.Count != 0)
            {
                MethodsClass.FillingComboBox(notificationFromJson, jsonFullTimeEdu, this);
            }
            else
            {
                comboBox1.Text = "Не загружено расписание";
                comboBox1.Enabled = false;
            }

            listViewScheduleTeacher.Columns.Add("Item Column" );
            listViewScheduleTeacher.Columns.Add("Item Column");

            ListViewItem classhours = new ListViewItem("classhours", 0);
            // Place a check mark next to the item.

            classhours.SubItems.Add("1");
            classhours.SubItems.Add("2");
            classhours.SubItems.Add("3");

            listViewScheduleTeacher.Items.AddRange(new ListViewItem[] { classhours});

            listViewScheduleTeacher.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        
        private void toolStripMenuItemFullTimeEdu_Click(object sender, EventArgs e)
        {
            MethodsClass.LoadFiles();

            MethodsClass.GenerateDocApp(izv, notifications);

            MethodsClass.JsonParse(notifications, jsonFullTimeEdu, this);   
        }

        private void toolStripMenuItemExtraStud_Click(object sender, EventArgs e)
        {
            MethodsClass.LoadFiles();
            //label13.Text = DateTime.Now.ToShortDateString();

            MethodsClass.JsonParse(notifications, jsonExtraStudEdu, this);
        }

        private void toolStripMenuItemMagistr_Click(object sender, EventArgs e)
        {
            MethodsClass.LoadFiles();
            //label23.Text = DateTime.Now.ToShortDateString();

            MethodsClass.JsonParse(notifications, jsonMagistrEdu, this);
        }
        
        

        private async void toolStripMenuItemCreateGeneralSchedule_Click(object sender, EventArgs e)
        { 
            app.Visible = true;
            progressBar1.Visible = true;
            
            progressBar1.Value = 0;

            notificationFromJson = MethodsClass.JsonParseDes(jsonFullTimeEdu);

            var progress = new Progress<int>(x => progressBar1.Value = x);
            await System.Threading.Tasks.Task.Run(() => MethodsClass.CreateGeneralSchedule(app, notificationFromJson, progress));
            progressBar1.Value = 100;

           // progressBar1.Visible = false;
        }

        private async void CreatePersonalScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            app.Visible = false;

            progressBar1.Visible = true;
            MethodsClass.GenerateDocApp(izv, notifications);
            progressBar1.Value = 0;

            var progress = new Progress<int>(x => progressBar1.Value = x);
            await System.Threading.Tasks.Task.Run(() => MethodsClass.CreatePersonalSchedule(app, notifications, progress));
            progressBar1.Value = 100;
           
           
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void buttonFindFullTimeEdu_Click(object sender, EventArgs e)
        {
            string result = MethodsClass.WeekDayShort(this);

            MessageBox.Show(comboBox1.SelectedItem.ToString(), /*dateTimePicker1.Value.DayOfWeek.ToString()*/ result);

            
           //notificationFromJson = MethodsClass.JsonParseDes(jsonFullTimeEdu);

           // foreach (var item in MethodsClass.Classhours())
           // {
           //     for (var i = 2; i <= item.Length+1;)
           //     {
           //         listViewScheduleTeacher.Columns.Add(MethodsClass.Classhours()[item]);
           //         i++;
           //     }
           // }
            
        }

        
    }
}
