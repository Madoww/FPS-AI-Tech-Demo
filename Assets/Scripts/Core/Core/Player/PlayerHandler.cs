using System;

namespace FPS.Core.Player
{
    public abstract class PlayerHandler : IPlayerHandler
    {
        public event Action OnInitialized;
        public event Action OnDeinitialized;

        public bool IsInitialized { get; private set; }

        protected PlayerModel PlayerModel { get; private set; }

        public void Initialize(PlayerModel playerModel)
        {
            if (IsInitialized)
            {
                return;
            }

            PlayerModel = playerModel;
            OnInitialize();
            IsInitialized = true;
            OnInitialized?.Invoke();
        }

        public void Deinitialize()
        {
            if (!IsInitialized)
            {
                return;
            }

            OnDeinitialize();
            IsInitialized = false;
            OnDeinitialized?.Invoke();
        }

        public void Update()
        {
            if (!IsInitialized)
            {
                return;
            }

            OnUpdate();
        }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }

        protected virtual void OnUpdate()
        { }
    }
}