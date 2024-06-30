using System;
using UnityEngine;

namespace Project.Weapons
{
    public class ThrowableObject : MonoBehaviour
    {
        [SerializeField] protected int Damage = 7;
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagable.GetDamage(Damage);
                _collider.enabled = false;
            }
        }
    }
}