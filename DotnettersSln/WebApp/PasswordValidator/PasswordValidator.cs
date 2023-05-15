namespace WebApp.PasswordValidator;

public class PasswordValidator
{
    public string Validate(string? password)
    {
        if (password is null)
            return "Password can not be null";

        if (password.Trim().Length == 0)
            return "Password can not be empty";

        if (password.Trim().Length < 8)
            return "Password length can not be less than 8";

        return string.Empty;
    }
}
