using _Scripts.Gameplay.Items.Container;
using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.Items
{
    [RequireComponent(typeof(Rigidbody))]
    public class Item : MonoBehaviour
    {
        private Rigidbody _rb;
        private IItemsContainerDelivered _itemsContainer;
        
        public bool IsGraped { get; private set; }
        public bool IsDelivered { get; private set; }

        [Inject]
        private void Inject(IItemsContainer itemsContainer) => 
            _itemsContainer = itemsContainer;

        private void Awake()
        {
            GetComponent<MeshCollider>().convex = true;
            _rb = GetComponent<Rigidbody>();
        }

        public bool TryGrap()
        {
            if (IsGraped || IsDelivered)
                return false;
            
            IsGraped = true;
            _rb.isKinematic = true;
            _rb.useGravity = false;

            return true;
        }

        public void UnGrap()
        {
            IsGraped = false;
            _rb.isKinematic = false;
            _rb.useGravity = true;
        }

        public void TryDelivery()
        {
            if (IsDelivered || IsGraped)
                return;
            
            IsDelivered = true;
            IsGraped = false;
            _itemsContainer.TryAddDeliveredItem(this);
        }
    }
}