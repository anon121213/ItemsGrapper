using _Scripts.Data.DataProvider;
using _Scripts.Gameplay.Input;
using _Scripts.Gameplay.Player.Camera;
using _Scripts.Gameplay.Player.PlayerService.Services;
using UnityEngine;

namespace _Scripts.Gameplay.Player.PlayerActions
{
    public class PlayerMover : IPlayerMover, IFixedUpdatable
    {
        private readonly IInputService _inputService;
        private readonly IDataProvider _dataProvider;

        private CharacterController _characterController;
        private UnityEngine.Camera _camera;
        
        private float _speed;
        private float _gravity;
        private float _verticalVelocity;

        public PlayerMover(IInputService inputService,
            IDataProvider dataProvider,
            ICameraRotator cameraRotator)
        {
            _inputService = inputService;
            _dataProvider = dataProvider;
        }

        public void Initialize(CharacterController characterController,
            UnityEngine.Camera camera)
        {
            _characterController = characterController;
            _speed = _dataProvider.PlayerSettings.Speed;
            _gravity = _dataProvider.PlayerSettings.Gravity;
            _camera = camera;
        }

        public void FixedUpdate()
        {
            if (_characterController.isGrounded)
                _verticalVelocity = 0f;
            else
                ApplyGravity();

            Vector3 moveVector = GetMoveVector();
            moveVector.y = _verticalVelocity;
            _characterController.Move(moveVector * Time.fixedDeltaTime);
        }

        private Vector3 GetMoveVector()
        {
            Vector3 move = _inputService.MoveAxis;
            Vector3 moveDirection = _camera.transform.forward * move.z + _camera.transform.right * move.x;

            moveDirection.y = 0f;
            moveDirection.Normalize();

            Vector3 velocity = moveDirection * _speed;
            return velocity;
        }

        private void ApplyGravity() => 
            _verticalVelocity -= _gravity * Time.fixedDeltaTime;
    }
}
