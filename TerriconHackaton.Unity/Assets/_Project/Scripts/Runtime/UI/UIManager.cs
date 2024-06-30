using System;
using Project.Systems;
using TMPro;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace Project.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [Header("Canvases")]
        [SerializeField] private Canvas _gameOverCanvas;
        [SerializeField] private Canvas _winCanvas;
        [Header("Buttons")] 
        [SerializeField] private Button _nextWinButton;
        [SerializeField] private Button _retryOverButton;
        [SerializeField] private Button _menuWinButton;
        [SerializeField] private Button _menuOverButton;

        private LevelManager _levelManager;
        private GameManager _gameManager;
        private Timer _timer;

        [Inject]
        private void Construct(Timer timer, GameManager gameManager, LevelManager levelManager)
        {
            _levelManager = levelManager;
            _gameManager = gameManager;
            _timer = timer;
        }

        private void InitButtons()
        {
            _nextWinButton.onClick.AddListener(_levelManager.NextLevelInvoke);
            _menuWinButton.onClick.AddListener(_levelManager.MenuInvoke);
            _retryOverButton.onClick.AddListener(_levelManager.RetryInvoke);
            _menuOverButton.onClick.AddListener(_levelManager.MenuInvoke);
        }

        private void OnEnable()
        {
            _timer.OnTimerTick += UpdateTimerText;
            _gameManager.OnScoreUpdate += UpdateScoreText;
            _gameManager.OnGameOver += ShowGameOver;
            _gameManager.OnWin += ShowWin;
        }

        private void Start()
        {
            InitButtons();
        }

        private void ShowWin()
        {
            _winCanvas.gameObject.SetActive(true);
        }

        private void ShowGameOver()
        {
            _gameOverCanvas.gameObject.SetActive(true);
        }

        private void UpdateScoreText()
        {
            _scoreText.text = _gameManager.Score.ToString();
        }

        private void UpdateTimerText(int time)
        {
            int minutes = time / 60;
            int seconds = time % 60;
            _timerText.text = $"{minutes:D2}:{seconds:D2}";
        }
    }
}