using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Infrastructure.SpawnContainer
{
    public class SpawnPointsContainer : MonoBehaviour, ISpawnPointContainer
    {
        [SerializeField] private List<Transform> _itemsSpawnPoints;
        [SerializeField] private Transform _playerSpawnPoint;

        public List<Transform> ItemsSpawnPoints =>
            _itemsSpawnPoints;

        public Transform PlayerSpawnPoint =>
            _playerSpawnPoint;
    }

    public interface ISpawnPointContainer
    {
        List<Transform> ItemsSpawnPoints { get; }
        Transform PlayerSpawnPoint { get; }
    }
}