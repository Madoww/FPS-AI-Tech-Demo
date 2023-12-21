using FPS.Common;
using FPS.Core.Entities;
using System;
using UnityEngine;

namespace FPS.Core.Presentation.Audio
{
    public class GameEntityAudioPresenter<T> : MonoBehaviour, IInitializable, IDeinitializable where T : GameEntity
    {
        public event Action OnInitialized;
        public event Action OnDeinitialized;

        [SerializeField]
        private bool selfInitialize;
        [SerializeField]
        private T entity;

        public bool IsInitialized { get; private set; }

        protected T Entity => entity;

        protected virtual void Awake()
        {
            if (selfInitialize)
            {
                Initialize();
            }
        }

        public void Initialize()
        {
            if (IsInitialized)
            {
                return;
            }

            entity.OnInitialized += OnInitializeEntity;
            entity.OnDeinitialized += OnDeinitializeEntity;

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

            entity.OnInitialized -= OnInitializeEntity;
            entity.OnDeinitialized -= OnDeinitializeEntity;

            OnDeinitialize();
            IsInitialized = false;
            OnDeinitialized?.Invoke();
        }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }

        protected virtual void OnInitializeEntity()
        { }

        protected virtual void OnDeinitializeEntity()
        { }
    }
}