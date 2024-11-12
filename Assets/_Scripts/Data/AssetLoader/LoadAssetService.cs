using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _Scripts.Data.AssetLoader
{
    public class LoadAssetService : ILoadAssetService
    {
        public async UniTask<TObject> GetAsset<TObject>(AssetReference path) where TObject : Object => 
            await LoadAsset<TObject>(path);

        private async UniTask<TObject> LoadAsset<TObject>(AssetReference path) where TObject : Object
        {
            AsyncOperationHandle<TObject> handle = Addressables.LoadAssetAsync<TObject>(path);

            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
                return handle.Result;

            Debug.LogError($"Не удалось загрузить префаб по пути: {path}");
            return null;
        }
    }
}