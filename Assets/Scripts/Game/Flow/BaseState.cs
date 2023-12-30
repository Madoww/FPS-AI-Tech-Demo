using System;
using System.Collections.Generic;

namespace FPS.Game.Flow
{
    public abstract class BaseState
    {
        public Type Type => GetType();
        public IReadOnlyList<Type> Destinations => destinationStates;

        private List<Type> destinationStates = new List<Type>();

        public virtual bool WantsToBegin()
        {
            return true;
        }

        public virtual bool WantsToClose()
        {
            return true;
        }

        public virtual void Begin()
        { }

        public virtual void Close()
        { }

        public virtual void Tick()
        { }

        public void AppendDestination(BaseState baseState)
        {
            destinationStates.Add(typeof(BaseState));
        }

        public void AppendDestination<T>() where T : BaseState
        {
            destinationStates.Add(typeof(T));
        }

        public void RemoveDestination(BaseState baseState)
        {
            destinationStates.Remove(typeof(BaseState));
        }

        public void RemoveDestination<T>() where T : BaseState
        {
            destinationStates.Remove(typeof(T));
        }
    }
}