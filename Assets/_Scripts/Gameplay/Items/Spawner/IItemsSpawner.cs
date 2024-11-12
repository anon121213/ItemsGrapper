using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Items.Spawner
{
    public interface IItemsSpawner
    {
        UniTask SpawnItems(List<Transform> spawnPoint);
    }
}