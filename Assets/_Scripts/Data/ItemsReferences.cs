using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "Items", menuName = "Data/Items")]
    public class ItemsReferences : ScriptableObject
    {
        [SerializeField] private List<AssetReferenceGameObject> _items = new ();
        
        public List<AssetReferenceGameObject> Items => _items;
    }
}