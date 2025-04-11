using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PracticeWinForms
{
    // Композитный метод фронтального спуска
    public class CompositeMethod
    {
        #region Свойства

        // Backpack
        public int numberOfVariables { get; set; } // Кол-во переменных
        public int numberOfLimits { get; set; }    // Кол-во ограничений
        public string target {get; set;}     // К чему стремится целевая функция 

        public List<int> targetFunc { get; set; } // Список элементов целевой функции 
        public int[,] limits;   // Ограничения [Строка, Столбец]
        public List<int> results { get; set; } // Список значений ограничений
        public List<string> signs { get; set; } // Список знаков (>=, <=)

        public List<int> listOfLimitAmount { get; set; } // Исходная сумма ограничений

        // Module
        public int numberOfModules { get; set; }  // Кол-во модулей
        public int moduleSize { get; set; }  // Размер модуля
        public List<Module> modules { get; set; }  // Для сохранения модулей

        // Peaks
        public List<Peak> frontOfPeaks { get; set; }  // Фронт висячих вершин

        Peak answerPeak; // Оптимальное решение

        int iteration = 0; // Счетчик итераций

        #endregion
       
        // Конструктор класса
        public CompositeMethod()
        {
            targetFunc = new List<int>(); // Список элементов целевой функции 
            limits = new int[numberOfLimits, numberOfVariables];   // Ограничения
            results = new List<int>(); // Список значений ограничений
            signs = new List<string>();// Список знаков (>=, <=)
        }
        public Peak StartCalculations()
        {
            moduleSize = numberOfVariables / numberOfModules;

            listOfLimitAmount = new List<int>();
            modules = new List<Module>(); // Для сохранения модулей
            frontOfPeaks = new List<Peak>();  // Фронт висячих вершин
            int sum = 0;

            // Считаю сумму элементов ограничения и записываю в список
            for (int i = 0; i < numberOfLimits; i++)
            {
                if (signs[i] == "<=")
                    listOfLimitAmount.Add(0);
                else
                {
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        sum += limits[i, j];
                    }
                    listOfLimitAmount.Add(sum);
                }
                sum = 0;
            }

            //Console.WriteLine("Базовые модули");
            CreateModules(); // Создание модулей и запись их в список modules

            DeleteWorsePeaks(); // Удаление плохих вершин
                                //PrintModules();  // Вывод модулей

            // Вывод фронта висячих вершин на экран
            frontOfPeaks = modules[0].getPeaks();
            //Console.WriteLine("\n\nФронт висячих вершин");
            //PrintFrontOfPeaks();

            // Алгоритм фронтального спуска
            while (SearchAnswer())
            {
                Peak currentPeak = frontOfPeaks[SearchOptimalPeak()]; // Возвращает оптимальную вершину из frontOfPeaks для продолжения дерева
                Peak newPeak;

                int currentModule = currentPeak.getPath().Length / moduleSize; // Определяем следующий модуль 

                if (currentPeak.getPath().Length == numberOfVariables)
                    currentModule = numberOfModules;

                string path;
                int targetValue;
                List<int> limitsValues = new List<int>();
                int limit;
                int perspective = 0;
                bool check;

                List<Peak> peaksFromModule = modules[currentModule].getPeaks(); // Берем вершины из следующего модуля

                for (int i = 0; i < peaksFromModule.Count; i++)
                {
                    path = currentPeak.getPath() + peaksFromModule[i].getPath(); // Новый путь (тек. вершина + вершина из след. модуля)
                    targetValue = currentPeak.getTargetValue() + peaksFromModule[i].getTargetValue(); // Целевая новой вершины
                    check = false;

                    for (int k = 0; k < numberOfLimits; k++) // Расчет ограничений
                    {
                        if (signs[k] == "<=")
                        {
                            limit = currentPeak.getValuesOfLimits()[k] + peaksFromModule[i].getValuesOfLimits()[k];

                            if (limit > results[k])
                            {
                                check = true;
                                break;
                            }
                        }
                        else
                        {
                            limit = listOfLimitAmount[k];

                            // Посчитать с помощью нового пути
                            for (int p = 0; p < path.Length; p++)
                                limit += -limits[k, p] + limits[k, p] * Convert.ToInt32(path[p].ToString());

                            if (limit < results[k])
                            {
                                check = true;
                                break;
                            }
                        }

                        limitsValues.Add(limit);
                    }
                    if (check)
                    {
                        limitsValues.Clear();
                        continue;
                    }
                    // Расчет потенциала
                    if (target == "max")
                    {
                        perspective = targetFunc.Sum();
                        // Посчитать с помощью нового пути
                        for (int p = 0; p < path.Length; p++)
                            perspective += -targetFunc[p] + targetFunc[p] * Convert.ToInt32(path[p].ToString());
                    }

                    newPeak = new Peak(path, targetValue, limitsValues, perspective);

                    frontOfPeaks.Add(newPeak);
                    limitsValues.Clear();
                }

                frontOfPeaks.Remove(currentPeak); // Удаляем использованную вершину 

                //Console.WriteLine($"\nИтерация {++iteration}");
                // PrintFrontOfPeaks();
            }

            return answerPeak;
        }

        // Проверка на наличие оптимального решения среди фронта висячих вершин. Надо исправить
        private bool SearchAnswer()
        {

            bool resume = true;

            if (frontOfPeaks.Count == 0)
            {
                //MessageBox.Show("Решения нет");
                resume = false;
            }

            int optimalTargetValue = frontOfPeaks[0].getTargetValue();

            if (target == "max")
            {
                for (int i = 0; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getPotential() > optimalTargetValue)
                        optimalTargetValue = frontOfPeaks[i].getPotential();
                }
            }
            else
            {
                for (int i = 0; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getTargetValue() < optimalTargetValue)
                        optimalTargetValue = frontOfPeaks[i].getTargetValue();
                }
            }

            for (int i = 0; i < frontOfPeaks.Count; i++)
            {
                if (frontOfPeaks[i].getTargetValue() == optimalTargetValue && frontOfPeaks[i].getPath().Length == numberOfVariables)
                {
                    resume = false;
                    answerPeak = frontOfPeaks[i];
                    Console.WriteLine("\nОтвет:");
                    PrintPeak(frontOfPeaks[i]);

                    break;
                }
            }

            return resume;
        }

        // Найти оптимальную вершину
        private int SearchOptimalPeak()
        {
            int numOfPeak = 0;
            int optimalTarget;
            string path = frontOfPeaks[numOfPeak].getPath();

            if (target == "max")
            {
                optimalTarget = frontOfPeaks[numOfPeak].getPotential();

                for (int i = 1; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getPotential() > optimalTarget)
                    {
                        numOfPeak = i;
                        optimalTarget = frontOfPeaks[i].getPotential();
                        path = frontOfPeaks[i].getPath();
                    }

                    if (frontOfPeaks[i].getPotential() == optimalTarget)
                    {
                        if(frontOfPeaks[i].getPath().Length > path.Length)
                        {
                            numOfPeak = i;
                            optimalTarget = frontOfPeaks[i].getPotential();
                            path = frontOfPeaks[i].getPath();
                        }
                    }

                }
            }
            else
            {
                optimalTarget = frontOfPeaks[numOfPeak].getTargetValue();

                for (int i = 1; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getTargetValue() < optimalTarget)
                    {
                        numOfPeak = i;
                        optimalTarget = frontOfPeaks[i].getTargetValue();
                    }

                    if (frontOfPeaks[i].getTargetValue() == optimalTarget)
                    {
                        if (frontOfPeaks[i].getPath().Length > path.Length)
                        {
                            numOfPeak = i;
                            optimalTarget = frontOfPeaks[i].getTargetValue();
                            path = frontOfPeaks[i].getPath();
                        }
                    }
                }
            }
            return numOfPeak;
        }

        // Удалить худшие вершины из модулей
        private void DeleteWorsePeaks()
        {
            for (int k = 0; k < modules.Count; k++)
            {
                List<Peak> peaks = modules[k].getPeaks();

                for (int i = 0; i < peaks.Count; i++)
                {
                    for (int j = 0; j < peaks.Count; j++)
                    {
                        if (i == j) continue;

                        bool worse = true;

                        if (target == "max")
                        {
                            if (peaks[i].getTargetValue() < peaks[j].getTargetValue())
                            {
                                worse = false;
                                continue;
                            }
                        }
                        else
                        {
                            if (peaks[i].getTargetValue() > peaks[j].getTargetValue())
                            {
                                worse = false;
                                continue;
                            }
                        }

                        for (int t = 0; t < numberOfLimits; t++)
                        {
                            if (signs[t] == "<=")
                            {
                                if (peaks[i].getValuesOfLimits()[t] > peaks[j].getValuesOfLimits()[t])
                                {
                                    worse = false;
                                    continue;
                                }
                            }
                            else
                            {
                                if (peaks[i].getValuesOfLimits()[t] < peaks[j].getValuesOfLimits()[t])
                                {
                                    worse = false;
                                    continue;
                                }
                            }
                        }
                        if (worse)
                        {
                            modules[k].getPeaks().RemoveAt(j);
                            j--;

                            if(i > 0)
                                i--;
                        }
                    }
                }
            }
        }

        // Создание модулей 
        private void CreateModules()
        {
            List<Peak> peaks = new List<Peak>(); // Временный список вершин
            Peak peak;                           // Временная вершина
            Module module;                       // Временный модуль

            // Создание путей
            #region Creating paths

            List<string> paths1 = new List<string>(); // Список путей
            List<string> paths2 = new List<string>(); // Пути последнего модуля
            List<int> moduleSizes = new List<int>(); // Размеры модулей
            int currentSize;

            for (int i = 0; i < numberOfModules; i++)
            {
                if (i == numberOfModules - 1)
                    currentSize = numberOfVariables / numberOfModules + numberOfVariables % numberOfModules;
                else
                    currentSize = numberOfVariables / numberOfModules;

                moduleSizes.Add(currentSize);
            }
            moduleSizes = moduleSizes.Distinct().ToList(); // Удаляем повторы 

            string text, path;

            for (int j = 0; j < moduleSizes.Count; j++)
            {
                text = "";
                for (int i = 0; i < moduleSizes[j]; i++)
                    text += "0";

                for (int i = 0; i < Math.Pow(2, moduleSizes[j]); i++)
                {
                    path = Convert.ToString(i, 2);
                    path = text.Substring(path.Length) + path; // Было path.Length

                    if (j == moduleSizes.Count-1 && moduleSizes.Count >= 2)
                        paths2.Add(path);
                    else
                        paths1.Add(path);
                }
            }

            #endregion

            int offset = 0; // Смещение на две переменные вправо
            int targetValue; // Значение целевой функции
            List<int> tempLimits = new List<int>(); // Временные значения ограничений вершины
            int limit; // Временное значение ограничения
            int perspective; // Значение перспективы вершины

            bool check; // Проверка ограничений

            List<string> paths = new List<string>();

            for (int i = 0; i < numberOfModules; i++)
            {
                if (i == numberOfModules - 1 && paths2.Count > 0)
                    paths = paths2;
                else
                    paths = paths1;

                for (int p = 0; p < paths.Count; p++)
                {
                    path = paths[p];
                    targetValue = 0;
                    check = false;
                    // Вычисление целевой функции
                    for (int j = 0; j < path.Length; j++)
                        targetValue += targetFunc[offset + j] * Convert.ToInt32(path[j].ToString());

                    // Вычисление ограничений 
                    for(int k = 0; k < numberOfLimits; k++)
                    {
                        if(signs[k] == "<=")
                        {
                            limit = 0;

                            for (int j = 0; j < path.Length; j++)
                                limit += limits[k, offset + j] * Convert.ToInt32(path[j].ToString());

                            if(limit > results[k])
                            {
                                check = true;
                                break;
                            }
                        }
                        else
                        {
                            limit = listOfLimitAmount[k];

                            for (int j = 0; j < path.Length; j++)
                                limit += -limits[k, offset + j] + limits[k, offset + j] * Convert.ToInt32(path[j].ToString());

                            if (limit < results[k])
                            {
                                check = true;
                                break;
                            }
                        }
                                                
                        tempLimits.Add(limit);
                    }

                    if (check)
                    {
                        tempLimits.Clear();
                        continue;
                    }
                    // Вычисление перспективы вершины, только для первого модуля
                    if (offset == 0 && target == "max")
                    {
                        perspective = targetFunc.Sum();

                        for (int j = 0; j < path.Length; j++)
                            perspective += -targetFunc[offset + j] + targetFunc[offset + j] * Convert.ToInt32(path[j].ToString());
                    }
                    else
                        perspective = 0;

                    peak = new Peak(paths[p], targetValue, tempLimits, perspective);
                    peaks.Add(peak);

                    tempLimits.Clear();
                }

                module = new Module(peaks);
                modules.Add(module);

                peaks.Clear();

                offset += moduleSizes[0];
            }
        }

        // Вывод модулей на экран
        private void PrintModules()
        {
            for (int i = 0; i < modules.Count; i++)
            {
                Console.WriteLine($"\n\nModule {i+1}");

                if(target == "max")
                    Console.WriteLine("Path|\tF\t|\tR\t\t|\tU");
                else
                    Console.WriteLine("Path|\tF\t|\tR\t");

                List<Peak> peaks = modules[i].getPeaks();

                for (int j = 0; j < peaks.Count; j++)
                    PrintPeak(peaks[j]);
            }
        }

        // Вывод на экран список висячих вершин
        private void PrintFrontOfPeaks()
        {
            if (target == "max")
                Console.WriteLine("Path|\tF\t|\tR\t\t|\tU");
            else
                Console.WriteLine("Path|\tF\t|\tR\t");

            for (int j = 0; j < frontOfPeaks.Count; j++)
                PrintPeak(frontOfPeaks[j]);
        }

        // Вывод на экран вершину
        private void PrintPeak(Peak peak)
        {
            string text = "";
            for (int k = 0; k < peak.getValuesOfLimits().Count; k++)
                text += peak.getValuesOfLimits()[k] + "; ";

            if (target == "max")
                Console.WriteLine($"{peak.getPath()}\t|\t{peak.getTargetValue()}\t|\t{text}\t|\t{peak.getPotential()}");
            else
                Console.WriteLine($"{peak.getPath()}\t|\t{peak.getTargetValue()}\t|\t{text}");
        }
    }
}
