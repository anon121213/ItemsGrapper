using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Gameplay.Input.PcInput
{
    public class PCInput : PlayerInput, IDisposable
    {
        public override event Action Grap;

        private readonly GameInput _gameInput;
        private float _scrollValue = 0f;

        public PCInput(GameInput gameInput)
        {
            _gameInput = gameInput;
            _gameInput.Gameplay.GrapAction.performed += GrapVoid;
            _gameInput.Gameplay.MouseScroll.performed += OnMouseScroll;
        }

        public override Vector3 GetMoveDirection()
        {
            Vector2 inputVector = _gameInput.Gameplay.MoveAction.ReadValue<Vector2>();
            Vector3 moveVector = new Vector3(inputVector.x, 0, inputVector.y);
            return moveVector;
        }

        public override Vector3 GetLookVector() =>
            _gameInput.Gameplay.Lookvector.ReadValue<Vector2>();

        public override float GetScrollValue() =>
            _scrollValue;

        private void OnMouseScroll(InputAction.CallbackContext context)
        {
            float scrollDelta = context.ReadValue<Vector2>().y;
            
            switch (scrollDelta)
            {
                case > 0:
                    _scrollValue += 0.5f;
                    break;
                case < 0:
                    _scrollValue -= 0.5f;
                    break;
            }
        }

        private void GrapVoid(InputAction.CallbackContext context) =>
            Grap?.Invoke();

        public void Dispose()
        {
            _gameInput.Gameplay.GrapAction.performed -= GrapVoid;
            _gameInput.Gameplay.MouseScroll.performed -= OnMouseScroll;
        }
    }
}