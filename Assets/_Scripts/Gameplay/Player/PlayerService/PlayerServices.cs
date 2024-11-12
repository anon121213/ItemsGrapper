using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Player.PlayerService.Services;
using UnityEngine;

namespace _Scripts.Gameplay.Player.PlayerService
{
    public class PlayerServices : IPlayerServices
    {
        private readonly List<IUpdatable> _updatableServices = new();
        private readonly List<IFixedUpdatable> _fixedUpdatableServices = new();
        private readonly Dictionary<Type, object> _services = new();

        private bool _isStarted;
        
        public PlayerServices(IEnumerable<IUpdatable> updatables,
            IEnumerable<IFixedUpdatable> fixedUpdatables)
        {
            foreach (var service in updatables) 
                _updatableServices.Add(service);

            foreach (var service in fixedUpdatables)
                _fixedUpdatableServices.Add(service);
        }

        public bool TryGetService<T>(out T service)
        {
            if (_services.TryGetValue(typeof(T), out object value))
            {
                service = (T)value;
                return true;
            }

            service = default;
            return false;
        }

        public void Update()
        {
            if (!_isStarted)
                return;
            
            foreach (var service in _updatableServices) 
                service.Update();
        }
        
        public void FixedUpdate()
        {
            if (!_isStarted)
                return;
            
            foreach (var service in _fixedUpdatableServices) 
                service.FixedUpdate();
        }

        public void StopServices() => 
            _isStarted = false;

        public void StartServices() => 
            _isStarted = true;
    }

    public interface IPlayerServices
    {
        public bool TryGetService<T>(out T service);
        public void Update();
        public void FixedUpdate();
        public void StopServices();
        public void StartServices();
    }
}