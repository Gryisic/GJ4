using GJ4.Utils;
using System.Collections.Generic;
using UnityEngine;
using static GJ4.Utils.Enums;

namespace GJ4.Battle
{
    public class EnemyFactory 
    {
        private Dictionary<int, Enemy> _enemies = new Dictionary<int, Enemy>();

        public void Load(List<EnemyType> enemies)
        {
            foreach (var enemy in enemies) 
            {
                _enemies.Add((int)enemy, Resources.Load<Enemy>($"{Constants.ENEMY_PREFABS}/{enemy}"));

                if (_enemies[(int)enemy] == null)
                    throw new System.NullReferenceException($"{enemy} is not assigned or not found in 'Resources'");
            }
        }

        public Enemy Create(EnemyType type, Vector2 at) 
        {
            var enemy = GameObject.Instantiate(_enemies[(int)type], at, Quaternion.identity);

            return enemy; 
        }
    }
}
