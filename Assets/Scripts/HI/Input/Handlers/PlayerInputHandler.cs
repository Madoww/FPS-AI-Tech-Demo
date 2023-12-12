using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FPS.HI.Input.Handlers
{
    using FPS.HI.Input;
    using FPS.HI.Player;
    using static FPS.HI.Input.PlayerControls;

    public class PlayerInputHandler : IPlayerInputHandler
    {
        private PlayerControls playerControls;
        private IPlayerMovementController playerMovementController;
        private IPlayerCameraController playerCameraController;

        public void Enable()
        {
            playerControls.OnFoot.Enable();
        }

        public void Disable()
        {
            playerControls.OnFoot.Disable();
        }

        public void Tick()
        {
            UpdateMovementInput();
        }

        [Inject]
        internal void Bind(PlayerControls playerControls, IPlayerMovementController playerMovementController, IPlayerCameraController playerCameraController)
        {
            this.playerControls = playerControls;
            this.playerMovementController = playerMovementController;
            this.playerCameraController = playerCameraController;
            playerControls.OnFoot.SetCallbacks(this);
        }

        private void UpdateMovementInput()
        {
            Vector2 movementVector = playerControls.OnFoot.Movement.ReadValue<Vector2>();
            playerMovementController.Move(movementVector);
        }

        void IOnFootActions.OnMovement(InputAction.CallbackContext context)
        { }

        void IOnFootActions.OnLook(InputAction.CallbackContext context)
        {
            Vector2 lookVector = context.ReadValue<Vector2>();
            playerCameraController.ProcessLook(lookVector);
        }
    }
}