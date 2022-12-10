using Cysharp.Threading.Tasks;
using GJ4.Interfaces;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static GJ4.Utils.Enums;

namespace GJ4.Battle
{
    public abstract class EnemySpawnStrategy : IEnemySpawnStrategy
    {
        protected List<EnemySpawnPoint> spawnPoints;
        protected List<EnemyType> enemies;

        public EnemySpawnStrategy(List<EnemySpawnPoint> spawnPoints, List<EnemyType> enemies) 
        {
            this.spawnPoints = spawnPoints;
            this.enemies = enemies;
        }

        public abstract UniTask<EnemyType> EnemyToSpawn(CancellationToken cancellationToken = default);
        public abstract UniTask<Vector2> PositionToSpawn(CancellationToken cancellationToken = default);
    }
}
