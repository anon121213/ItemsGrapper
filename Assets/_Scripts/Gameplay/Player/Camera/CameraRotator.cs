using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input;
using _Scripts.Gameplay.Player.PlayerService.Services;
using UnityEngine;

namespace _Scripts.Gameplay.Player.Camera
{
    public class CameraRotator : ICameraRotator, IUpdatable
    {
        private UnityEngine.Camera _camera;
        private readonly IInputService _inputService;
        private readonly float _mouseSpeed;
        
        private float _xRotation;
        private float _yRotation;
        
        public CameraRotator(IDataProvider dataProvider, 
            IInputService inputService)
        {
            _inputService = inputService;
            _mouseSpeed = dataProvider.PlayerSettings.MouseSpeed;
        }

        public void Initialize(UnityEngine.Camera camera) => 
            _camera = camera;

        public void Update()
        {
            float mouseX = _inputService.LookXAxis * _mouseSpeed * Time.deltaTime;
            float mouseY = _inputService.LookYAxis * _mouseSpeed * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            _yRotation += mouseX;

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        }
    }
}