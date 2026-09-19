using Starostin.KD_ZIVT_251_OOP2;

// Создаем учеников
Pupil pupil1 = new ExcelentPupil("Старостин", "Кирилл", Gender.Мужской);
Pupil pupil2 = new GoodPupil("Лепилина", "Полина", Gender.Женский);
Pupil pupil3 = new GoodPupil("Дзигилевич", "Арина", Gender.Женский);
Pupil pupil4 = new BadPupil("Жмайло", "Алекандр", Gender.Мужской);
Pupil pupil5 = new BadPupil("Петренко", "Евгений", Gender.Мужской);
Pupil pupil6 = new ExcelentPupil("Наместникова", "Екатерина", Gender.Женский);
Pupil pupil7 = new ExcelentPupil("Какенов", "Ильяс", Gender.Мужской);
Pupil pupil8 = new BadPupil("Своротенин", "Александр", Gender.Мужской);
Pupil pupil9 = new ExcelentPupil("Гребенюк", "Павел", Gender.Мужской);
Pupil pupil10 = new GoodPupil("Гришаева", "Дарья", Gender.Женский);
Pupil pupil11 = new ExcelentPupil("Терещенок", "Сергей", Gender.Мужской);

// Создаем классы
ClassRoom classRoom11а = new ClassRoom("11А", pupil1, pupil2, pupil3, pupil4);
ClassRoom classRoom11b = new ClassRoom("11Б", pupil5, pupil6, pupil7);
ClassRoom classRoom11c = new ClassRoom("11В", pupil8, pupil9);
ClassRoom classRoom11d = new ClassRoom("11Г", pupil10, pupil11);

// Выводим статистику по группам
Console.WriteLine("Статистика");
Console.WriteLine();
classRoom11а.GetMarks();
Console.WriteLine($"Средний балл группы {classRoom11а.Name} = {classRoom11а.GetRoundGrade}");
Console.WriteLine();
classRoom11b.GetMarks();
Console.WriteLine($"Средний балл группы {classRoom11b.Name} = {classRoom11b.GetRoundGrade}");
Console.WriteLine();
classRoom11c.GetMarks();
Console.WriteLine($"Средний балл группы {classRoom11c.Name} = {classRoom11c.GetRoundGrade}");
Console.WriteLine();
classRoom11d.GetMarks();
Console.WriteLine($"Средний балл группы {classRoom11d.Name} = {classRoom11d.GetRoundGrade}");
Console.WriteLine();

// Выводим методы учеников
Console.WriteLine("Действия");
Console.WriteLine(pupil1.Study());
Console.WriteLine(pupil2.Relax());
Console.WriteLine(pupil3.Read());
Console.WriteLine(pupil4.Study());
Console.WriteLine(pupil5.Write());
Console.WriteLine(pupil6.Write());
Console.WriteLine(pupil7.Relax());
Console.WriteLine(pupil8.Study());
Console.WriteLine(pupil9.Read());
Console.WriteLine(pupil10.Write());
Console.WriteLine(pupil11.Study());

Console.ReadKey();