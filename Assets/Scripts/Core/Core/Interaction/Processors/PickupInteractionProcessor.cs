using FPS.Core.Interaction.Interactables;
using FPS.Core.Player;
using FPS.Core.Player.Handlers;
using UnityEngine;
using Zenject;

namespace FPS.Core.Interaction.Processors
{
    public class PickupInteractionProcessor : InteractionProcessor
    {
        private IPlayerController playerController;

        private InventoryHandler InventoryHandler
        {
            get
            {
                var playerEntity = playerController.PlayerEntity;
                return playerEntity.GetHandler<InventoryHandler>();
            }
        }

        public override void Process(Interactable interactable)
        {
            base.Process(interactable);
            if (interactable is not PickupInteractable pickupInteractable)
            {
                return;
            }

            Debug.Log("Picked up item");
        }

        [Inject]
        internal void Bind(IPlayerController playerController)
        {
            this.playerController = playerController;
        }
    }
}