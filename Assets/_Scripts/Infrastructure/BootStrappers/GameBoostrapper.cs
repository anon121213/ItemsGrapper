using _Scripts.Gameplay.Input;
using _Scripts.Gameplay.Items.Spawner;
using _Scripts.Infrastructure.Factories;
using _Scripts.Infrastructure.SpawnContainer;
using _Scripts.Infrastructure.Win;
using UnityEngine;
using VContainer;

namespace _Scripts.Infrastructure.BootStrappers
{
    public class GameBoostrapper : MonoBehaviour
    {
        private IInputService _inputService;
        private IPlayerFactory _playerFactory;
        private IItemsSpawner _itemSpawner;
        private ISpawnPointContainer _spawnPointContainer;
        private IWinnerChecker _winnerChecker;

        [Inject]
        public void Inject(IPlayerFactory playerFactory,
            IInputService inputService,
            IItemsSpawner itemsSpawner,
            IWinnerChecker winnerChecker,
            ISpawnPointContainer spawnPointContainer)
        {
            _playerFactory = playerFactory;
            _inputService = inputService;
            _itemSpawner = itemsSpawner;
            _spawnPointContainer = spawnPointContainer;
            _winnerChecker = winnerChecker;
        }

        public async void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            await _itemSpawner.SpawnItems(_spawnPointContainer.ItemsSpawnPoints);
            await _playerFactory.CreatePlayer(_spawnPointContainer.PlayerSpawnPoint);
            
            _winnerChecker.Initialize();
            _inputService.Initialize();
        }
    }
}