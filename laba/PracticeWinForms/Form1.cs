using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace PracticeWinForms
{
    public partial class Form1 : Form
    {
        // Переменные ранца
        static int cntVariables, cntLimits, cntModules;
        string target;
        List<int> targetFunc = new List<int>();
        List<string> signs = new List<string>();
        List<int> results = new List<int>();
        int[,] limits = new int[cntLimits, cntVariables];
        public Form1()
        {
            InitializeComponent();
        }

        // Заполнение рандомом таблицу
        private void button1_Click(object sender, EventArgs e) 
        {
            try
            {
                Random random = new Random();

                // Заполнение первой таблицы
                for (int i = 0; i < cntLimits + 1; i++)
                {
                    for (int j = 0; j < cntVariables; j++)
                    {
                        dataGridBackpack.Rows[i].Cells[j].Value = random.Next(0, 20);
                    }
                }

                // Заполнение второй таблицы
                for (int i = 1; i < cntLimits + 1; i++)
                {
                    if (random.Next(0, 2) == 0)
                        dataGridBackpack2.Rows[i].Cells[0].Value = "<=";
                    else
                        dataGridBackpack2.Rows[i].Cells[0].Value = ">=";
                }

                if (random.Next(0, 2) == 0)
                    dataGridBackpack2.Rows[0].Cells[1].Value = "max";
                else
                    dataGridBackpack2.Rows[0].Cells[1].Value = "min";
            }
            catch
            {
                MessageBox.Show("Введите размерность задачи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        // Заполнение данных из таблицы
        private void FillVariables()
        {
            targetFunc.Clear();
            signs.Clear();
            results.Clear();
            
            // Заполнение данных из таблицы
            target = dataGridBackpack2.Rows[0].Cells[1].Value.ToString();
            limits = new int[cntLimits, cntVariables];

            for (int i = 0; i < cntVariables; i++)
            {
                targetFunc.Add(Convert.ToInt32(dataGridBackpack.Rows[0].Cells[i].Value));
            }

            for (int i = 0; i < cntLimits; i++)
            {
                signs.Add(dataGridBackpack2.Rows[i + 1].Cells[0].Value.ToString());

                if (dataGridBackpack2.Rows[i + 1].Cells[1].Value == null)
                    throw new Exception("Заполните все поля!");
                else
                    results.Add(Convert.ToInt32(dataGridBackpack2.Rows[i + 1].Cells[1].Value));
            }

            for (int i = 1; i < cntLimits + 1; i++)
            {
                for (int j = 0; j < cntVariables; j++)
                {
                    if(dataGridBackpack.Rows[i].Cells[j].Value == null) 
                        throw new Exception("Заполните все поля!");
                    else
                        limits[i - 1, j] = Convert.ToInt32(dataGridBackpack.Rows[i].Cells[j].Value);
                }
            }
        }

        // Решение композитным методом
        private void button2_Click(object sender, EventArgs e) // Решение задачи
        {
            try
            {
                // Заполнение данных из таблицы
                FillVariables();

                CompositeMethod compositeMethod = new CompositeMethod();

                compositeMethod.numberOfVariables = cntVariables;
                compositeMethod.numberOfLimits = cntLimits; 
                compositeMethod.target = target;

                compositeMethod.targetFunc = targetFunc;    
                compositeMethod.limits = limits;
                compositeMethod.signs = signs;
                compositeMethod.results = results;

                compositeMethod.numberOfModules = cntModules;

                // Секундомер
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                Peak peak = compositeMethod.StartCalculations();

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                WorkingTime2.Text = elapsedTime;

                if (peak.getTargetValue().ToString().Length == 0)
                    throw new Exception("Задача не имеет решений!");

                textBoxPath.Text = peak.getPath();
                labelTarget.Text = peak.getTargetValue().ToString();
            }
            catch (Exception ex)
            {
                if(ex.Message == "Заполните все поля!")
                    MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Задача не имеет решений!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Прекратить выполнение метода
            }
        }

        // Решение фронтальным спуском
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Заполнение данных из таблицы
                FillVariables();

                FrontalDescent frontalDescent = new FrontalDescent();

                frontalDescent.numberOfVariables = cntVariables;
                frontalDescent.numberOfLimits = cntLimits;

                frontalDescent.targetFunc = targetFunc;
                frontalDescent.target = target;

                frontalDescent.limits = limits;
                frontalDescent.signs = signs;
                frontalDescent.results = results;

                // Секундомер
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                Peak peak = frontalDescent.StartCalculations();

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                WorkingTime1.Text = elapsedTime;

                if (peak.getTargetValue().ToString().Length == 0)
                    throw new Exception("Задача не имеет решений!");

                textBoxPath.Text = peak.getPath();
                labelTarget.Text = peak.getTargetValue().ToString();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Заполните все поля!")
                    MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Задача не имеет решений!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Прекратить выполнение метода
            }
        }

        // Создать ранец указанной размерности 
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                cntVariables = Convert.ToInt32(textBoxCntVariables.Text);
                cntLimits = Convert.ToInt32(textBoxCntLimits.Text);
                cntModules = Convert.ToInt32(textBoxCntModules.Text);

                dataGridBackpack.Rows.Clear();
                dataGridBackpack2.Rows.Clear();

                // dataGridBackpack2
                dataGridBackpack.ColumnCount = cntVariables;
                dataGridBackpack.RowCount = cntLimits + 1;

                for (int i = 0; i < cntVariables; i++)
                    dataGridBackpack.Columns[i].HeaderText = $"X{i + 1}";

                dataGridBackpack.Rows[0].HeaderCell.Value = $"F";

                for (int i = 0; i < cntLimits; i++)
                    dataGridBackpack.Rows[i + 1].HeaderCell.Value = $"C{i + 1}";

                // dataGridBackpack2
                dataGridBackpack2.ColumnCount = 2;
                dataGridBackpack2.RowCount = cntLimits + 1;

                dataGridBackpack2.Columns[0].HeaderText = $"Sign";
                dataGridBackpack2.Columns[1].HeaderText = $"Target";
                dataGridBackpack2.Rows[0].Cells[0].Value = "=>";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
