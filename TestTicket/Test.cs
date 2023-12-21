using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryForClasses;

namespace TestTicket
{
    /// <summary>
    /// Класс для тестирования программы.
    /// </summary>
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Метод сравнения массивов.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CompareArray(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Тест при одном маршруте и свободном автобусе.
        /// </summary>
        [TestMethod]
        public void OneRouteAndFullSeats()
        {
            Man bus = new Man();
            int begin = 1, end = 2;

            int[] result = bus.FreeSeats(begin, end);

            int[] array = new int[] { 12, 13, 13, 13, 13 };

            Assert.IsTrue(CompareArray(result, array));
        }

        /// <summary>
        /// Тест для одного маршрута и автобуса с несколькими занятами местами.
        /// </summary>
        [TestMethod]
        public void OneRouteAndSomeSeats()
        {
            Man bus = new Man();
            for (int i = 0; i < 5; i++)
            {
                bus.freeSeats[i] = 1;
            }
            int begin = 1, end = 4;

            int[] result = bus.FreeSeats(begin, end);

            int[] array = new int[] { 0, 0, 0, 1, 1 };

            Assert.IsTrue(CompareArray(result, array));
        }

        /// <summary>
        /// Тест для одного маршрута и заполненного автобуса.
        /// </summary>
        [TestMethod]
        public void OneRouteNoSeats()
        {
            Man bus = new Man();
            for (int i = 0; i < 5; i++)
            {
                bus.freeSeats[i] = 0;
            }
            int begin = 1, end = 5;

            int[] result = bus.FreeSeats(begin, end);

            int[] array = new int[] { -1, -1, -1, -1, 0 };

            Assert.IsFalse(CompareArray(result, array));
        }

        /// <summary>
        /// Тест для нескольких маршрутов и автобуса с несколькими свободными местами.
        /// </summary>
        [TestMethod]
        public void SomeRouteAndSomeSeats()
        {
            Man bus = new Man();
            for (int i = 0; i < 5; i++)
            {
                bus.freeSeats[i] = 3;
            }
            int begin1 = 1, end1 = 4, begin2 = 3, end2 = 5;

            bus.FreeSeats(begin1, end1);
            int[] result = bus.FreeSeats(begin2, end2);

            int[] array = new int[] { 2, 2, 1, 2, 3 };

            Assert.IsTrue(CompareArray(result, array));
        }

        /// <summary>
        /// Тест для нескольких маршрутов, но в автобусе другого типа.
        /// </summary>
        [TestMethod]
        public void SomeRouteAndNewCar()
        {
            MAZ bus = new MAZ();

            int begin1 = 1, end1 = 3, begin2 = 1, end2 = 5;

            bus.FreeSeats(begin1, end1);
            int[] result = bus.FreeSeats(begin2, end2);

            int[] array = new int[] { 18, 18, 19, 19, 20 };

            Assert.IsTrue(CompareArray(result, array));
        }

        /// <summary>
        /// Тест при нескольких маршрутов и заполненном автобусе.
        /// </summary>
        [TestMethod]
        public void SomeRouteAndNoSeats()
        {
            Man bus = new Man();
            for (int i = 0; i < 5; i++)
            {
                bus.freeSeats[i] = 0;
            }
            int begin1 = 1, end1 = 4, begin2 = 3, end2 = 5, begin3 = 2, end3 = 4;

            bus.FreeSeats(begin1, end1);
            bus.FreeSeats(begin2, end2);
            int[] result = bus.FreeSeats(begin3, end3);

            int[] array = new int[] { 0, 0, 0, 0, 0 };

            Assert.IsTrue(CompareArray(result, array));
        }

        /// <summary>
        /// Тест без маршрутов.
        /// </summary>
        [TestMethod]
        public void NoRoute()
        {
            Man bus = new Man();
            int begin = 1, end = 1;

            int[] result = bus.FreeSeats(begin, end);

            int[] array = new int[] {13, 13, 13, 13, 13 };

            Assert.IsTrue(CompareArray(result, array));
        }

        /// <summary>
        /// Тест, когда сидения заканчиваются не сразу.
        /// </summary>
        [TestMethod]
        public void WhenSeatsAreEnded()
        {
            Man bus = new Man();
            for (int i = 0; i < 5; i++)
            {
                bus.freeSeats[i] = 2;
            }
            int begin1 = 1, end1 = 4, begin2 = 3, end2 = 5, begin3 = 1, end3 = 5;

            bus.FreeSeats(begin1, end1);
            bus.FreeSeats(begin2, end2);
            int[] result = bus.FreeSeats(begin3, end3);

            int[] array = new int[] { 0, 0, -1, 0, 2 };

            Assert.IsFalse(CompareArray(result, array));
        }
    }
}
