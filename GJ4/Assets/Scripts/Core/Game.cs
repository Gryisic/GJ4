using UnityEngine;

namespace GJ4.Core
{
    public class Game : MonoBehaviour
    {
        private GameCore _core;

        private void Awake()
        {
            _core = new GameCore();
            _core.Construct();
        }
    }
}