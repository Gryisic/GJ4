using GJ4.Utils;
using System.Collections.Generic;
using UnityEngine;
using static GJ4.Utils.Enums;

namespace GJ4.Battle
{
    public class AlliesFactory 
    {
        private Dictionary<int, Ally> _allies = new Dictionary<int, Ally>();

        public void Load(List<AllyType> allies)
        {
            foreach (var ally in allies)
            {
                _allies.Add((int)ally, Resources.Load<Ally>($"{Constants.ALLY_PREFABS}/{ally}"));

                if (_allies[(int)ally] == null)
                    throw new System.NullReferenceException($"{ally} is not assigned or not found in 'Resources'");
            }
        }

        public Ally Create(AllyType type, Vector2 at)
        {
            var ally = GameObject.Instantiate(_allies[(int)type], at, Quaternion.identity);

            return ally;
        }
    }
}
