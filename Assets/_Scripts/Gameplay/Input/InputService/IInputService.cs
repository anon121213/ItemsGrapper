using System;
using UnityEngine;

namespace _Scripts.Gameplay.Input
{
    public interface IInputService : IDisposable
    {
        event Action GrapAction;
        Vector3 MoveAxis { get; }
        float LookXAxis { get; }
        float LookYAxis { get; }
        float ScrollValue { get; }
        void Initialize();
    }
}