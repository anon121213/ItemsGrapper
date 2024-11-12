using System;
using _Scripts.Gameplay.Player.PlayerService;
using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        private IPlayerServices _playerServices;

        [Inject]
        private void Inject(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }

        private void Start()
        {
            _playerServices.StartServices();
        }

        private void Update()
        {
            _playerServices.Update();
        }

        private void FixedUpdate()
        {
            _playerServices.FixedUpdate();
        }

        private void OnDestroy()
        {
            _playerServices.StopServices();
        }
    }
}