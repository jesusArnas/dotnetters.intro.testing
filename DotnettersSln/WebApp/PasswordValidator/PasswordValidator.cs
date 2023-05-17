using WebApp.Models;

namespace WebApp.PasswordValidator;

public class PasswordValidatorImpl
{
    public string Validate(User user)
    {
        if (user.Password is null)
            return "Password can not be null";

        if (user.Password.Trim().Length == 0)
            return "Password can not be empty";

        if (user.Password.Trim().Length < 8)
            return "Password length can not be less than 8";

        if (user.Password.Trim().Equals(user.Name.Trim()))
            return "Password can not be equal to user name";

        return string.Empty;
    }
}
