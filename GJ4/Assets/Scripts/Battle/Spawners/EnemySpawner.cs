using Cysharp.Threading.Tasks;
using GJ4.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static GJ4.Utils.Enums;

namespace GJ4.Battle
{
    public class EnemySpawner : IPausable, IDisposable
    {
        public event Action<UnitCreationArgs> UnitCreated;

        private IEnemySpawnStrategy _spawnStrategy;
        private EnemyFactory _enemyFactory;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private bool _isPaused = false;

        public EnemySpawner(EnemyFactory enemyFactory, BattleConfig config, List<EnemySpawnPoint> spawnPoints) 
        {
            _enemyFactory = enemyFactory;

            Initialize(config.SpawnStrategyType, config.Enemies, spawnPoints);
        }

        public void Start() => SpawnAsync(_cancellationTokenSource.Token).Forget();

        public void Stop() => _cancellationTokenSource.Cancel();

        public void TogglePause(bool isPaused) => _isPaused = isPaused;

        public void Dispose()
        {
            Stop();

            _cancellationTokenSource.Dispose();

            _spawnStrategy = null;
            _enemyFactory = null;
        }

        private void Initialize(SpawnStrategyType type, List<EnemyType> enemies, List<EnemySpawnPoint> spawnPoints)
        {
            switch (type)
            {
                case SpawnStrategyType.Simple:
                    _spawnStrategy = new SimpleEnemySpawnStrategy(spawnPoints, enemies);
                    break;

                default:
                    throw new ArgumentException($"{type} is not assigned");
            }

            _enemyFactory.Load(enemies);
        }

        private async UniTask SpawnAsync(CancellationToken cancellationToken = default) 
        {
            while (cancellationToken.IsCancellationRequested == false) 
            {
                if (_isPaused)
                    await UniTask.WaitUntil(() => _isPaused == false);

                var task1 = _spawnStrategy.EnemyToSpawn(cancellationToken);
                var task2 = _spawnStrategy.PositionToSpawn(cancellationToken);

                var (enemyType, position) = await UniTask.WhenAll(task1, task2);

                var enemy = _enemyFactory.Create(enemyType, position);

                UnitCreated?.Invoke(new UnitCreationArgs(enemy, position));
            }
        }
    }
}
