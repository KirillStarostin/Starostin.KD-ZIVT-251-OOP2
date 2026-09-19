using NUnit.Framework;
using Starostin.KD_ZIVT_251_OOP2;
using System;
using System.Linq;

namespace ClassRoomApp.Tests
{
    // Unit тесты для Pupil
    [TestFixture]
    public class PupilTests
    {
        // Тест 1: Проверка, что GetCurrentGrade возвращает число в диапазоне 2-5
        [Test]
        public void GetCurrentGrade_MarkBadtoExcelent()
        {
            // Arrange
            var pupil = new Pupil();

            // Act
            int Mark = pupil.GetCurrentGrade;

            // Assert
            Assert.IsTrue(Mark >= 2 && Mark <= 5,
                $"Оценка {Mark} должна быть в диапазоне от 2 до 5");
        }

        // Тест 2: Проверка, что при повторном вызове GetCurrentGrade возвращает одинаковую оценку
        [Test]
        public void GetCurrentGrade_SameMark()
        {
            // Arrange
            var pupil = new Pupil();

            // Act
            int firstCall = pupil.GetCurrentGrade;
            int secondCall = pupil.GetCurrentGrade;
            int thirdCall = pupil.GetCurrentGrade;

            // Assert
            Assert.IsTrue(firstCall == secondCall && secondCall == thirdCall,
                "При повторном вызове оценки должны быть равны");
        }

        // Тест 3: Проверка конструктора с параметрами
        [Test]
        public void Constructor_WithParameters()
        {
            // Arrange
            string expectedSurname = "Ильиных";
            string expectedName = "Евгений";
            Gender expectedGender = Gender.Мужской;

            // Act
            var pupil = new Pupil(expectedSurname, expectedName, expectedGender);

            // Assert
            Assert.IsTrue(pupil.Surname == expectedSurname,
                $"Фамилия должна быть {expectedSurname}, получено {pupil.Surname}");
            Assert.IsTrue(pupil.Name == expectedName,
                $"Имя должно быть {expectedName}, получено {pupil.Name}");
            Assert.IsTrue(pupil.Gender == expectedGender,
                $"Пол должен быть {expectedGender}, получено {pupil.Gender}");
        }

        // Тест 4: Проверка методов Study, Read, Write, Relax
        [Test]
        public void Methods_Pupil()
        {
            // Arrange
            var pupil = new Pupil();

            // Act
            string studyResult = pupil.Study();
            string readResult = pupil.Read();
            string writeResult = pupil.Write();
            string relaxResult = pupil.Relax();

            // Assert
            Assert.IsTrue(studyResult.Contains("учится"),
                $"Метод Study должен содержать 'учится', получено: {studyResult}");
            Assert.IsTrue(readResult.Contains("читает"),
                $"Метод Read должен содержать 'читает', получено: {readResult}");
            Assert.IsTrue(writeResult.Contains("пишет"),
                $"Метод Write должен содержать 'пишет', получено: {writeResult}");
            Assert.IsTrue(relaxResult.Contains("отдыхает"),
                $"Метод Relax должен содержать 'отдыхает', получено: {relaxResult}");
        }

        // Тест 5: Проверка правильности установки свойств через конструктор
        [Test]
        public void Constructor_CorrectParams()
        {
            // Arrange
            string Surname = "Цвых";
            string Name = "Алена";
            Gender gender = Gender.Женский;

            // Act
            var pupil = new Pupil(Surname, Name, gender);

            // Assert
            Assert.IsTrue(pupil.Surname == Surname,
                $"Имя должно быть {Surname}, получено {pupil.Surname}");
            Assert.IsTrue(pupil.Name == Name,
                $"Фамилия должна быть {Name}, получено {pupil.Name}");
            Assert.IsTrue(pupil.Gender == gender,
                $"Пол должен быть {gender}, получено {pupil.Gender}");
        }
    }

