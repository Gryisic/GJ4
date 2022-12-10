using System;
using System.Collections.Generic;

namespace GJ4.Battle
{
    public class UnitContainer : IDisposable
    {
        private List<Ally> _allies = new List<Ally>();
        private List<Enemy> _enemies = new List<Enemy>();

        public IReadOnlyList<Ally> Allies => _allies;
        public IReadOnlyList<Enemy> Enemies => _enemies;

        public void Dispose()
        {
            _allies = null;
            _enemies = null;
        }

        public void Add(Unit unit)
        {
            if (unit == null)
                throw new System.ArgumentNullException(nameof(unit));

            if (unit is Ally)
                _allies.Add(unit as Ally);
            else
                _enemies.Add(unit as Enemy);
        }

        public bool Remove(Unit unit) 
        {
            if (unit == null)
                throw new System.ArgumentNullException(nameof(unit));

            if (unit is Ally && _allies.Contains(unit as Ally))
                return _allies.Remove(unit as Ally);
            else if (_enemies.Contains(unit as Enemy))
                return _enemies.Remove(unit as Enemy);

            return false;
        }
    }
}
