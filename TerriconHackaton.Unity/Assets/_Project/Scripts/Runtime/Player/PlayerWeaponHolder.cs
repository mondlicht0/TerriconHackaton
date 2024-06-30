using System;
using System.Collections;
using System.Collections.Generic;
using Project.Controls;
using Project.Systems;
using Project.Weapons;
using UnityEngine;
using Zenject;

namespace Project.Player
{
    public class PlayerWeaponHolder : MonoBehaviour
    {
        [Header("Weapons")]
        [SerializeField] private Bow _bow;
        [SerializeField] private ForceStaff _forcestaff;
        [SerializeField] private Suriken _shuriken;
        [Space]
        [SerializeField] private Transform _weaponHolder;
        [SerializeField] private WeaponType _initialWeapon;
        [Header("Objects")]
        private GameObject _shurikenObject;
        private GameObject _forcestaffObject;
        private GameObject _bowObject;
        private Weapon _currentWeapon;
        private InputHandler _input;
        private List<Checkpoint> _checkpoints = new();

        [Inject]
        private void Construct(InputHandler input)
        {
            _input = input;
        }

        private void Awake()
        {
            InitWeapons();
        }

        private void InitWeapons()
        {
            _bow.Spawn(_weaponHolder);
            _forcestaff.Spawn(_weaponHolder);
            _shuriken.Spawn(_weaponHolder);
            _shuriken.SpawnedModel.SetActive(false);
        }

        private void Start()
        {
            _checkpoints.AddRange(FindObjectsOfType<Checkpoint>());

            foreach (Checkpoint checkpoint in _checkpoints)
            {
                checkpoint.OnCheckpointReached += () => ChangeWeapon(checkpoint.WeaponType);
            }
        }

        private void Update()
        {
            if (_currentWeapon)
            {
                _currentWeapon.Tick(_input.FireTriggered, _input.SpecialAttackTriggered);
            }
            
            CheckChangeWeapon();
        }

        private void CheckChangeWeapon()
        {
            if (_input.IsFirstWeapon)
            {
                ChangeWeapon(WeaponType.Bow);
            }
            
            if (_input.IsSecondWeapon)
            {
                ChangeWeapon(WeaponType.Shuriken);
            }
            
            if (_input.IsThirdWeapon)
            {
                ChangeWeapon(WeaponType.Forcestaff);
            }
        }

        private void ChangeWeapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Bow:
                    _bow.SpawnedModel.SetActive(true);
                    EquipWeapon(_bow);
                    break;
                case WeaponType.Forcestaff:
                    _forcestaff.SpawnedModel.SetActive(true);
                    EquipWeapon(_forcestaff);
                    break;
                case WeaponType.Shuriken:
                    _shuriken.SpawnedModel.SetActive(true);
                    EquipWeapon(_shuriken);
                    break;
            }
        }
        
        private IEnumerator AttackAnimation()
        {
            Vector3 originalPosition = transform.position;
            Vector3 attackPosition = transform.position + new Vector3(0, 0.2f, 0);
        
            float animationTime = 0.1f;
            float elapsedTime = 0f;

            while (elapsedTime < animationTime)
            {
                transform.position = Vector3.Lerp(originalPosition, attackPosition, (elapsedTime / animationTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = originalPosition;
        }

        private void EquipWeapon(Weapon newWeapon)
        {
            _currentWeapon?.SpawnedModel.SetActive(false);
            _currentWeapon = newWeapon;
            _currentWeapon.SpawnedModel.SetActive(true);
        }

        private void DequipWeapon()
        {
            //_currentWeapon = null;
        }
    }
}
