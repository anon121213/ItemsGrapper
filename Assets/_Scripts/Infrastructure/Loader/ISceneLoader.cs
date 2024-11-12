using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace _Scripts.Infrastructure.Loader
{
    public interface ISceneLoader
    {
        UniTask Load(AssetReference nextScene, Action onLoaded = null);
    }
}