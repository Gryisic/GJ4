using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GJ4.Battle
{
    public class Battle : MonoBehaviour, IDisposable
    {
        [SerializeField] private BattleConfig _config;
        [SerializeField] private Tilemap _linesMap;

        private Grid _grid;
        private EnemySpawner _enemySpawner;

        private UnitContainer _unitContainer = new UnitContainer();
        private PausableContainer _iPausableContainer = new PausableContainer();

        private void Awake()
        {
            Initialize();
        }

        public void Dispose()
        {
            DeInitialize();

            _enemySpawner.Dispose();
            _unitContainer.Dispose();
        }

        private void Initialize() 
        {
            InitializeGrid();
            InitializeSpawner();
            InitializeUnitContainer();

            //StartBattle();
        }

        private void InitializeGrid() 
        {
            _linesMap.CompressBounds();

            _grid = new Grid((Vector2Int)_linesMap.origin, (Vector2Int)_linesMap.cellBounds.max);
        }

        private void InitializeSpawner() 
        {
            var enemyFactory = new EnemyFactory();

            _enemySpawner = new EnemySpawner(enemyFactory, _config, _grid.SpawnPoints);

            _iPausableContainer.Add(_enemySpawner);
        }

        private void InitializeUnitContainer() 
        {
            _enemySpawner.UnitCreated += (args) =>
            {
                _unitContainer.Add(args.Unit);
            };
        }

        private void DeInitialize() 
        {
            _enemySpawner.UnitCreated -= (args) =>
            {
                _unitContainer.Add(args.Unit);
            };
        }

        private void StartBattle() 
        {
            _enemySpawner.Start();
        }

        private void SetPause() => TogglePause(true);

        private void ResetPause() => TogglePause(false);

        private void TogglePause(bool isPaused) 
        {
            foreach (var item in _iPausableContainer.Items)
            {
                item.TogglePause(isPaused);
            }
        }
    }
}
