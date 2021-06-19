
namespace ScheduleParse
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFullTimeEdu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExtraStud = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMagistr = new System.Windows.Forms.ToolStripMenuItem();
            this.формированиеРасписанияНаСтендToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCreateGeneralSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеПреподовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreatePersonalScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listViewScheduleTeacher = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUpdate,
            this.формированиеРасписанияНаСтендToolStripMenuItem,
            this.расписаниеПреподовToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(566, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuUpdate";
            // 
            // toolStripMenuItemUpdate
            // 
            this.toolStripMenuItemUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFullTimeEdu,
            this.toolStripMenuItemExtraStud,
            this.toolStripMenuItemMagistr});
            this.toolStripMenuItemUpdate.Name = "toolStripMenuItemUpdate";
            this.toolStripMenuItemUpdate.Size = new System.Drawing.Size(156, 20);
            this.toolStripMenuItemUpdate.Text = "Обновление расписания";
            this.toolStripMenuItemUpdate.Click += new System.EventHandler(this.toolStripMenuItemUpdate_Click);
            // 
            // toolStripMenuItemFullTimeEdu
            // 
            this.toolStripMenuItemFullTimeEdu.Name = "toolStripMenuItemFullTimeEdu";
            this.toolStripMenuItemFullTimeEdu.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemFullTimeEdu.Text = "Очная форма";
            this.toolStripMenuItemFullTimeEdu.Click += new System.EventHandler(this.toolStripMenuItemFullTimeEdu_Click);
            // 
            // toolStripMenuItemExtraStud
            // 
            this.toolStripMenuItemExtraStud.Name = "toolStripMenuItemExtraStud";
            this.toolStripMenuItemExtraStud.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemExtraStud.Text = "Заочная форма";
            this.toolStripMenuItemExtraStud.Click += new System.EventHandler(this.toolStripMenuItemExtraStud_Click);
            // 
            // toolStripMenuItemMagistr
            // 
            this.toolStripMenuItemMagistr.Name = "toolStripMenuItemMagistr";
            this.toolStripMenuItemMagistr.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemMagistr.Text = "Магистратура";
            this.toolStripMenuItemMagistr.Click += new System.EventHandler(this.toolStripMenuItemMagistr_Click);
            // 
            // формированиеРасписанияНаСтендToolStripMenuItem
            // 
            this.формированиеРасписанияНаСтендToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCreateGeneralSchedule});
            this.формированиеРасписанияНаСтендToolStripMenuItem.Name = "формированиеРасписанияНаСтендToolStripMenuItem";
            this.формированиеРасписанияНаСтендToolStripMenuItem.Size = new System.Drawing.Size(221, 20);
            this.формированиеРасписанияНаСтендToolStripMenuItem.Text = "Формирование расписания на стенд";
            // 
            // toolStripMenuItemCreateGeneralSchedule
            // 
            this.toolStripMenuItemCreateGeneralSchedule.Name = "toolStripMenuItemCreateGeneralSchedule";
            this.toolStripMenuItemCreateGeneralSchedule.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCreateGeneralSchedule.Text = "Сформировать";
            this.toolStripMenuItemCreateGeneralSchedule.Click += new System.EventHandler(this.toolStripMenuItemCreateGeneralSchedule_Click);
            // 
            // расписаниеПреподовToolStripMenuItem
            // 
            this.расписаниеПреподовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreatePersonalScheduleToolStripMenuItem});
            this.расписаниеПреподовToolStripMenuItem.Name = "расписаниеПреподовToolStripMenuItem";
            this.расписаниеПреподовToolStripMenuItem.Size = new System.Drawing.Size(176, 20);
            this.расписаниеПреподовToolStripMenuItem.Text = "Расписание преподавателей";
            // 
            // CreatePersonalScheduleToolStripMenuItem
            // 
            this.CreatePersonalScheduleToolStripMenuItem.Name = "CreatePersonalScheduleToolStripMenuItem";
            this.CreatePersonalScheduleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CreatePersonalScheduleToolStripMenuItem.Text = "Создать";
            this.CreatePersonalScheduleToolStripMenuItem.Click += new System.EventHandler(this.CreatePersonalScheduleToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 395);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дата обновления очной формы:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 395);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "04.06.2021";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 421);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Дата обновления магистратуры:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 408);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(182, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Дата обновления заочной формы:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 421);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "04.06.2021";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(495, 408);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "04.06.2021";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(194, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "Поиск расписания";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(20, 61);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Введите фамилию";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(20, 104);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Выберите дату";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.Location = new System.Drawing.Point(199, 104);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(198, 61);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(357, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 13;
            // 
            // buttonFind
            // 
            this.buttonFind.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonFind.AutoSize = true;
            this.buttonFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFind.Location = new System.Drawing.Point(431, 101);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(125, 27);
            this.buttonFind.TabIndex = 14;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 435);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(566, 17);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Visible = false;
            // 
            // listViewScheduleTeacher
            // 
            this.listViewScheduleTeacher.AutoArrange = false;
            this.listViewScheduleTeacher.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewScheduleTeacher.GridLines = true;
            this.listViewScheduleTeacher.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewScheduleTeacher.HideSelection = false;
            this.listViewScheduleTeacher.Location = new System.Drawing.Point(12, 148);
            this.listViewScheduleTeacher.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listViewScheduleTeacher.Name = "listViewScheduleTeacher";
            this.listViewScheduleTeacher.Size = new System.Drawing.Size(543, 242);
            this.listViewScheduleTeacher.TabIndex = 16;
            this.listViewScheduleTeacher.UseCompatibleStateImageBehavior = false;
            this.listViewScheduleTeacher.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Занятия";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 350;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(566, 453);
            this.Controls.Add(this.listViewScheduleTeacher);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Расписание";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFullTimeEdu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExtraStud;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMagistr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem формированиеРасписанияНаСтендToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateGeneralSchedule;
        private System.Windows.Forms.ToolStripMenuItem расписаниеПреподовToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonFind;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem CreatePersonalScheduleToolStripMenuItem;
        private System.Windows.Forms.ListView listViewScheduleTeacher;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}

