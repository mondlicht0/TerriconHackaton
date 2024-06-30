using System;
using System.Collections;
using UnityEngine;

namespace Project.Weapons
{
    public class Arrow : ThrowableObject
    {
        private Rigidbody _rigidbody;
        private Collider _collider;
        private Quaternion _initialRotation;

        private int _enemiesCount = 2;
        private int _currentCount;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.01f);
            Quaternion currentRotation = transform.rotation;
            transform.parent = null;
            transform.rotation = currentRotation;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_currentCount != _enemiesCount) return;
            
            _rigidbody.isKinematic = true;
            _collider.enabled = false;
            transform.SetParent(other.transform);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagable.GetDamage(Damage + 3);
            }
        }
    }
}