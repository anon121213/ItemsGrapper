using System;
using _Scripts.Infrastructure.Loader;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace _Scripts.Infrastructure
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask Load(AssetReference nextScene, Action onLoaded = null) => 
            await LoadScene(nextScene, onLoaded);

        private async UniTask LoadScene(AssetReference nextScene, Action onLoaded = null)
        {
            if (!nextScene.IsDone)
                return;

            AsyncOperationHandle<SceneInstance> waitNextScene = nextScene.LoadSceneAsync();
            
            await waitNextScene;

            if (waitNextScene.IsDone)
                onLoaded?.Invoke();
        }
    }
}