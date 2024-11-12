using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Grapper;

namespace _Scripts.Gameplay.Items.Container
{
    public class ItemsContainer : IItemsContainer
    {
        private readonly List<Item> _items = new ();
        private readonly List<Item> _deliveredItems = new ();

        public event Action DeliveryItem;
        public event Action AllItemsDelivered;

        public void AddItem(Item item) => 
            _items.Add(item);

        public void TryAddDeliveredItem(Item item)
        {
            if (!_items.Contains(item))
                return;
            
            if (!item.IsDelivered)
                return;
            
            DeliveryItem?.Invoke();
            _deliveredItems.Add(item);

            if (_items.Count == _deliveredItems.Count)
                AllItemsDelivered?.Invoke();
        }
    }
}