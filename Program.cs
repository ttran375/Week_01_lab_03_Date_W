namespace Week_01_lab_02_Cars_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Date date = new(1, 1, 2024);
            Console.WriteLine(date.ToString());

            date.Add(31);
            Console.WriteLine(date.ToString());

            date.Add(5, 29);
            Console.WriteLine(date.ToString());

            Date otherDate = new(1, 1, 1);
            date.Add(otherDate);
            Console.WriteLine(date.ToString());
        }
    }


    public class Date
    {
        private int _day;
        private int _month;
        private int _year;

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

        public void Add(int months, int days)
        {
            _month += months;
            _day += days;
            Normalize();
        }

        public void Add(Date other)
        {
            _year += other._year;
            _month += other._month;
            _day += other._day;
            Normalize();
        }

        private void Normalize()
        {
            int daysInMonth = GetDaysInMonth(_year, _month);
            while (_day > daysInMonth)
            {
                _day -= daysInMonth;
                _month++;
            }

            while (_month > 12)
            {
                _month -= 12;
                _year++;
            }
        }

        public override string ToString()
        {
            string monthText = GetMonthText(_month);
            return $"{_year}-{monthText}-{_day}";
        }

        public static string GetMonthText(int month)
        {
            switch (month)
            {

                case 1: return "Jan";
                case 2: return "Feb";
                case 3: return "Mar";
                case 4: return "Apr";
                case 5: return "May";
                case 6: return "Jun";
                case 7: return "Jul";
                case 8: return "Aug";
                case 9: return "Sep";
                case 10: return "Oct";
                case 11: return "Nov";
                case 12: return "Dec";
                default: return "Unknown";
            }
        }
        private static int GetDaysInMonth(int year, int month)
        {
            return month switch
            {
                2 => IsLeapYear(year) ? 29 : 28,
                4 or 6 or 9 or 11 => 30,
                _ => 31,
            };
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
    }
}
