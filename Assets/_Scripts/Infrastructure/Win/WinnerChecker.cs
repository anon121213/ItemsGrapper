using System;
using _Scripts.Gameplay.Items;
using _Scripts.Gameplay.Items.Container;
using UnityEngine;

namespace _Scripts.Infrastructure.Win
{
    public class WinnerChecker : IWinnerChecker
    {
        private readonly IItemsContainer _itemsContainer;
        public event Action WinEvent;

        public WinnerChecker(IItemsContainer itemsContainer) => 
            _itemsContainer = itemsContainer;

        public void Initialize() => 
            _itemsContainer.AllItemsDelivered += Win;

        private void Win()
        {
            Debug.Log("win");
            WinEvent?.Invoke();
        }
    }

    public interface IWinnerChecker
    {
        event Action WinEvent;
        void Initialize();
    }
}