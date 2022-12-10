using System.Collections.Generic;
using System.Linq;

namespace GJ4.Battle
{
    public class Line 
    {
        public List<Cell> Cells => _cells.Values.ToList();

        private Dictionary<int, Cell> _cells = new Dictionary<int, Cell>();

        public void AddCell(int positionX, Cell cell) 
        {
            if (_cells.ContainsKey(positionX))
                throw new System.ArgumentException($"Cell in positionX {positionX} is already exist");

            _cells[positionX] = cell;
        }

        public bool TryGetCell(int positionX, out Cell cell) 
        {
            if (_cells.ContainsKey(positionX) == false)
            {
                cell = null;
                return false;
            }

            return _cells.TryGetValue(positionX, out cell); 
        }
    }
}