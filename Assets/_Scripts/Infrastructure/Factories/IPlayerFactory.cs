using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Factories
{
    public interface IPlayerFactory
    {
        UniTask CreatePlayer(Transform spawnPoint);
    }
}