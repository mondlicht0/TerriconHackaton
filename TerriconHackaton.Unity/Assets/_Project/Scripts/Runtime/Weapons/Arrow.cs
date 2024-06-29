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

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1f);
            Quaternion rotation = transform.rotation;
            transform.parent = null;
            transform.rotation = rotation;
        }

        private void Update()
        {
            transform.rotation = _initialRotation;
        }

        private void OnCollisionEnter(Collision other)
        {
            _rigidbody.isKinematic = true;
            _collider.enabled = false;
        
            transform.SetParent(other.transform);
        }
    }
}