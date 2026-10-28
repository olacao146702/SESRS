using SESRS.Models;

namespace SESRS.Helpers;

/// <summary>
/// Holds the signed-in user and enforces role checks. Services call these
/// guards so authorization does not depend on which screen is open.
/// </summary>
public static class Session
{
    public static User? CurrentUser { get; private set; }

    public static bool IsAdmin => CurrentUser?.Role == "Admin";

    public static void Start(User user)
    {
        CurrentUser = user;
    }

    public static void End()
    {
        CurrentUser = null;
    }

    public static User RequireLogin()
    {
        return CurrentUser
            ?? throw new UnauthorizedAccessException("You must be signed in to do this.");
    }

    public static User RequireAdmin()
    {
        User user = RequireLogin();

        if (user.Role != "Admin")
        {
            throw new UnauthorizedAccessException(
                "This action is restricted to administrators.");
        }

        return user;
    }

    /// <summary>Admins may access any student; a student only their own record.</summary>
    public static User RequireStudentSelfOrAdmin(int studentId)
    {
        User user = RequireLogin();

        if (user.Role == "Admin")
        {
            return user;
        }

        if (user.Role == "Student" && user.StudentId == studentId)
        {
            return user;
        }

        throw new UnauthorizedAccessException(
            "You can only access your own records.");
    }
}
