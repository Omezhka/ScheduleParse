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
        static string path = AppDomain.CurrentDomain.BaseDirectory + @"documents\";
        static string pathOutput = AppDomain.CurrentDomain.BaseDirectory + @"outputDocuments\";
        List<Notification> notifications = new List<Notification>();
        List<string> izv = new List<string>();
        //string filename = path + "1.doc";
        static Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        BackgroundWorker worker = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();

        }

        private void toolStripMenuItemFullTimeEdu_Click(object sender, EventArgs e)
        {
            MethodsClass.LoadFiles();
            MethodsClass.GenerateDocApp(izv, notifications);
            label2.Text = DateTime.Now.ToShortDateString();
            foreach (var item in notifications)
            {
                comboBox1.Items.AddRange(new object[]{
                    item.teacher.fullname
            });
            }
        }

        private void toolStripMenuItemExtraStud_Click(object sender, EventArgs e)
        {
            MethodsClass.LoadFiles();
            label6.Text = DateTime.Now.ToShortDateString();
        }

        private void toolStripMenuItemMagistr_Click(object sender, EventArgs e)
        {
            MethodsClass.LoadFiles();
            label5.Text = DateTime.Now.ToShortDateString();
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void toolStripMenuItemCreateGeneralSchedule_Click(object sender, EventArgs e)
        { 
            app.Visible = true;
            progressBar1.Visible = true;
            MethodsClass.GenerateDocApp(izv, notifications);
            progressBar1.Value = 0;
            
            var progress = new Progress<int>(x => progressBar1.Value = x);
            await System.Threading.Tasks.Task.Run(() => MethodsClass.CreateGeneralSchedule(app, notifications, progress));
            progressBar1.Value = 100;
            
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
        
    }
}
