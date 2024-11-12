using _Scripts.Gameplay.Player.PlayerService.Services;
using UnityEngine;

namespace _Scripts.Gameplay.Grapper
{
    public interface IGrapper : IUpdatable
    {
        void Initialize(Camera camera);
    }
}