using FPS.Core.Character.Items;
using UnityEngine;

namespace FPS.Core.Interaction.Interactables
{
    public class PickupInteractable : Interactable
    {
        [SerializeField]
        private ItemEntity itemEntity;

        public ItemEntity ItemEntity => itemEntity;
    }
}