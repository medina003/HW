SystemProxy SystemProxy = new(new RealSystem());
SystemProxy.LogIn("Somebody");
SystemProxy.LogIn("Admin1");
public interface ISystem
{
    void LogIn(string? user);
}
public class RealSystem : ISystem
{
    public void LogIn(string? user)
    {
        Console.WriteLine($"{user} logged in");
    }
}
public class SystemProxy : ISystem
{
    readonly RealSystem realSystem;
    public SystemProxy(RealSystem realSystem)
    {
        this.realSystem = realSystem;
    }
    public void LogIn(string? user)
    {
        if (!String.IsNullOrEmpty(user))
        {
            if (user == "Admin1" || user == "Admin2")
            {
                realSystem.LogIn(user);
            }
            else Console.WriteLine("This user doesn't have access to the system");
        }
    }
}