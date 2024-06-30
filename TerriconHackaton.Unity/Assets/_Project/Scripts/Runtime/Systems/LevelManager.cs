using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using DG.Tweening;

namespace Project.Systems
{
    public class LevelManager : MonoBehaviour
    {
        public event Action OnRetry;
        public event Action OnNextLevel;
        public event Action OnMenu;

        private void OnEnable()
        {
            OnRetry += Retry;
            OnNextLevel += NextLevel;
            OnMenu += Menu;
        }
        
        private void OnDisable()
        {
            OnRetry -= Retry;
            OnNextLevel -= NextLevel;
            OnMenu -= Menu;
        }

        public void RetryInvoke()
        {
            OnRetry?.Invoke();
        }
        
        public void MenuInvoke()
        {
            OnMenu?.Invoke();
        }
        
        public void NextLevelInvoke()
        {
            OnNextLevel?.Invoke();
        }

        private void Retry()
        {
            DOTween.KillAll();
            SceneManager.LoadSceneAsync(1);
        }
        
        private void Menu()
        {
            DOTween.KillAll();
            SceneManager.LoadSceneAsync(0);
        }
        
        private void NextLevel()
        {
            DOTween.KillAll();
            SceneManager.LoadSceneAsync(2);
        }
    }
}