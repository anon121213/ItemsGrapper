using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Grapper;
using _Scripts.Gameplay.Player.Camera;
using _Scripts.Gameplay.Player.PlayerActions;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly IObjectResolver _resolver;
        private readonly IPlayerMover _playerMover;
        private readonly ICameraRotator _cameraRotator;
        private readonly IGrapper _grapper;
        private readonly Camera _camera;
        private readonly ILoadAssetService _loadAssetService;
        private CharacterController _characterController;

        public PlayerFactory(ILoadAssetService loadAssetService,
            IDataProvider dataProvider,
            IObjectResolver resolver,
            IPlayerMover playerMover,
            ICameraRotator cameraRotator,
            IGrapper grapper,
            Camera camera)
        {
            _loadAssetService = loadAssetService;
            _dataProvider = dataProvider;
            _resolver = resolver;
            _playerMover = playerMover;
            _cameraRotator = cameraRotator;
            _grapper = grapper;
            _camera = camera;
        }

        public async UniTask CreatePlayer(Transform spawnPoint)
        {
            GameObject playerPreafab = await _loadAssetService
                .GetAsset<GameObject>(_dataProvider.ObjectsReferences.Player);
            
            GameObject player = _resolver.Instantiate(playerPreafab, spawnPoint.position, Quaternion.identity);
            
            _characterController = player.GetComponent<CharacterController>();

            InitializeCamera(_camera, _characterController);
            InitializeGrapper(_camera);
            InitializePlayerMover(_characterController, _camera);
        }

        private void InitializeCamera(Camera camera,
            CharacterController characterController)
        {
            CameraFollow follower = camera.GetComponent<CameraFollow>();
            
            follower.Initialize(characterController.transform, new Vector3(0, 0.8f, 0));
            
            _cameraRotator.Initialize(camera);
        }

        private void InitializeGrapper(Camera camera) =>
            _grapper.Initialize(camera);

        private void InitializePlayerMover(CharacterController characterController, 
            Camera camera) =>
            _playerMover.Initialize(characterController, camera);
    }
}