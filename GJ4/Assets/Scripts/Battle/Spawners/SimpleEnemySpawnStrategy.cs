using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static GJ4.Utils.Enums;

namespace GJ4.Battle
{
    public class SimpleEnemySpawnStrategy : EnemySpawnStrategy
    {
        private float timeBeetwenSpawn = 2f;

        public SimpleEnemySpawnStrategy(List<EnemySpawnPoint> spawnPoints, List<EnemyType> enemies) : base(spawnPoints, enemies) { }

        public override async UniTask<EnemyType> EnemyToSpawn(CancellationToken cancellationToken = default)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(timeBeetwenSpawn));

            return EnemyType.Skeleton;
        }

        public override async UniTask<Vector2> PositionToSpawn(CancellationToken cancellationToken = default) 
        {
            await UniTask.Delay(TimeSpan.FromSeconds(timeBeetwenSpawn));

            var position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)].Position;

            return position;
        }
    }
}
