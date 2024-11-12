using _Scripts.Gameplay.Input;
using _Scripts.Gameplay.Items;
using UnityEngine;

namespace _Scripts.Gameplay.Grapper
{
    public class Grapper : IGrapper
    {
        private Camera _camera;
        
        private IInputService _inputService;
        private Item _currentObject;

        public Grapper(IInputService inputService) => 
            _inputService = inputService;

        public void Initialize(Camera camera)
        {
            _inputService.GrapAction += Grap;
            _camera = camera;
        }

        public void Update()
        {
            if (_currentObject == null)
                return;
            
            Vector3 targetPosition =
                _camera.transform.position + _camera.transform.forward *
                    Mathf.Clamp(_inputService.ScrollValue, 2f, 7f);
            
            _currentObject.transform.position = 
                Vector3.Lerp(_currentObject.transform.position,
                    targetPosition, Time.deltaTime * 5f);
        }

        private void Grap()
        {
            if (_currentObject)
            {
                _currentObject.UnGrap();
                _currentObject = null;
                return;
            }
            
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
            Ray ray = _camera.ScreenPointToRay(screenCenter);
            
            if (!Physics.Raycast(ray, out RaycastHit hit, 10))
                return;
            
            if (!hit.collider.TryGetComponent(out Item item))
                return;

            if (item.TryGrap()) 
                _currentObject = item;
        }
    }
}
