using System;
using _Scripts.Gameplay.Input.PcInput;
using UnityEngine;

namespace _Scripts.Gameplay.Input
{
    public class InputService : IInputService
    {
        private PlayerInput _pcInput;
        private GameInput _gameInput;

        public event Action GrapAction;

        public Vector3 MoveAxis =>
            _pcInput.GetMoveDirection();

        public float LookXAxis =>
            _pcInput.GetLookVector().x;
        
        public float LookYAxis =>
            _pcInput.GetLookVector().y;

        public float ScrollValue =>
            _pcInput.GetScrollValue();
        
        public void Initialize()
        {
            _gameInput = new GameInput();
            _pcInput = new PCInput(_gameInput);
            
            _pcInput.Grap += Grap;
            _gameInput.Enable();
        }

        private void Grap() => 
            GrapAction?.Invoke();

        public void Dispose()
        {
            _pcInput.Grap -= Grap;
            _gameInput.Dispose();
        }
    }
}