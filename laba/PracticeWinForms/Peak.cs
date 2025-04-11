using System.Collections.Generic;

namespace PracticeWinForms
{
    // Класс вершин
    public class Peak
    {
        string path;       // Путь  (Пример 1011)
        int targetValue;   // Значение целевой функции
        List<int> limitsValues = new List<int>();   // Значения ограничений
        int potential; // Перспектива целевой функции у вершины
        public Peak(string path, int targetValue, List<int> listOfLimits)
        {
            this.path = path;
            this.targetValue = targetValue;
            //this.potential = -1;

            for (int i = 0; i < listOfLimits.Count; i++)
                limitsValues.Add(listOfLimits[i]);
        }

        public Peak(string path, int targetValue, List<int> listOfLimits, int potential)
        {
            this.path = path;
            this.targetValue = targetValue;
            this.potential = potential;

            for (int i = 0; i < listOfLimits.Count; i++)
                limitsValues.Add(listOfLimits[i]);
        }

        public string getPath() { return path; }
        public int getPotential() { return potential; }
        public void setPotential(int value) { potential = value; }
        public int getTargetValue() { return targetValue; }
        public List<int> getValuesOfLimits() { return limitsValues; }
    }
}
