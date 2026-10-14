public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate() => _date;
    public int GetMinutes() => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{GetDate()} {GetType().Name} ({GetMinutes()} min): " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.1} mph, " +
               $"Pace: {GetPace():0.1} min per mile";
    }
}