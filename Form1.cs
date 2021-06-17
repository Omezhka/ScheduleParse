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
        

        public Form1()
        {
            InitializeComponent();

        }

        private void toolStripMenuItemFullTimeEdu_Click(object sender, EventArgs e)
        {
            MethodsClass.LoadFiles();
        }

        private void toolStripMenuItemExtraStud_Click(object sender, EventArgs e)
        {
            MethodsClass.LoadFiles();
        }

        private void toolStripMenuItemMagistr_Click(object sender, EventArgs e)
        {
            MethodsClass.LoadFiles();
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemCreateGeneralSchedule_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application
            {
                Visible = true
            };

            MethodsClass.GenerateDocApp(izv, notifications);
            MethodsClass.GeneralSchedule(app, notifications);
        }
    }
}
