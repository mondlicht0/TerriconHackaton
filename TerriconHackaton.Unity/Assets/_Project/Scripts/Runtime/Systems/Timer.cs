using System;
using System.Collections;
using UnityEngine;

namespace Project.Systems
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private int _time;

        private int _currentTime;
        public event Action OnTimerEnded;
        public event Action<int> OnTimerTick;

        private void Start()
        {
            _currentTime = _time;
            StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            while (_currentTime >= 0)
            {
                yield return new WaitForSeconds(1f);
                _currentTime -= 1;
                OnTimerTick?.Invoke(_currentTime);
            }
            
            OnTimerEnded?.Invoke();
        }
    }
}
