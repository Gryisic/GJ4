using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using static GJ4.Utils.Enums;

namespace GJ4.Interfaces
{
    public interface IEnemySpawnStrategy 
    {
        UniTask<EnemyType> EnemyToSpawn(CancellationToken cancellationToken = default);

        UniTask<Vector2> PositionToSpawn(CancellationToken cancellationToken = default);
    }
}
