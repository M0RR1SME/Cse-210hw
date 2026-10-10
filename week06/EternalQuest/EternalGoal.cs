public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are never complete, so recording an event doesn't change any state.
        // Points are handled by the manager class using GetPoints().
    }

    public override bool IsComplete()
    {
        // Eternal goals can never be marked as finished
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}";
    }
}