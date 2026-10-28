using System.Data;

namespace SESRS.Models;

public sealed record StudentProfile(
    int StudentId,
    string StudentNumber,
    string FullName,
    string Gender,
    DateTime? BirthDate,
    string Email,
    string Phone,
    string Address,
    string ProgramCode,
    string ProgramName,
    int YearLevel,
    string Status);

public sealed record TimetableEntry(
    string SubjectCode,
    string SubjectName,
    string SectionCode,
    string Day,
    TimeSpan Start,
    TimeSpan End,
    string Room,
    string Instructor,
    string EnrollmentStatus);

public sealed record CurriculumProgress(
    DataTable Subjects,
    int CompletedUnits,
    int TotalUnits,
    int RemainingSubjects,
    int Deficiencies);

public sealed record HomeSummary(
    StudentProfile Profile,
    AcademicPeriod? Period,
    string EnrollmentStatus,
    int EnrolledUnits,
    int UnreadNotifications,
    int CompletedUnits,
    int TotalUnits,
    List<string> Alerts,
    DataTable Announcements,
    DataTable RecentNotifications);
