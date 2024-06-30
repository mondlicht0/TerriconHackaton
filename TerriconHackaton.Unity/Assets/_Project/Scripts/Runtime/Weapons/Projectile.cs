using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Weapons
{
    public class Projectile : ThrowableObject
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _bounceRadius = 5f;
        [SerializeField] private int _maxBounces = 2;
        [SerializeField] private int _rotationSpeed = 360;
        [SerializeField] private float _bounceFrequency = 0.5f;
        [SerializeField] private float _bounceHeight = 0.5f;

        private Rigidbody _rigidbody;
        private Vector3 _initialPosition;
        private int _bounces = 1;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _initialPosition = transform.position;
        }        
        
        private void Update()
        {
            transform.DORotate(new Vector3(0, _rotationSpeed, 0), 1f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);

            //transform.DOMoveY(_bounceHeight, _bounceFrequency)
                //.SetLoops(-1, LoopType.Yoyo)
                //.SetEase(Ease.InOutQuad);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagable.GetDamage();
                if (_bounces < _maxBounces)
                {
                    _bounces++;
                    EnemyBounce(other.transform);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }

        private void EnemyBounce(Transform hitEnemy)
        {
            Collider[] enemies = Physics.OverlapSphere(hitEnemy.position, _bounceRadius);

            foreach (Collider enemy in enemies)
            {
                if (enemy.TryGetComponent(out IDamagable damagable) && enemy.transform != hitEnemy)
                {
                    Vector3 direction = (enemy.transform.position - hitEnemy.position).normalized;
                    _rigidbody.velocity = direction * 10;
                    transform.position = hitEnemy.position;
                    transform.rotation = Quaternion.LookRotation(direction);
                    return;
                }
            }

            gameObject.SetActive(false);
        }
    }
}