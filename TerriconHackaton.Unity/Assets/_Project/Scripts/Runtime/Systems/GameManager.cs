using System;
using Project.Targets;
using Project.UI;
using UnityEngine;

namespace Project.Systems
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private Timer _timer;
        
        private BaseTarget _baseTarget;
        private FlyTarget[] _flies;
        public int Score { get; private set; }
        public event Action OnScoreUpdate;
        public event Action OnGameOver;

        private void Start()
        {
            _baseTarget = FindFirstObjectByType<BaseTarget>();
            _flies = FindObjectsOfType<FlyTarget>(true);

            foreach (FlyTarget fly in _flies)
            {
                fly.OnTargetHit += UpdateScore;
            }
            
            _baseTarget.OnTargetHit += UpdateScore;
            _timer.OnTimerEnded += GameOver;
        }

        private void GameOver()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            OnGameOver?.Invoke();
        }

        private void UpdateScore(int score)
        {
            Score += score;
            OnScoreUpdate?.Invoke();
        }
    }
}