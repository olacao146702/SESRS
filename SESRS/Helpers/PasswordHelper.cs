using System.Security.Cryptography;

namespace SESRS.Helpers;

public static class PasswordHelper
{
    // Ambiguous characters (0/O, 1/l/I) are left out so passwords can be read aloud or copied by hand.
    private const string Upper = "ABCDEFGHJKLMNPQRSTUVWXYZ";
    private const string Lower = "abcdefghijkmnopqrstuvwxyz";
    private const string Digits = "23456789";

    public static string GenerateTemporaryPassword(int length = 10)
    {
        string all = Upper + Lower + Digits;

        var chars = new List<char>
        {
            Pick(Upper),
            Pick(Lower),
            Pick(Digits)
        };

        while (chars.Count < length)
        {
            chars.Add(Pick(all));
        }

        for (int i = chars.Count - 1; i > 0; i--)
        {
            int j = RandomNumberGenerator.GetInt32(i + 1);
            (chars[i], chars[j]) = (chars[j], chars[i]);
        }

        return new string(chars.ToArray());
    }

    /// <summary>Returns an error message, or null when the password is acceptable.</summary>
    public static string? Validate(string password, string username)
    {
        if (password.Length < 8)
        {
            return "The new password must be at least 8 characters long.";
        }

        if (password.Length > 72)
        {
            return "The new password must be 72 characters or fewer.";
        }

        if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
        {
            return "The new password must contain at least one letter and one number.";
        }

        if (password.Equals(username, StringComparison.OrdinalIgnoreCase))
        {
            return "The new password must not be the same as your username.";
        }

        return null;
    }

    private static char Pick(string source)
    {
        return source[RandomNumberGenerator.GetInt32(source.Length)];
    }
}
