namespace PracticeWinForms
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.textBoxCntModules = new System.Windows.Forms.TextBox();
            this.textBoxCntLimits = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCntVariables = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.WorkingTime1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ToSolve = new System.Windows.Forms.Button();
            this.WorkingTime2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridBackpack2 = new System.Windows.Forms.DataGridView();
            this.FillRandom = new System.Windows.Forms.Button();
            this.dataGridBackpack = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTarget = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackpack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackpack)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonConfirm);
            this.groupBox1.Controls.Add(this.textBoxCntModules);
            this.groupBox1.Controls.Add(this.textBoxCntLimits);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxCntVariables);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Размерность задачи";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(90, 228);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(119, 44);
            this.buttonConfirm.TabIndex = 8;
            this.buttonConfirm.Text = "Ok";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // textBoxCntModules
            // 
            this.textBoxCntModules.Location = new System.Drawing.Point(183, 158);
            this.textBoxCntModules.Name = "textBoxCntModules";
            this.textBoxCntModules.Size = new System.Drawing.Size(100, 26);
            this.textBoxCntModules.TabIndex = 5;
            // 
            // textBoxCntLimits
            // 
            this.textBoxCntLimits.Location = new System.Drawing.Point(183, 95);
            this.textBoxCntLimits.Name = "textBoxCntLimits";
            this.textBoxCntLimits.Size = new System.Drawing.Size(100, 26);
            this.textBoxCntLimits.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Кол-во модулей:";
            // 
            // textBoxCntVariables
            // 
            this.textBoxCntVariables.Location = new System.Drawing.Point(183, 38);
            this.textBoxCntVariables.Name = "textBoxCntVariables";
            this.textBoxCntVariables.Size = new System.Drawing.Size(100, 26);
            this.textBoxCntVariables.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Кол-во ограничений:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол-во переменных:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dataGridBackpack2);
            this.groupBox2.Controls.Add(this.FillRandom);
            this.groupBox2.Controls.Add(this.dataGridBackpack);
            this.groupBox2.Location = new System.Drawing.Point(357, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(872, 495);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ранец";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.WorkingTime1);
            this.groupBox4.Location = new System.Drawing.Point(359, 311);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(233, 164);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Фронтальный спуск";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "Решить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Время:";
            // 
            // WorkingTime1
            // 
            this.WorkingTime1.AutoSize = true;
            this.WorkingTime1.Location = new System.Drawing.Point(91, 117);
            this.WorkingTime1.Name = "WorkingTime1";
            this.WorkingTime1.Size = new System.Drawing.Size(0, 20);
            this.WorkingTime1.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ToSolve);
            this.groupBox3.Controls.Add(this.WorkingTime2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(618, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 164);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Композитный метод";
            // 
            // ToSolve
            // 
            this.ToSolve.Location = new System.Drawing.Point(26, 47);
            this.ToSolve.Name = "ToSolve";
            this.ToSolve.Size = new System.Drawing.Size(101, 44);
            this.ToSolve.TabIndex = 2;
            this.ToSolve.Text = "Решить";
            this.ToSolve.UseVisualStyleBackColor = true;
            this.ToSolve.Click += new System.EventHandler(this.button2_Click);
            // 
            // WorkingTime2
            // 
            this.WorkingTime2.AutoSize = true;
            this.WorkingTime2.Location = new System.Drawing.Point(90, 117);
            this.WorkingTime2.Name = "WorkingTime2";
            this.WorkingTime2.Size = new System.Drawing.Size(0, 20);
            this.WorkingTime2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Время:";
            // 
            // dataGridBackpack2
            // 
            this.dataGridBackpack2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridBackpack2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridBackpack2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBackpack2.Location = new System.Drawing.Point(606, 28);
            this.dataGridBackpack2.Name = "dataGridBackpack2";
            this.dataGridBackpack2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridBackpack2.RowTemplate.Height = 28;
            this.dataGridBackpack2.Size = new System.Drawing.Size(245, 243);
            this.dataGridBackpack2.TabIndex = 3;
            // 
            // FillRandom
            // 
            this.FillRandom.Location = new System.Drawing.Point(21, 311);
            this.FillRandom.Name = "FillRandom";
            this.FillRandom.Size = new System.Drawing.Size(119, 44);
            this.FillRandom.TabIndex = 1;
            this.FillRandom.Text = "Заполнить";
            this.FillRandom.UseVisualStyleBackColor = true;
            this.FillRandom.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridBackpack
            // 
            this.dataGridBackpack.AllowUserToAddRows = false;
            this.dataGridBackpack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridBackpack.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridBackpack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBackpack.Location = new System.Drawing.Point(21, 28);
            this.dataGridBackpack.Name = "dataGridBackpack";
            this.dataGridBackpack.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridBackpack.RowTemplate.Height = 28;
            this.dataGridBackpack.Size = new System.Drawing.Size(571, 243);
            this.dataGridBackpack.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxPath);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.labelTarget);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(12, 324);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(312, 184);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Результат";
            // 
            // textBoxPath
            // 
            this.textBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPath.Location = new System.Drawing.Point(71, 98);
            this.textBoxPath.Multiline = true;
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxPath.Size = new System.Drawing.Size(222, 63);
            this.textBoxPath.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "F:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Path:";
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.Location = new System.Drawing.Point(81, 47);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(0, 20);
            this.labelTarget.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 579);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackpack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackpack)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ToSolve;
        private System.Windows.Forms.Button FillRandom;
        private System.Windows.Forms.DataGridView dataGridBackpack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label WorkingTime2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridBackpack2;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label WorkingTime1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBoxCntModules;
        private System.Windows.Forms.TextBox textBoxCntLimits;
        private System.Windows.Forms.TextBox textBoxCntVariables;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.TextBox textBoxPath;
    }
}

