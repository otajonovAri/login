public class Program
{
  public static void Main(string[] args)
  {
    User user = new User();

    bool loginInputTrue = false;
    bool passwordInputTrue = false;

    string loginInput = "";
    string passwordInput = "";

    while(!loginInputTrue)
    {
      Console.Write("Enter Login: ");
      loginInput = Console.ReadLine();

      if(user.ValidateNickName(loginInput))
      {
        loginInputTrue = true;
      }
    }

    while(!passwordInputTrue)
    {
      Console.Write("Enter password: ");
      passwordInput = Console.ReadLine();

      if(user.ValidatePassword(passwordInput))
      {
        passwordInputTrue = true;
      }
    }

    if(passwordInputTrue && loginInputTrue)
    {
      Console.WriteLine(user.EnterEmail(loginInput , passwordInput));
    }

  }
}

public class NickNameMessage
{
  public void NumberMessage() =>
    Console.WriteLine("Cannot attach with number");

  public void CountMessage() =>
    Console.WriteLine("It is also not possible to attach with special characters");

  public void LengthMessage() =>
    Console.WriteLine("Login length must start with at least 3 characters");

  public void PassLength() =>
    Console.WriteLine("Password must be longer than 8");

  public void PassUppercase() =>
    Console.WriteLine("At least one uppercase letter is required");

  public void PassNumber() =>
    Console.WriteLine("Be a single number");

  public void PassSymbol() =>
    Console.WriteLine("There is no sign");

  public void enterEmailTrue()
  =>
  Console.WriteLine("Log in done");
}

public class User : NickNameMessage
{
  private string UserLogin = "User";
  private string UserPassword = "User123!";

  public bool ValidateNickName(string login)
  {
    if (login.Length < 3)
    {
      LengthMessage();
      return false;
    }

    foreach (char c in login)
    {
      if (char.IsDigit(c))
      {
        NumberMessage();
        return false; 
      }

      if (!char.IsLetter(c)) 
      {
        CountMessage();
        return false; 
      }
    }

    return true;
  }

  public bool ValidatePassword(string password)
  {
    if (password.Length < 8)
    {
      PassLength();
      return false; 
    }

    bool hasUpper = false;
    bool hasDigit = false;
    bool hasSymbol = false;

    foreach (char c in password)
    {
      if (char.IsUpper(c))
        hasUpper = true;
      if (char.IsDigit(c))
        hasDigit = true;
      if (!char.IsLetterOrDigit(c)) 
        hasSymbol = true;
    }

    if (!hasUpper)
    {
      PassUppercase();
      return false;
    }

    if (!hasDigit)
    {
      PassNumber();
      return false; 
    }

    if (!hasSymbol)
    {
      PassSymbol();
      return false; 
    }

    return true;
  }

  public bool EnterEmail(string Login , string Password)
  {
    const int maxAttemps = 3;
    int attemps = 0;

    while(attemps < maxAttemps)
    {
      if(Login.Equals(UserLogin) && Password.Equals(UserPassword))
      {
        enterEmailTrue();
        return true;
      }
      else
      {
        attemps++;
        Console.WriteLine($"Kirish uchun {attemps} - time error");

        if(attemps >= maxAttemps)
        {
          Console.WriteLine($"{maxAttemps} - Number of possibilities");
          return false;
        }

        Console.Write("Try enter login: ");
        Login = Console.ReadLine();
        Console.Write("Try enter Password: ");
        Password = Console.ReadLine();
      }
    }
    return false;
  }
}


