using FPS.Entities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Player
{
    public class PlayerEntity : GameEntity
    {
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<IPlayerHandler> handlers;

        private readonly Dictionary<Type, IPlayerHandler> handlersByType = new Dictionary<Type, IPlayerHandler>();

        private PlayerModel playerModel;

        public T GetHandler<T>() where T : class, IPlayerHandler
        {
            var type = typeof(T);
            if (!handlersByType.TryGetValue(type, out var handler))
            {
                Debug.LogError($"Handler not found: {type.Name}");
                return null;
            }

            return (T)handler;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            playerModel = new PlayerModel();
            InitializeHandlers();
        }

        protected override void OnDeinitialize()
        {
            DeinitializeHandlers();
            base.OnDeinitialize();
        }

        private void InitializeHandlers()
        {
            foreach (var handler in handlers)
            {
                handler.Initialize(playerModel);
                var type = handler.GetType();
                handlersByType.Add(type, handler);
            }
        }

        private void DeinitializeHandlers()
        {
            foreach (var handler in handlers)
            {
                handler.Deinitialize();
            }

            handlersByType.Clear();
        }
    }
}