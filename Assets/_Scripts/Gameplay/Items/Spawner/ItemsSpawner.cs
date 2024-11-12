using System;
using System.Collections.Generic;
using _Scripts.Data.AssetLoader;
using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Items.Container;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace _Scripts.Gameplay.Items.Spawner
{
    public class ItemsSpawner : IItemsSpawner
    {
        private List<Transform> _spawnPoints = new();
        
        private readonly IDataProvider _dataProvider;
        private readonly ILoadAssetService _loadAssetService;
        private readonly IItemsContainer _itemsContainer;
        private readonly IObjectResolver _resolver;
        private readonly Collider[] _results = new Collider[10];
        
        public ItemsSpawner(IDataProvider dataProvider,
            ILoadAssetService loadAssetService,
            IItemsContainer itemsContainer,
            IObjectResolver resolver)
        {
            _dataProvider = dataProvider;
            _loadAssetService = loadAssetService;
            _itemsContainer = itemsContainer;
            _resolver = resolver;
        }

        public async UniTask SpawnItems(List<Transform> spawnPoints)
        {
            _spawnPoints = spawnPoints;
            
            foreach (var spawnPoint in _spawnPoints)
            {
                Item item = await GetItem(spawnPoint.position);
                
                if (item == null)
                    continue;

                item = _resolver.Instantiate(item, spawnPoint);
                
                _itemsContainer.AddItem(item);
            }
        }

        private async UniTask<Item> GetItem(Vector3 spawnPoint)
        {
            List<int> triedIndices = new List<int>();
            
            while (triedIndices.Count < _dataProvider.ItemsReferences.Items.Count)
            {
                int assetIndex = Random.Range(0, _dataProvider.ItemsReferences.Items.Count);
                
                if (triedIndices.Contains(assetIndex))
                    continue;

                triedIndices.Add(assetIndex);
                
                GameObject item = await _loadAssetService.GetAsset<GameObject>
                    (_dataProvider.ItemsReferences.Items[assetIndex]);
                
                BoxCollider prefabCollider = item.GetComponent<BoxCollider>();
                Vector3 size = prefabCollider.size;
                
                Array.Clear(_results, 0, _results.Length);
                Physics.OverlapBoxNonAlloc(spawnPoint, size / 2, _results);
                
                if (_results.Length == 0 || _results[0] == null)
                    return item.GetComponent<Item>();
            }
            
            Debug.LogWarning("Failed to find a valid spawn point after checking all items.");
            return null;
        }
    }
}
