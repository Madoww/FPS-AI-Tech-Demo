using FPS.Core.Character.Items;
using UnityEngine;

namespace FPS.Core.Interaction.Interactables
{
    public class PickupInteractable : Interactable
    {
        [SerializeField]
        private ItemEntity itemEntity;

        public ItemEntity ItemEntity => itemEntity;

        protected override void OnInteract()
        {
            base.OnInteract();
            Destroy(itemEntity.gameObject);
        }
    }
}