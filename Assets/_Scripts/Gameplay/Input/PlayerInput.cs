using System;
using UnityEngine;

namespace _Scripts.Gameplay.Input
{
    public abstract class PlayerInput
    {
        public abstract event Action Grap;
        public abstract Vector3 GetMoveDirection();
        public abstract Vector3 GetLookVector();
        public abstract float GetScrollValue();
    }
}