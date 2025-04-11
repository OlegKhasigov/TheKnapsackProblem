using System.Collections.Generic;
namespace PracticeWinForms
{
    public class Module
    {
        List<Peak> peaks = new List<Peak>(); // Список вершин

        // Базовый модуль
        public Module(List<Peak> peaks)
        {
            List<int> limits = new List<int>();

            for (int i = 0; i < peaks.Count; i++)
            {
                for (int j = 0; j < peaks[i].getValuesOfLimits().Count; j++)
                    limits.Add(peaks[i].getValuesOfLimits()[j]);

                this.peaks.Add(new Peak(peaks[i].getPath(), peaks[i].getTargetValue(), limits, peaks[i].getPotential()));
                limits.Clear();
            }
        }

        public List<Peak> getPeaks() { return peaks; }
    }
}
