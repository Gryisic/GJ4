using System.Collections.Generic;
using GJ4.Utils;
using UnityEngine;
using System.Linq;

namespace GJ4.Battle
{
    public class Grid
    {
        public List<Line> Lines => _lines.Values.ToList();
        public List<EnemySpawnPoint> SpawnPoints => _spawnPoints;

        private Dictionary<int, Line> _lines = new Dictionary<int, Line>();
        private List<EnemySpawnPoint> _spawnPoints = new List<EnemySpawnPoint>();

        private int _minY, _maxY = int.MinValue;
        private int _minX, _maxX = int.MinValue;

        public Grid(Vector2Int from, Vector2Int to) 
        {
            Generate(from, to);
        }

        public bool TryGetCell(Vector2Int position, out Cell cell) 
        {
            if (_lines.ContainsKey(position.y) == false)
            {
                cell = null;
                return false;
            }

            return _lines[position.y].TryGetCell(position.x, out cell);
        }

        public bool IsPointerOnGrid(Vector3 worldPosition) 
        {
            return worldPosition.x >= _minX 
                && worldPosition.x <= _maxX 
                && worldPosition.y >= _minY 
                && worldPosition.y <= _maxY;
        }

        private void Generate(Vector2Int from, Vector2Int to) 
        {
            _minY = from.y;
            _minX = from.x;

            for (int y = from.y; y < to.y; y++) 
            {
                if (_maxY < y + Constants.CELL_SIZE)
                    _maxY = (int)(y + Constants.CELL_SIZE);

                var midpointYPosition = y + Constants.CELL_SIZE / 2;

                _lines.Add(y, new Line());

                for (int x = from.x; x < to.x; x++)
                {
                    if (_maxX < x + Constants.CELL_SIZE)
                        _maxX = (int)(x + Constants.CELL_SIZE);

                    var midpointXPosition = x + Constants.CELL_SIZE / 2;

                    _lines[y].AddCell(x, new Cell(new Vector2(midpointXPosition, midpointYPosition)));
                }

                _spawnPoints.Add(new EnemySpawnPoint(new Vector2(to.x - Constants.CELL_SIZE / 2, midpointYPosition)));
            }
        }
    }
}