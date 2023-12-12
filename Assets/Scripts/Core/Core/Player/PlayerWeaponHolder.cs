using UnityEngine;
using Zenject;

namespace FPS.Core.Player
{
    using FPS.Core.Entities.Weapons;
    using FPS.Core.Prefabs;

    public class PlayerWeaponHolder : MonoBehaviour
    {
        [SerializeField]
        private WeaponEntity currentWeapon;

        //TODO: Consider moving.
        private IPrefabsManager prefabsManager;

        [Inject]
        internal void Bind(IPrefabsManager prefabsManager)
        {
            this.prefabsManager = prefabsManager;
        }

        public void Equip(WeaponEntity weaponEntity)
        {
            currentWeapon = weaponEntity;

            Instantiate(weaponEntity);
        }
    }
}