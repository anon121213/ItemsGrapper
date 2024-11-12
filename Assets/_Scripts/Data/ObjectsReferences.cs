using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "AssetsReferences", menuName = "Data/AssetsReferences")]
    public class ObjectsReferences : ScriptableObject
    {
        [SerializeField] private AssetReference _mainScene;
        [SerializeField] private AssetReferenceGameObject _player;

        public AssetReference MainScene =>
            _mainScene;

        public AssetReferenceGameObject Player =>
            _player;
    }
}