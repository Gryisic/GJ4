using System.Collections.Generic;
using UnityEngine;
using static GJ4.Utils.Enums;

namespace GJ4.Battle
{
    [CreateAssetMenu(menuName = "Configs / Battle / Battles / BattleTemplate", fileName = "Battle")]
    public class BattleConfig : ScriptableObject
    {
        [SerializeField] private SpawnStrategyType _spawnStrategyType;
        [SerializeField] private List<EnemyType> _enemies;

        public SpawnStrategyType SpawnStrategyType => _spawnStrategyType;
        public List<EnemyType> Enemies => _enemies;
    }
}
