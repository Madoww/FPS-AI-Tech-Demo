using System;

namespace FPS.Entities.Weapons
{
    public abstract class WeaponEntity : GameEntity
    {
        public event Action OnFired;
        public event Action OnReloaded;

        public void Fire()
        {
            OnFire();
            OnFired?.Invoke();
        }

        public void Relad()
        {
            OnReload();
            OnReloaded?.Invoke();
        }

        protected virtual void OnFire()
        { }

        protected virtual void OnReload()
        { }
    }
}