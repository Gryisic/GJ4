using System;
using UnityEngine;

namespace GJ4.Battle
{
    public class UnitCreationArgs : EventArgs
    {
        public readonly Unit Unit;
        public readonly Vector2 Position;

        public UnitCreationArgs(Unit unit, Vector2 position)
        {
            Unit = unit;
            Position = position;
        }
    }
}