using UnityEngine;

namespace _Scripts.Gameplay.Player.PlayerActions
{
    public interface IPlayerMover
    {
        void Initialize(CharacterController characterController,
            UnityEngine.Camera camera);
    }
}