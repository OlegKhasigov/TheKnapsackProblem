using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeWinForms
{
    public class FrontalDescent
    {
        #region Свойства

        public int numberOfVariables { get; set; } // Количество переменных
        public int numberOfLimits { get; set; }    // Количество строк ограничений
        public string target { get; set; }    // Куда стремится целевая функция

        public List<int> targetFunc { get; set; } // Список элементов целевой фукнции

        public int[,] limits;   // Ограничения
        public List<int> results { get; set; } // Список значений ограничений
        public List<string> signs { get; set; } // список знаков

        //public List<Peak> frontOfPeaks { get; set; } // Список всех вершин
        public List<Peak> frontOfPeaks = new List<Peak>(); // Список всех вершин

        Peak answerPeak; // Оптимальное решение

        #endregion

        public FrontalDescent()
        {
            targetFunc = new List<int>();
            limits = new int[numberOfVariables, numberOfLimits];
            results = new List<int>();
            signs = new List<string>();
        }
        
        public Peak StartCalculations()
        {            
            List<int> peaksSumLimits = new List<int>(); // Исходная сумма ограничений

            int sum = 0;

            // Считаю сумму элементов ограничения и записываю в список
            for (int i = 0; i < numberOfLimits; i++)
            {
                if (signs[i] == "<=")
                {
                    peaksSumLimits.Add(0);
                }
                else
                {
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        sum += limits[i, j];
                    }
                    peaksSumLimits.Add(sum);

                }
                sum = 0;
            }

            #region Решение

            if (target == "max")
                sum = targetFunc.Sum();              // Сумма целевой функции  

            int tempSum ;                         // Текущая сумма целевой функции
            List<int> tempResults = new List<int>(); // Текущие значения ограничений

            Peak currentPeak;

            // Расчет первых двух вершин
            for (int j = 0; j < 2; j++)
            {
                // Вычисление целевой фукнции
                if (target == "min")
                    tempSum = targetFunc[0] * j;
                else
                    tempSum = sum - targetFunc[0] + targetFunc[0] * j;

                // Вычисление ограничений               
                for (int l = 0; l < numberOfLimits; l++)
                {
                    if (signs[l] == "<=")
                        tempResults.Add(limits[l, 0] * j);
                    else
                        tempResults.Add(peaksSumLimits[l] - limits[l, 0] + limits[l, 0] * j);
                }

                currentPeak = new Peak(j.ToString(), tempSum, tempResults); // Создание вершины

                frontOfPeaks.Add(currentPeak); // Запись вершины в список
               // Print(currentPeak);     // Вывод на экран 

                tempResults.Clear();    // Очистить список ограничений
            }

            // Расчет следующих вершин
            while (SearchAnswer())
            {
                int currentPath = OptimalPath(); // Выбираем лучшую вершину и продолжаем из нее
                int currentVariable = frontOfPeaks[currentPath].getPath().Length; // Вычисление для дочерних вершин текущей вершины
                sum = frontOfPeaks[currentPath].getTargetValue();

                // Вычисление вершин 1 и 0
                for (int j = 0; j < 2; j++)
                {
                    if (target == "min")
                        tempSum = sum + targetFunc[currentVariable] * j;
                    else
                        tempSum = sum - targetFunc[currentVariable] + targetFunc[currentVariable] * j;


                    // Вычисление ограничений
                    for (int l = 0; l < numberOfLimits; l++)
                    {
                        if (signs[l] == "<=")
                            tempResults.Add(frontOfPeaks[currentPath].getValuesOfLimits()[l] + limits[l, currentVariable] * j); // limits[Строка, столбец]
                        else
                            tempResults.Add(frontOfPeaks[currentPath].getValuesOfLimits()[l] - limits[l, currentVariable] + limits[l, currentVariable] * j);
                    }

                    currentPeak = new Peak(frontOfPeaks[currentPath].getPath() + j.ToString(), tempSum, tempResults);


                    if (Check(tempResults, results, signs))
                        frontOfPeaks.Add(currentPeak);

                    tempResults.Clear();
                   // Print(currentPeak);
                }

                frontOfPeaks.RemoveAt(currentPath);
            }

            return answerPeak;
            #endregion
        }


        // Вывод вершины
        private static void Print(Peak peak)
        {
            string text = "";
            for (int i = 0; i < peak.getValuesOfLimits().Count; i++)
                text += peak.getValuesOfLimits()[i] + "; ";

            Console.WriteLine($"\nPath: {peak.getPath()}\nTarget: {peak.getTargetValue()}\nLimits: {text}\n");
        }


        // Проверить ограничения
        private static bool Check(List<int> tempResults, List<int> results, List<string> signs)
        {
            bool check = true;

            for (int i = 0; i < tempResults.Count; i++)
            {
                if (signs[i] == "<=")
                {
                    if (tempResults[i] > results[i])
                    {
                        check = false;
                        break;
                    }
                }
                if (signs[i] == ">=")
                {
                    if (tempResults[i] < results[i])
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }


        // Проверка нашелся ли ответ
        private bool SearchAnswer()
        {
            bool check = true;

            if (target == "max")
            {
                int max = frontOfPeaks[0].getTargetValue();

                for (int i = 0; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getTargetValue() > max)
                        max = frontOfPeaks[i].getTargetValue();
                }

                for (int i = 0; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getTargetValue() == max && frontOfPeaks[i].getPath().Length == numberOfVariables)
                    {
                        check = false;
                        answerPeak = frontOfPeaks[i];
                        Console.WriteLine($"Ответ:");
                        Print(frontOfPeaks[i]);
                        break;
                    }
                }
            }
            else
            {
                int min = frontOfPeaks[0].getTargetValue();
                for (int i = 0; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getTargetValue() < min)
                        min = frontOfPeaks[i].getTargetValue();
                }

                for (int i = 0; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getTargetValue() == min && frontOfPeaks[i].getPath().Length == numberOfVariables)
                    {
                        check = false;
                        answerPeak = frontOfPeaks[i];
                        Console.WriteLine($"Ответ");
                        Print(frontOfPeaks[i]);

                        break;
                    }
                }
            }
            return check;
        }


        // Находим лучший путь
        private int OptimalPath()
        {
            int numOfPeak = 0;
            int optimalTarget = frontOfPeaks[0].getTargetValue();

            if (target == "max")
            {
                for (int i = 1; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getTargetValue() > optimalTarget)
                    {
                        numOfPeak = i;
                        optimalTarget = frontOfPeaks[i].getTargetValue();
                    }
                }
            }
            else
            {
                for (int i = 1; i < frontOfPeaks.Count; i++)
                {
                    if (frontOfPeaks[i].getTargetValue() < optimalTarget)
                    {
                        numOfPeak = i;
                        optimalTarget = frontOfPeaks[i].getTargetValue();
                    }
                }
            }
            return numOfPeak;
        }
    }
}
