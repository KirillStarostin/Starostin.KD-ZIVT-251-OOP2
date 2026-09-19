using System;
using System.Collections.Generic;
using System.Text;

namespace Starostin.KD_ZIVT_251_OOP2
{
    public class ClassRoom
    {
        public static int PupilCount = 0;
        public string Name;
        private List<Pupil> pupils;

        // Свойство получения средней оценки
        public double GetRoundGrade
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < pupils.Count; i++)
                {
                    sum += pupils[i].GetCurrentGrade;
                }
                return Math.Round((double)sum / pupils.Count, 2);
            }
        }
        // Конструктор
        public ClassRoom(string name,params Pupil[] pupilsArray)
        {
            if (pupilsArray.Length < 2 || pupilsArray.Length > 4)
            {
                throw new ArgumentException("Класс должен содержать от 2 до 4 учеников");
            }
            pupils = new List<Pupil>(pupilsArray);
            PupilCount += pupilsArray.Length;
            Name = name;
        }

        // Метод вывода оценок учеников группы
        public void GetMarks()
        {
            Console.WriteLine("Оценки");
            for (int i = 0;i < pupils.Count;i++)
            {
                Console.WriteLine($"{pupils[i].Surname} : {pupils[i].GetCurrentGrade}");
            }
        }
    }
}
