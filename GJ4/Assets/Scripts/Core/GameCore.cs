using GJ4.Battle;
using GJ4.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GJ4.Core
{
    public class GameCore 
    {
        private List<IService> _services;

        public void Construct() 
        {
            RegisterServices();
        }

        public T GetService<T>() where T : IService
        {
            return (T) _services.First(s => s is T);
        }

        private void RegisterServices() 
        {
            _services = new List<IService>() 
            {
                
            };
        }
    }
}