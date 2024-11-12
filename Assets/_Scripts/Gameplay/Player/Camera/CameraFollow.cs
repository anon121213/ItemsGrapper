using UnityEngine;

namespace _Scripts.Gameplay.Player.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        private const float _smoothSpeed = 0.125f;
        
        private Transform _target;
        private Vector3 _offset;

        public void Initialize(Transform target,
            Vector3 offset)
        {
            _target = target;
            _offset = offset;
        }
    
        private void LateUpdate()
        {
            if (!_target)
                return;
            
            Vector3 desiredPosition = _target.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}