using System.Text.RegularExpressions;
using SESRS.Models;

namespace SESRS.Helpers;

/// <summary>Server-side input rules shared by services (the screens check the same things for fast feedback).</summary>
public static class Validate
{
    private static readonly Regex Code = new(@"^[A-Za-z0-9][A-Za-z0-9 \-_./]*$");
    private static readonly Regex SchoolYearPattern = new(@"^(\d{4})-(\d{4})$");
    private static readonly Regex EmailPattern = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    private static readonly Regex PhonePattern = new(@"^[0-9+\-\s()]{7,20}$");

    public static void Program(string code, string name, int durationYears)
    {
        RequireCode(code, "Program code", 2, 20);
        RequireText(name, "Program name", 3, 150);
        RequireRange(durationYears, "Duration", 1, 8);
    }

    public static void Subject(string code, string name, string? description, int units)
    {
        RequireCode(code, "Subject code", 2, 30);
        RequireText(name, "Subject name", 3, 150);

        if ((description ?? "").Length > 255)
        {
            throw new BusinessRuleException("The description must be 255 characters or fewer.");
        }

        RequireRange(units, "Units", 1, 12);
    }

    public static void Section(string code, string name, int programId, int yearLevel,
        string semester, string schoolYear, int capacity)
    {
        RequireCode(code, "Section code", 2, 30);
        RequireText(name, "Section name", 2, 100);

        if (programId <= 0)
        {
            throw new BusinessRuleException("Please select a program.");
        }

        RequireRange(yearLevel, "Year level", 1, 6);

        if (!Academic.Semesters.Contains(semester))
        {
            throw new BusinessRuleException("Please choose a valid semester.");
        }

        SchoolYear(schoolYear);
        RequireRange(capacity, "Capacity", 1, 200);
    }

    public static void SchoolYear(string schoolYear)
    {
        Match m = SchoolYearPattern.Match(schoolYear ?? "");

        if (!m.Success || int.Parse(m.Groups[2].Value) != int.Parse(m.Groups[1].Value) + 1)
        {
            throw new BusinessRuleException("School year must look like 2026-2027 (two consecutive years).");
        }
    }

    public static void StudentProfile(string firstName, string? middleName, string lastName, string gender,
        DateTime birthDate, string? email, string? phone, string? address, int programId, int yearLevel)
    {
        RequireText(firstName, "First name", 1, 50);
        RequireText(lastName, "Last name", 1, 50);

        if ((middleName ?? "").Length > 50)
        {
            throw new BusinessRuleException("Middle name must be 50 characters or fewer.");
        }

        if (string.IsNullOrWhiteSpace(gender))
        {
            throw new BusinessRuleException("Please select a gender.");
        }

        if (birthDate.Date >= DateTime.Today || birthDate.Year < 1900)
        {
            throw new BusinessRuleException("Please enter a valid birth date.");
        }

        if (!string.IsNullOrWhiteSpace(email) && (email.Length > 100 || !EmailPattern.IsMatch(email)))
        {
            throw new BusinessRuleException("Please enter a valid email address.");
        }

        if (!string.IsNullOrWhiteSpace(phone) && !PhonePattern.IsMatch(phone))
        {
            throw new BusinessRuleException("Please enter a valid phone number.");
        }

        if ((address ?? "").Length > 255)
        {
            throw new BusinessRuleException("Address must be 255 characters or fewer.");
        }

        if (programId <= 0)
        {
            throw new BusinessRuleException("Please select a program.");
        }

        RequireRange(yearLevel, "Year level", 1, 6);
    }

    public static void RequireText(string? value, string field, int min, int max)
    {
        int length = (value ?? "").Trim().Length;

        if (length < min)
        {
            throw new BusinessRuleException(min == 1
                ? $"{field} is required."
                : $"{field} must be at least {min} characters.");
        }

        if (length > max)
        {
            throw new BusinessRuleException($"{field} must be {max} characters or fewer.");
        }
    }

    public static void RequireCode(string? value, string field, int min, int max)
    {
        RequireText(value, field, min, max);

        if (!Code.IsMatch(value!.Trim()))
        {
            throw new BusinessRuleException(
                $"{field} may contain only letters, numbers, spaces and - _ . /");
        }
    }

    public static void RequireRange(int value, string field, int min, int max)
    {
        if (value < min || value > max)
        {
            throw new BusinessRuleException($"{field} must be between {min} and {max}.");
        }
    }
}
