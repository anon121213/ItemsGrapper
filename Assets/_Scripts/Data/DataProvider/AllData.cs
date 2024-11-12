using UnityEngine;

namespace _Scripts.Data.DataProvider
{
    [CreateAssetMenu(fileName = "AllData", menuName = "Data/AllData")]
    public class AllData : ScriptableObject
    {
        public DefaultPlayerSettings DefaultPlayerSettings;
        public ObjectsReferences ObjectsReferences;
        public ItemsReferences ItemsReferences;
    }
}