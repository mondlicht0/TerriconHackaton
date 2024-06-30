using System;
using Cinemachine;
using DG.Tweening;
using Project.Player;
using Project.Targets;
using Project.UI;
using UnityEngine;
using Zenject;

namespace Project.Systems
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CinemachineInputProvider _inputProvider;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private Timer _timer;

        private Player.Player _player;
        private PlayerMovement _playerMovement;
        private BaseTarget _baseTarget;
        private FlyTarget[] _flies;
        public int Score { get; private set; }
        public event Action OnScoreUpdate;
        public event Action OnGameOver;
        public event Action OnWin;

        [Inject]
        private void Construct(Player.Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            _playerMovement = _player.GetComponent<PlayerMovement>();
        }

        private void Start()
        {
            DOTween.SetTweensCapacity(500, 50);
            _baseTarget = FindFirstObjectByType<BaseTarget>();
            _flies = FindObjectsOfType<FlyTarget>(true);

            foreach (FlyTarget fly in _flies)
            {
                fly.OnTargetHit += UpdateScore;
                fly.OnPlayerAttacked += GameOver;
            }
            
            _baseTarget.OnTargetHit += UpdateScore;
            _timer.OnTimerEnded += GameOver;
            _playerMovement.OnFinalCheckpoint += Win;
        }

        private void Win()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _inputProvider.enabled = false;
            OnWin?.Invoke();
        }

        private void GameOver()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _inputProvider.enabled = false;
            OnGameOver?.Invoke();
        }

        private void UpdateScore(int score)
        {
            Score += score;
            OnScoreUpdate?.Invoke();
        }
    }
}