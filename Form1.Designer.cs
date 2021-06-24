
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
            this.toolStripMenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFullTimeEdu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExtraStud = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMagistr = new System.Windows.Forms.ToolStripMenuItem();
            this.формированиеРасписанияНаСтендToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCreateGeneralSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеПреподовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreatePersonalScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewScheduleTeacher = new System.Windows.Forms.ListView();
            this.buttonFindFullTimeEdu = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFullTimeEduPersSch = new System.Windows.Forms.ToolStripMenuItem();
            this.заочнаяФормаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.магистратураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuUpdate,
            this.формированиеРасписанияНаСтендToolStripMenuItem,
            this.расписаниеПреподовToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(611, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuUpdate";
            // 
            // toolStripMenuUpdate
            // 
            this.toolStripMenuUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFullTimeEdu,
            this.toolStripMenuItemExtraStud,
            this.toolStripMenuItemMagistr});
            this.toolStripMenuUpdate.Name = "toolStripMenuUpdate";
            this.toolStripMenuUpdate.Size = new System.Drawing.Size(156, 20);
            this.toolStripMenuUpdate.Text = "Обновление расписания";
            // 
            // toolStripMenuItemFullTimeEdu
            // 
            this.toolStripMenuItemFullTimeEdu.Name = "toolStripMenuItemFullTimeEdu";
            this.toolStripMenuItemFullTimeEdu.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItemFullTimeEdu.Text = "Очная форма";
            this.toolStripMenuItemFullTimeEdu.Click += new System.EventHandler(this.toolStripMenuItemFullTimeEdu_Click);
            // 
            // toolStripMenuItemExtraStud
            // 
            this.toolStripMenuItemExtraStud.Name = "toolStripMenuItemExtraStud";
            this.toolStripMenuItemExtraStud.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItemExtraStud.Text = "Заочная форма";
            this.toolStripMenuItemExtraStud.Click += new System.EventHandler(this.toolStripMenuItemExtraStud_Click);
            // 
            // toolStripMenuItemMagistr
            // 
            this.toolStripMenuItemMagistr.Name = "toolStripMenuItemMagistr";
            this.toolStripMenuItemMagistr.Size = new System.Drawing.Size(161, 22);
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
            this.CreatePersonalScheduleToolStripMenuItem,
            this.toolStripSeparator1,
            this.открытьToolStripMenuItem});
            this.расписаниеПреподовToolStripMenuItem.Name = "расписаниеПреподовToolStripMenuItem";
            this.расписаниеПреподовToolStripMenuItem.Size = new System.Drawing.Size(176, 20);
            this.расписаниеПреподовToolStripMenuItem.Text = "Расписание преподавателей";
            // 
            // CreatePersonalScheduleToolStripMenuItem
            // 
            this.CreatePersonalScheduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFullTimeEduPersSch,
            this.заочнаяФормаToolStripMenuItem,
            this.магистратураToolStripMenuItem});
            this.CreatePersonalScheduleToolStripMenuItem.Name = "CreatePersonalScheduleToolStripMenuItem";
            this.CreatePersonalScheduleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CreatePersonalScheduleToolStripMenuItem.Text = "Создать";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(587, 439);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewScheduleTeacher);
            this.tabPage1.Controls.Add(this.buttonFindFullTimeEdu);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(579, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Очная форма";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listViewScheduleTeacher
            // 
            this.listViewScheduleTeacher.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listViewScheduleTeacher.AutoArrange = false;
            this.listViewScheduleTeacher.GridLines = true;
            this.listViewScheduleTeacher.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewScheduleTeacher.HideSelection = false;
            this.listViewScheduleTeacher.Location = new System.Drawing.Point(20, 137);
            this.listViewScheduleTeacher.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listViewScheduleTeacher.Name = "listViewScheduleTeacher";
            this.listViewScheduleTeacher.Size = new System.Drawing.Size(543, 242);
            this.listViewScheduleTeacher.TabIndex = 29;
            this.listViewScheduleTeacher.UseCompatibleStateImageBehavior = false;
            this.listViewScheduleTeacher.View = System.Windows.Forms.View.Details;
            // 
            // buttonFindFullTimeEdu
            // 
            this.buttonFindFullTimeEdu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonFindFullTimeEdu.AutoSize = true;
            this.buttonFindFullTimeEdu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFindFullTimeEdu.Location = new System.Drawing.Point(438, 88);
            this.buttonFindFullTimeEdu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFindFullTimeEdu.Name = "buttonFindFullTimeEdu";
            this.buttonFindFullTimeEdu.Size = new System.Drawing.Size(125, 27);
            this.buttonFindFullTimeEdu.TabIndex = 28;
            this.buttonFindFullTimeEdu.Text = "Найти";
            this.buttonFindFullTimeEdu.UseVisualStyleBackColor = true;
            this.buttonFindFullTimeEdu.Click += new System.EventHandler(this.buttonFindFullTimeEdu_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(205, 48);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(357, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 27;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.Location = new System.Drawing.Point(206, 91);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(16, 92);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Выберите дату";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(16, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Введите фамилию";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(201, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "Поиск расписания";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 389);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 389);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(282, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Дата обновления расписания очной формы обучения:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.dateTimePicker2);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(579, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Заочная форма";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(20, 137);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(543, 242);
            this.listView1.TabIndex = 49;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Занятия";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 350;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(438, 88);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 27);
            this.button1.TabIndex = 48;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(205, 48);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(357, 21);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 47;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker2.Location = new System.Drawing.Point(206, 91);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker2.TabIndex = 46;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(16, 92);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 20);
            this.label10.TabIndex = 45;
            this.label10.Text = "Выберите дату";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(16, 48);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 20);
            this.label11.TabIndex = 44;
            this.label11.Text = "Введите фамилию";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(201, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 24);
            this.label12.TabIndex = 43;
            this.label12.Text = "Поиск расписания";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(502, 389);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(10, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "-";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(203, 389);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label15.Size = new System.Drawing.Size(294, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Дата обновления расписания заочной формы обучения:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.comboBox3);
            this.tabPage3.Controls.Add(this.dateTimePicker3);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(579, 413);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Институт магистратуры";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listView2.AutoArrange = false;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(20, 137);
            this.listView2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(543, 242);
            this.listView2.TabIndex = 58;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Занятия";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 350;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.AutoSize = true;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(438, 88);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 27);
            this.button2.TabIndex = 57;
            this.button2.Text = "Найти";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(205, 48);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(357, 21);
            this.comboBox3.Sorted = true;
            this.comboBox3.TabIndex = 56;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker3.Location = new System.Drawing.Point(206, 91);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker3.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 54;
            this.label3.Text = "Выберите дату";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(16, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Введите фамилию";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(201, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 24);
            this.label5.TabIndex = 52;
            this.label5.Text = "Поиск расписания";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 389);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "-";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(164, 389);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(334, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Дата обновления расписания занятий института магистратуры:";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 467);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(611, 17);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Visible = false;
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть папку";
            // 
            // ToolStripMenuItemFullTimeEduPersSch
            // 
            this.ToolStripMenuItemFullTimeEduPersSch.Name = "ToolStripMenuItemFullTimeEduPersSch";
            this.ToolStripMenuItemFullTimeEduPersSch.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemFullTimeEduPersSch.Text = "Очная форма";
            this.ToolStripMenuItemFullTimeEduPersSch.Click += new System.EventHandler(this.ToolStripMenuItemFullTimeEduPersSch_Click);
            // 
            // заочнаяФормаToolStripMenuItem
            // 
            this.заочнаяФормаToolStripMenuItem.Name = "заочнаяФормаToolStripMenuItem";
            this.заочнаяФормаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.заочнаяФормаToolStripMenuItem.Text = "Заочная форма";
            // 
            // магистратураToolStripMenuItem
            // 
            this.магистратураToolStripMenuItem.Name = "магистратураToolStripMenuItem";
            this.магистратураToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.магистратураToolStripMenuItem.Text = "Магистратура";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(611, 483);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Расписание";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFullTimeEdu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExtraStud;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMagistr;
        private System.Windows.Forms.ToolStripMenuItem формированиеРасписанияНаСтендToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расписаниеПреподовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreatePersonalScheduleToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFindFullTimeEdu;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateGeneralSchedule;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.ListView listViewScheduleTeacher;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFullTimeEduPersSch;
        private System.Windows.Forms.ToolStripMenuItem заочнаяФормаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem магистратураToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

