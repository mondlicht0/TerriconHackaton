using Project.Systems;
using TMPro;
using UnityEngine;
using Zenject;

namespace Project.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        [SerializeField] private Canvas _gameOverCanvas;

        private GameManager _gameManager;
        private Timer _timer;

        [Inject]
        private void Construct(Timer timer, GameManager gameManager)
        {
            _gameManager = gameManager;
            _timer = timer;
        }

        private void OnEnable()
        {
            _timer.OnTimerTick += UpdateTimerText;
            _gameManager.OnScoreUpdate += UpdateScoreText;
            _gameManager.OnGameOver += ShowGameOver;
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