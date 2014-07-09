using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Задание_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите день");
            var day = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите месяц");
            var month = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите год");
            var year = int.Parse(Console.ReadLine());

            var dateIsValid = Date.IsValidDate(day, month, year);
            Console.WriteLine(dateIsValid ? "Корректная дата" : "Некорректная дата");
            if (dateIsValid)
            {
                Console.WriteLine("Номер дня в году: {0}", Date.DayNumber(day, month, year));
                Console.WriteLine("Дней до конца года: {0}", Date.DaysLeftInTheYear(day, month, year));
            }
            Console.ReadLine();
        }
        public static class Date
        {
            private static readonly int[] DaysToMonth365 =
		{
			0,
			31,
			59,
			90,
			120,
			151,
			181,
			212,
			243,
			273,
			304,
			334,
			365
		};
            private static readonly int[] DaysToMonth366 =
		{
			0,
			31,
			60,
			91,
			121,
			152,
			182,
			213,
			244,
			274,
			305,
			335,
			366
		};
            public static bool IsValidDate(int day, int month, int year)
            {
                if (year >= 1 && year <= 9999 && (month >= 1 && month <= 12))
                {
                    var numArray = IsLeapYear(year) ? DaysToMonth366 : DaysToMonth365;
                    if (day >= 1 && day <= numArray[month] - numArray[month - 1])
                    {
                        return true;
                    }
                }
                return false;
            }

            public static int DayNumber(int day, int month, int year)
            {
                if (!IsValidDate(day, month, year))
                    throw new Exception("Wrong Date");

                var numArray = IsLeapYear(year) ? DaysToMonth366 : DaysToMonth365;
                return numArray[month - 1] + day;
            }

            public static int DaysLeftInTheYear(int day, int month, int year)
            {
                if (!IsValidDate(day, month, year))
                    throw new Exception("Wrong Date");

                var numArray = IsLeapYear(year) ? DaysToMonth366 : DaysToMonth365;
                return numArray[12] - DayNumber(day, month, year);
            }

            private static bool IsLeapYear(int year)
            {
                if (year < 1 || year > 9999)
                    throw new Exception("Wrong year");
                if (year % 4 != 0)
                    return false;
                if (year % 100 == 0)
                    return year % 400 == 0;
                return true;
            }
        }
    }
}
    



