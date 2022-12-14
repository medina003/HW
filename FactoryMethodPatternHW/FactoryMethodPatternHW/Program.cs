LogInService logInService = new UseFacebookAccService();
AccountData accountData1 = logInService.LogIn("username1", "password1");
logInService = new UseGoogleAccService();
AccountData accountData2 = logInService.LogIn("username2", "password2");

abstract class AccountData
{
    string? Username { get; set; }
    string? Password { get; set; }
    public AccountData(string? username, string? password)
    {
        Username = username;
        Password = password;
    }
}
class CurrentProgramAccountData : AccountData
{
    public CurrentProgramAccountData(string? username, string? password) : base(username, password)
    {
    }
}
class FacebookAccountData : AccountData
{
    public FacebookAccountData(string? username, string? password) : base(username, password)
    {
    }
}
class GoogleAccountData : AccountData
{
    public GoogleAccountData(string? username, string? password) : base(username, password)
    {
    }
}
abstract class LogInService
{


    public abstract AccountData LogIn(string username, string password);
}

class UseCurrentAccService : LogInService
{


    public override AccountData LogIn(string username, string password)
    {
        return new CurrentProgramAccountData(username, password);
    }
}
class UseFacebookAccService : LogInService
{

    public override AccountData LogIn(string username, string password)
    {
        return new FacebookAccountData(username, password);
    }
}
class UseGoogleAccService : LogInService
{


    public override AccountData LogIn(string username, string password)
    {
        return new GoogleAccountData(username, password);
    }
}