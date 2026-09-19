using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Java;
using System.Text;

namespace Starostin.KD_ZIVT_251_OOP2
{
    public enum Gender { Мужской, Женский}

    // Основной класс ученика
    public class Pupil
    {
        private static Random random = new Random();

        public string Surname;
        public string Name;
        public Gender Gender;

        protected int? Mark = null;

        // Конструктор без параметров
        public Pupil()
        {
            Surname = "Неизвестно";
            Name = "Неизвестно";
            Gender = Gender.Мужской;
        }

        // Конструктор с параметрами
        public Pupil(string surname, string name, Gender gender)
        {
            Surname = surname;
            Name = name;
            Gender = gender;
        }

        // Виртуальное свойство получения оценки
        public virtual int GetCurrentGrade
        {
            get
            {
                if (!Mark.HasValue)
                {
                    Mark = random.Next(2, 6);
                }
                return Mark.Value;
            }
        }
        
        // Методы ученика
        public virtual string Study()
        {
            return ($"{Surname} {Name} учится");
        }

        public virtual string Read()
        {
            return ($"{Surname} {Name} читает");
        }

        public virtual string Write()
        {
            return ($"{Surname} {Name} пишет");
        }

        public virtual string Relax()
        {
            return ($"{Surname} {Name} отдыхает");
        }

        public void ResetMark()
        {
            Mark = null;
        }
    }

    // Класс отличник
    public class ExcelentPupil : Pupil
    {
        private static Random random = new Random();

        // Конструктор без параметров
        public ExcelentPupil() : base()
        {

        }

        // Конструктор с параметрами
        public ExcelentPupil(string surname, string name, Gender gender): base(surname, name, gender)
        {

        }

        // Переопределение метода получения оценки
        public override int GetCurrentGrade
        {
            get
            {
                if (!Mark.HasValue)
                {
                    int chance = random.Next(1, 101);
                    if (chance <= 85) Mark = 5;      // 85% вероятность получить 5
                    else if (chance <= 95) Mark = 4;  // 10% вероятность получить 4
                    else if (chance <= 99) Mark = 3;  // 4% вероятность получить 3
                    else Mark = 2;                    // 1% вероятность получить 2
                }
                return Mark.Value;
            }
        }

        // Методы отличника
        public override string Study()
        {
            return ($"{Surname} {Name} усердно учится");
        }

        public override string Read()
        {
            return ($"{Surname} {Name} много читает");
        }

        public override string Write()
        {
            return ($"{Surname} {Name} красиво пишет");
        }

        public override string Relax()
        {
            return ($"{Surname} {Name} ERROR 404: Метод не найден");
        }

    }

    //Класс хорошист
    public class GoodPupil : Pupil
    {
        private static Random random = new Random();

        // Конструктор без параметров
        public GoodPupil() : base()
        {

        }

        // Конструктор с параметрами
        public GoodPupil(string surname, string name, Gender gender) : base(surname, name, gender)
        {

        }

        // Переопределение метода получения оценки
        public override int GetCurrentGrade
        {
            get
            {
                if (!Mark.HasValue)
                {
                    int chance = random.Next(1, 101);
                    if (chance <= 50) Mark = 5;      // 50% вероятность получить 5
                    else if (chance <= 90) Mark = 4;  // 40% вероятность получить 4
                    else if (chance <= 97) Mark = 3;  // 7% вероятность получить 3
                    else Mark = 2;                    // 3% вероятность получить 2
                }
                return Mark.Value;
            }
        }

        // Методы хорошиста
        public override string Study()
        {
            return ($"{Surname} {Name} спокойно учится");
        }

        public override string Read()
        {
            return ($"{Surname} {Name} чуть-чуть читает");
        }

        public override string Write()
        {
            return ($"{Surname} {Name} пишет");
        }

        public override string Relax()
        {
            return ($"{Surname} {Name} чилит");
        }

    }

    // Класс троешник
    public class BadPupil : Pupil
    {
        private static Random random = new Random();

        // Конструктор без параметров
        public BadPupil() : base()
        {

        }

        // Конструктор с параметрами
        public BadPupil(string surname, string name, Gender gender) : base(surname, name, gender)
        {

        }

        // Переопределение метода получения оценки
        public override int GetCurrentGrade
        {
            get
            {
                if (!Mark.HasValue)
                {
                    int chance = random.Next(1, 101);
                    if (chance <= 10) Mark = 5;      // 10% вероятность получить 5
                    else if (chance <= 40) Mark = 4;  // 30% вероятность получить 4
                    else if (chance <= 90) Mark = 3;  // 50% вероятность получить 3
                    else Mark = 2;                    // 10% вероятность получить 2
                }
                return Mark.Value;
            }
        }

        // Методы троешника
        public override string Study()
        {
            return Relax();
        }

        public override string Read()
        {
            return Relax();
        }

        public override string Write()
        {
            return Relax();
        }

        public override string Relax()
        {
            return ($"{Surname} {Name} чилит");
        }

    }
}
