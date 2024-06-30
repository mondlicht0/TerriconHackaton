using Project.Systems;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.UI
{
    public class MenuUIManager : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        private LevelManager _levelManager;

        [Inject]
        private void Construct(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        private void Start()
        {
            InitButtons();
        }

        private void InitButtons()
        {
            _playButton.onClick.AddListener(() => _levelManager.RetryInvoke());
            _exitButton.onClick.AddListener(() => Application.Quit());
        }
    }
}