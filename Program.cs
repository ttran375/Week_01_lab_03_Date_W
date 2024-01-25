using System;

public class Date
{
    // Fields
    private int year;
    private int month;
    private int day;

    // Property for Julian day
    public int JulianDay
    {
        get { return CalculateJulianDay(); }
        private set { SetDateFromJulianDay(value); }
    }

    // Constructor
    public Date(int day = 1, int month = 1, int year = 2022)
    {
        this.day = day;
        this.month = month;
        this.year = year;
        Normalize();
    }

    // Methods
    public override string ToString()
    {
        string monthName = GetMonthName(month);
        return $"{day} {monthName} {year}";
    }

    public void Add(int days)
    {
        JulianDay += days;
        Normalize();
    }

    public void Add(int months, int days)
    {
        // Adjust Julian day directly
        JulianDay += days + CalculateDaysInMonths(months);
        Normalize();
    }

    public void Add(Date other)
    {
        // Add Julian days directly
        JulianDay += other.JulianDay;
        Normalize();
    }

    // Private method to normalize the date
    private void Normalize()
    {
        // Extract year, month, and day from Julian day
        int totalDays = JulianDay;
        year = 2022;

        while (totalDays > 365 + (IsLeapYear(year) ? 1 : 0))
        {
            totalDays -= 365 + (IsLeapYear(year) ? 1 : 0);
            year++;
        }

        month = 1;
        while (totalDays > GetMonthLength(month, year))
        {
            totalDays -= GetMonthLength(month, year);
            month++;
        }

        day = totalDays;
    }

    // Private method to calculate Julian day
    private int CalculateJulianDay()
    {
        int totalDays = day;

        for (int i = 1; i < month; i++)
        {
            totalDays += GetMonthLength(i, year);
        }

        for (int i = 2022; i < year; i++)
        {
            totalDays += 365 + (IsLeapYear(i) ? 1 : 0);
        }

        return totalDays;
    }

    // Private method to set date from Julian day
    private void SetDateFromJulianDay(int julianDay)
    {
        int totalDays = julianDay;
        year = 2022;

        while (totalDays > 365 + (IsLeapYear(year) ? 1 : 0))
        {
            totalDays -= 365 + (IsLeapYear(year) ? 1 : 0);
            year++;
        }

        month = 1;
        while (totalDays > GetMonthLength(month, year))
        {
            totalDays -= GetMonthLength(month, year);
            month++;
        }

        day = totalDays;
    }

    // Private method to calculate days in months
    private int CalculateDaysInMonths(int months)
    {
        int totalDays = 0;
        int currentMonth = month;
        int currentYear = year;

        for (int i = 0; i < months; i++)
        {
            totalDays += GetMonthLength(currentMonth, currentYear);
            currentMonth++;

            if (currentMonth > 12)
            {
                currentMonth = 1;
                currentYear++;
            }
        }

        return totalDays;
    }

    // Private method to get the month name
    private string GetMonthName(int month)
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
            default: return "Invalid Month";
        }
    }

    // Private method to get the length of a month
    private int GetMonthLength(int month, int year)
    {
        if (month == 2)
        {
            // Check for leap year
            return IsLeapYear(year) ? 29 : 28;
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            return 30;
        }
        else
        {
            return 31;
        }
    }

    // Private method to check for leap year
    private bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}

class Program
{
    static void Main()
    {
        // Example usage
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
