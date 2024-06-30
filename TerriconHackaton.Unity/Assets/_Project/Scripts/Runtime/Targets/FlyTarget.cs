using System;
using DG.Tweening;
using Project.Player;
using UnityEngine;
using Zenject;

public class FlyTarget : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _bobbingHeight = 1f;
    [SerializeField] private float _bobbingDuration = 1f;
    private int _value = 10;
    private Player _player;
    private bool _isDead;
    
    private int _currentHealth;
    
    public event Action<int> OnTargetHit; 
    public event Action OnDead;
    public event Action OnPlayerAttacked;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        Bobbing();
    }

    private void Update()
    {
        MoveToPlayer();
        if (!_isDead)
        {
            transform.LookAt(_player.transform);
        }
    }

    private void MoveToPlayer()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        transform.position += direction * _moveSpeed * Time.deltaTime;

        if (Vector3.Distance(_player.transform.position, transform.position) < 0.35f)
        {
            OnPlayerAttacked?.Invoke();
        }
    }

    private void Bobbing()
    {
        transform.DOMoveY(transform.position.y + _bobbingHeight, _bobbingDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
    
    public void GetDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            OnTargetHit?.Invoke(_value);
            Die();   
        }
    }

    public void Die()
    {
        _isDead = true;
        DOTween.Kill(transform);

        Sequence deathSequence = DOTween.Sequence();
        deathSequence.Append(transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack));
        deathSequence.Join(transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360));
        deathSequence.OnComplete(Dead);
    }

    private void Dead()
    {
        gameObject.SetActive(false);
        OnDead?.Invoke();
    }
}
