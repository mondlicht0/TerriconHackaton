using Project.Controls;
using Project.Weapons;
using UnityEngine;
using Zenject;

namespace Project.Player
{
    public class PlayerWeaponHolder : MonoBehaviour
    {
        [SerializeField] private Transform _weaponHolder;
        [SerializeField] private Weapon _initialWeapon;
        private Weapon _currentWeapon;
        private InputHandler _input;

        [Inject]
        private void Construct(InputHandler input)
        {
            _input = input;
        }

        private void Awake()
        {
            EquipWeapon(_initialWeapon);
            _initialWeapon.Spawn(_weaponHolder);
        }

        private void Update()
        {
            if (_currentWeapon)
            {
                _currentWeapon.Tick(_input.FireTriggered, _input.SpecialAttackTriggered);
            }
        }

        private void EquipWeapon(Weapon newWeapon)
        {
            _currentWeapon = newWeapon;
        }

        private void DequipWeapon()
        {
            //_currentWeapon = null;
        }
    }
}
