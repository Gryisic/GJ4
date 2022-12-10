using GJ4.Interfaces;
using System.Collections.Generic;

namespace GJ4.Battle
{
    public class PausableContainer 
    {
        private List<IPausable> _items = new List<IPausable>();

        public IReadOnlyList<IPausable> Items => _items;

        public void Add(IPausable item) => _items.Add(item);

        public bool TryRemove(IPausable item) => _items.Remove(item);
    }
}
