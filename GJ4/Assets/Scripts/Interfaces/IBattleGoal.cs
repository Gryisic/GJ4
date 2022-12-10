using System;

namespace GJ4.Interfaces
{
    public interface IBattleGoal 
    {
        event Action Achieved;

        bool IsAchieved { get; }
    }
}
