public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Abstract method: Every derived class MUST implement its own version of RecordEvent
    public abstract void RecordEvent();

    // Abstract method: Every derived class MUST define how to check if it's finished
    public abstract bool IsComplete();

    // Virtual method: Provides a default string representation, but can be overridden
    public virtual string GetDetailsString()
    {
        string statusSymbol = IsComplete() ? "[X]" : "[ ]";
        return $"{statusSymbol} {_shortName} ({_description})";
    }

    // Abstract method: Forces each child class to specify how it should be saved to a file
    public abstract string GetStringRepresentation();
}