    // Класс содержит Unit тесты для разных типов учеников
    [TestFixture]
    public class PupilTypeTests
    {
        // Тест 6: Проверка, что отличник чаще получает 5
        [Test]
        public void GetCurrentGrade_ExcelentPupilFive()
        {
            // Arrange
            var pupil = new ExcelentPupil();
            int fiveCount = 0;
            int totalTests = 100;

            // Act
            for (int i = 0; i < totalTests; i++)
            {
                pupil.ResetMark(); // Сбрасываем для новой генерации
                if (pupil.GetCurrentGrade == 5)
                    fiveCount++;
            }

            // Assert: отличник должен иметь 5 в >= 50% случаев
            double percentage = (double)fiveCount / totalTests * 100;
            Assert.IsTrue(fiveCount >= totalTests * 0.5,
                $"Отличник получил 5 в {percentage}% случаев, ожидалось больше 50%");
        }

        // Тест 7: Проверка, что двоечник редко получает 5
        [Test]
        public void GetCurrentGrade_BadPupilMarkFive()
        {
            // Arrange
            var pupil = new BadPupil();
            int fiveCount = 0;
            int totalTests = 100;

            // Act
            for (int i = 0; i < totalTests; i++)
            {
                pupil.ResetMark();
                if (pupil.GetCurrentGrade == 5)
                    fiveCount++;
            }

            // Assert: двоечник должен иметь 5 в <= 15% случаев
            double percentage = (double)fiveCount / totalTests * 100;
            Assert.IsTrue(fiveCount <= totalTests * 0.15,
                $"Двоечник получил 5 в {percentage}% случаев, ожидалось менее 15%");
        }

        // Тест 8: Проверка, что хорошист часто получает 4 или 5
        [Test]
        public void GetCurrentGrade_GoodPupilFourOrFive()
        {
            // Arrange
            var pupil = new GoodPupil();
            int Mark45 = 0;
            int totalTests = 100;

            // Act
            for (int i = 0; i < totalTests; i++)
            {
                var tempPupil = new GoodPupil();
                int grade = tempPupil.GetCurrentGrade;
                if (grade == 4 || grade == 5)
                    Mark45++;
            }

            // Assert: хорошист должен иметь 4 или 5 в >= 80% случаев
            double percentage = (double)Mark45 / totalTests * 100;
            Assert.IsTrue(Mark45 >= totalTests * 0.8,
                $"Хорошист получил 4 или 5 в {percentage}% случаев, ожидалось >= 80%");
        }
    }

    // Класс содержит Unit тесты для ClassRoom
    [TestFixture]
    public class ClassRoomTests
    {
        // Тест 9: Проверка конструктора с разным количеством учеников
        [Test]
        public void Constructor_DifferentCountPupils()
        {
            // Arrange & Act
            var pupil1 = new Pupil();
            var pupil2 = new Pupil();
            var pupil3 = new Pupil();
            var pupil4 = new Pupil();

            var classRoom2 = new ClassRoom("10А", pupil1, pupil2);
            var classRoom3 = new ClassRoom("10Б", pupil1, pupil2, pupil3);
            var classRoom4 = new ClassRoom("10В", pupil1, pupil2, pupil3, pupil4);

            // Assert
            Assert.IsNotNull(classRoom2, "Класс с 2 учениками должен быть создан");
            Assert.IsNotNull(classRoom3, "Класс с 3 учениками должен быть создан");
            Assert.IsNotNull(classRoom4, "Класс с 4 учениками должен быть создан");
        }

        // Тест 10: Проверка метода GetMarks
        [Test]
        public void GetMarks_NoException()
        {
            // Arrange
            var pupil1 = new Pupil();
            var pupil2 = new Pupil();
            var classRoom = new ClassRoom("11А", pupil1, pupil2);

            // Act & Assert
            Assert.DoesNotThrow(() => classRoom.GetMarks(),
                "Метод GetMarks не должен выбрасывать исключения");
        }
    }
}

