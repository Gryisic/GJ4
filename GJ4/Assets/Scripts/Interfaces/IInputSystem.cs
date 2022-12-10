using GJ4.Battle;
using System;

namespace GJ4.Interfaces
{
    public interface IInputSystem  
    {
        event Action<PointerEventArgs> PointerDown;
        event Action<PointerEventArgs> PointerDrag;
        event Action<PointerEventArgs> PointerUp;
    }
}
