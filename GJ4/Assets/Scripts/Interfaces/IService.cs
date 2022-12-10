using System;

namespace GJ4.Interfaces
{
    public interface IService : IDisposable
    {
        void Enable();

        void Disable();
    }
}
