using _Scripts.Gameplay.Grapper;
using _Scripts.Gameplay.Items;
using UnityEngine;

namespace _Scripts.Gameplay.Car
{
    public class CarItemAdder : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out Item item))
                return;

            if(item.IsGraped)
                return;

            if (item.IsDelivered)
                return;
            
            item.TryDelivery();
        }
    }
}