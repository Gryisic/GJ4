using UnityEngine;
using UnityEngine.EventSystems;

namespace GJ4.Battle
{
    public class PointerEventArgs : System.EventArgs
    {
        public Vector3 WorldPosition { get; }
        public PointerEventData.InputButton Button { get; }

        public PointerEventArgs(PointerEventData.InputButton button, Vector3 worldPosition) 
        {
            Button = button;
            WorldPosition = worldPosition;
        }
    }
}
