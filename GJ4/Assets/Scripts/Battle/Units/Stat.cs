using UnityEngine;
using static GJ4.Utils.Enums;

namespace GJ4.Battle
{
    [System.Serializable]
    public struct Stat 
    {
        [SerializeField] private StatType _type;
        [SerializeField] private int _value;

        public StatType Type => _type;
        public int Value => _value;

        public Stat(StatType type, int value) 
        {
            _type = type;
            _value = value;
        }
    }
}
