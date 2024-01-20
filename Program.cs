using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Week_01_lab_02_Cars_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date(1, 1, 2024);
            Console.WriteLine(date.ToString());

            date.Add(31);
            Console.WriteLine(date.ToString());

            date.Add(0, 29);
            Console.WriteLine(date.ToString());

            Date otherDate = new Date(1, 1, 1);
            date.Add(otherDate);
            Console.WriteLine(date.ToString());
        }
    }



}





public class Date
{
    private int day;
    private int month;
    private int year;

    public Date(int day = 1, int month = 1, int year = 2022)
    {
        this.day = day;
        this.month = month;
        this.year = year;
        Normalize();
    }

    public void Add(int days)
    {
        day += days;
        Normalize();
    }

    public void Add(int months, int days)
    {
        months += months;
        day += days;
        Normalize();
    }

    public void Add(Date other)
    {
        year += other.year;
        month += other.month;
        day += other.day;
        Normalize();
    }

    private void Normalize()
    {
        int daysInMonth = GetDaysInMonth(year, month);
        while (day > daysInMonth)
        {
            day -= daysInMonth;
            month++;
        }

        while (month > 12)
        {
            month -= 12;
            year++;
        }
    }

    public override string ToString()
    {
        string monthText = GetMonthText(month);
        return $"{year}-{monthText}-{day}";
    }

    public string GetMonthText(int month)
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
    private int GetDaysInMonth(int year, int month)
    {
        switch (month)
        {
            case 2:
                return IsLeapYear(year) ? 29 : 28;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            default:
                return 31;
        }
    }

    private bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}
