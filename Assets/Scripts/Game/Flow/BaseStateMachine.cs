using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPS.Game.Flow
{
    public class BaseStateMachine : IStateMachine
    {
        public event Action<BaseState> OnStateChanged;

        public BaseState CurrentState { get; private set; }

        private readonly BaseState startState;
        private readonly Dictionary<Type, BaseState> statesByType;

        public BaseStateMachine(IReadOnlyList<BaseState> states, BaseState startState = null)
        {
            this.startState = startState;
            statesByType = new Dictionary<Type, BaseState>();
            for (var i = 0; i < states.Count; i++)
            {
                AppendState(states[i]);
            }
        }

        public void Start()
        {
            var state = startState == null
                ? statesByType.First().Value
                : startState;
            ChangeState(state);
        }

        public void Stop()
        {
            CurrentState?.Close();
            CurrentState = null;
        }

        public void Tick()
        {
            if (CurrentState == null)
            {
                return;
            }

            CurrentState.Tick();
            if (!CurrentState.WantsToClose())
            {
                return;
            }

            var destinations = CurrentState.Destinations;
            foreach (var destination in destinations)
            {
                if (TryGetState(destination, out BaseState state))
                {
                    if (state.WantsToBegin())
                    {
                        ChangeState(state);
                    }
                }
                else
                {
                    Debug.LogWarning($"[States] Can't find state: {destination.Name}");
                }
            }
        }

        public bool ChangeState(BaseState state)
        {
            return ChangeState(state.Type);
        }

        public bool ChangeState(Type newStateType)
        {
            if (!statesByType.TryGetValue(newStateType, out var newState))
            {
                return false;
            }

            CurrentState?.Close();
            CurrentState = newState;
            CurrentState.Begin();
            OnStateChanged?.Invoke(CurrentState);
            return true;
        }

        private void AppendState(BaseState state)
        {
            var stateType = state.Type;
            if (statesByType.ContainsKey(stateType))
            {
                Debug.LogWarning($"[States] state {stateType} already exists in state machine.");
                return;
            }

            statesByType.Add(stateType, state);
        }

        private bool TryGetState(Type stateType, out BaseState state)
        {
            return statesByType.TryGetValue(stateType, out state);
        }
    }
}