using UnityEngine;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "DefaultPlayerSettings", menuName = "Data/DefaultPlayerSettings")]
    public class DefaultPlayerSettings : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _gravity;
        [SerializeField] private float _mouseSpeed;

        public float Speed => _speed;
        public float Gravity => _gravity;
        public float MouseSpeed => _mouseSpeed;
    }
}