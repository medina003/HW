Teacher MathTeacher = new MathTeacher(new Algebra());
MathTeacher.Teaches();
MathTeacher.subject = new Geometry();
MathTeacher.Teaches();
public interface ISubject
{
    public void Description();
}
public class Algebra : ISubject
{
   public void Description()
    {
        Console.WriteLine("Learning algebra helps to develop your critical thinking skills.");
    }
}
public class Geometry : ISubject
{
    public void Description()
    {
        Console.WriteLine("Geometry skills include visual skill, descriptive skill, drawing skill, logical skill, applied skill.");
    }
}
public abstract class Teacher
{
    public ISubject subject;
    public ISubject Subject
    {
        set { subject = value; }
    }
    public Teacher(ISubject sub)
    {
        subject = sub;
    }
    public virtual void Teaches()
    {
        subject.Description();
    }
    public abstract void EarnsMoney();
}
public class MathTeacher : Teacher
{
    public MathTeacher(ISubject sub) : base(sub)
    {
    }

    public override void EarnsMoney()
    {
        Console.Write("Have 15 working hours a week and earns 700azn");
    }
}