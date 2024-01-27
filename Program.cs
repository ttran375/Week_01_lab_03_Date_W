namespace Week_01_lab_03_Date_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Date date = new(1, 1, 2024);
            Console.WriteLine(date.ToString());

            date.Add(10);
            Console.WriteLine(date.ToString());

            date.Add(100);
            Console.WriteLine(date.ToString());

            date.Add(1000);
            Console.WriteLine(date.ToString());
        }
    }


    public class Date
    {
        private int _year;
        private int _month;
        private int _day;

        public Date(int day = 1, int month = 1, int year = 2022)
        {
            _day = day;
            _month = month;
            _year = year;
            Normalize();
        }

        public void Add(int days)
        {
            _day += days;
            Normalize();
        }

        private void Normalize()
        {
            int daysInMonth = GetDaysInMonth(_year, _month);
            while (_day > daysInMonth)
            {
                _day -= daysInMonth;
                _month++;

                if (_month > 12)
                {
                    _month -= 12;
                    _year++;
                }

                daysInMonth = GetDaysInMonth(_year, _month);
            }
        }


        public override string ToString()
        {
            string monthText = GetMonthText(_month);
            return $"{_year}-{monthText}-{_day}";
        }

        public static string GetMonthText(int month)
        {
            return month switch
            {
                1 => "Jan",
                2 => "Feb",
                3 => "Mar",
                4 => "Apr",
                5 => "May",
                6 => "Jun",
                7 => "Jul",
                8 => "Aug",
                9 => "Sep",
                10 => "Oct",
                11 => "Nov",
                12 => "Dec",
                _ => "Unknown",
            };
        }
        private static int GetDaysInMonth(int year, int month)
        {
            return month switch
            {
                2 => IsLeapYear(year) ? 29 : 28,
                4 or 6 or 9 or 11 => 30,
                1 or 3 or 5 or 7 or 8 or 10 or 12 => 31,
                _ => throw new NotImplementedException(),
            };
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
    }

}
