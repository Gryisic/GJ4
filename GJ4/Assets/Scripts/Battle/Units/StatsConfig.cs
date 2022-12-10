using System.Collections.Generic;
using UnityEngine;

namespace GJ4.Battle
{
    [CreateAssetMenu(menuName = "Configs / Battle / Units / StatsTemplate", fileName = "UnitName")]
    public class StatsConfig : ScriptableObject
    {
        [SerializeField] private List<Stat> _stats;

        public IReadOnlyList<Stat> Stats => _stats;
    }
}