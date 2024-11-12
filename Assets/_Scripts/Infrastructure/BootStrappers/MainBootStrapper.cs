using _Scripts.Data.DataProvider;
using _Scripts.Infrastructure.Loader;
using UnityEngine;
using VContainer.Unity;

namespace _Scripts.Infrastructure.BootStrappers
{
    public class MainBootStrapper : IStartable
    {
        private const int FRAMERATE = 240;
        
        private readonly IDataProvider _dataProvider;
        private readonly ISceneLoader _sceneLoader;

        public MainBootStrapper(IDataProvider dataProvider,
            ISceneLoader sceneLoader)
        {
            _dataProvider = dataProvider;
            _sceneLoader = sceneLoader;
        }

        public async void Start()
        {
            Application.targetFrameRate = FRAMERATE;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            await _sceneLoader.Load(_dataProvider.ObjectsReferences.MainScene);
        }
    }
}
