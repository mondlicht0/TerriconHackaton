using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Targets
{
    public class BaseTarget : MonoBehaviour
    {
        [Header("Movement Type")] 
        [SerializeField] private MovementType _movementType;

        [Header("General")]
        [SerializeField] private float _speed = 2.0f;

        [Header("Horizontal Movement")] 
        [SerializeField] private Transform _leftBound;
        [SerializeField] private Transform _rightBound;
        
        [Header("Random Movement")]
        [SerializeField] private float _changeDirectionTime = 2.0f;
        
        [Header("Teleport Movement")]
        [SerializeField] private Transform _minBounds;
        [SerializeField] private Transform _maxBounds;
        [SerializeField] private float _teleportInterval = 2.0f;
    
        private float _timer;
        private Vector2 _direction;
    
        private bool _movingRight = true;

        private void Start()
        {
            _timer = _changeDirectionTime;
            StartTeleport();
        }

        private void Update()
        {
            //RandomMovement();
        }

        private void HorizontalMovement()
        {
            if (_movingRight)
            {
                transform.Translate(Vector2.right * _speed * Time.deltaTime);
                if (transform.position.x >= _rightBound.position.x)
                {
                    _movingRight = false;
                }
            }
            else
            {
                transform.Translate(Vector2.left * _speed * Time.deltaTime);
                if (transform.position.x <= _leftBound.position.x)
                {
                    _movingRight = true;
                }
            }
        }

        private void RandomMovement()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                ChangeDirection();
                _timer = _changeDirectionTime;
            }

            if (transform.position.x > _rightBound.position.x || transform.position.x < _leftBound.position.x)
            {
                ChangeDirection();
            }

            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        private void StartTeleport()
        {
            InvokeRepeating("Teleport", _teleportInterval, _teleportInterval);
        }

        private void Teleport()
        {
            float randomX = Random.Range(_minBounds.position.x, _maxBounds.position.x);
            float randomY = Random.Range(_minBounds.position.y, _maxBounds.position.y);

            transform.position = new Vector3(randomX, randomY);
        }

        private void ChangeDirection()
        {
            float randomValue = Random.Range(0f, 1f);
            if (randomValue > 0.5f)
            {
                _direction = Vector2.right;
            }
            else
            {
                _direction = Vector2.left;
            }
        }
    }
}
