using GJ4.Interfaces;
using System;

namespace GJ4.Battle
{
    public abstract class BattleGoal : IBattleGoal
    {
        public event Action Achieved;

        public bool IsAchieved { get; private set; }

        protected void MarkAchieved() 
        {
            IsAchieved = true;

            Achieved?.Invoke();
        }
    }
}
