using System;

class Program
{
    // Exceeding Requirements Comment:
    // To exceed requirements, this program includes a gamification level system where players earn 
    // level titles (e.g., Novice, Adventurer, Master) based on accumulated point milestones, 
    // along with detailed progress formatting and robust error handling during file parsing.

    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}