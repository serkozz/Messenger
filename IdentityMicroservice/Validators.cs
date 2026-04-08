using System.Text.RegularExpressions;

namespace IdentityMicroservice;

public static partial class Validators
{
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$", RegexOptions.IgnoreCase)]
    private static partial Regex EmailRegex();

    public static bool ValidateEmail(string email) => EmailRegex().IsMatch(email);
}