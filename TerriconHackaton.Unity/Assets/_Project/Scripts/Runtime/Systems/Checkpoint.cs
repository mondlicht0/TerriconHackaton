using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Project.Weapons;

namespace Project.Systems
{
    public class Checkpoint : MonoBehaviour
    {
        [field: SerializeField] public WeaponType WeaponType { get; private set; }
        [SerializeField] private List<Wave> _waves;
        private Wave _currentWave;
        private int _currentWaveIndex;
        public event Action OnCheckpointComplete;
        public event Action OnCheckpointReached;

        private void Awake()
        {
            foreach (var waveEnemy in _waves.SelectMany(wave => wave.Enemies))
            {
                waveEnemy.OnDead += CheckIsClear;
            }

            _currentWave = _waves[0];
        }

        private void ActivateEnemies()
        {
            foreach (FlyTarget baseTarget in _currentWave.Enemies)
            {
                baseTarget.gameObject.SetActive(true);
            }
        }

        private void CheckIsClear()
        {
            if (FindObjectsOfType<FlyTarget>(false).Length == 0)
            {
                CompleteWave();
            }
        }

        private void CompleteWave()
        {
            _currentWaveIndex++;
            if (_currentWave == _waves.Last())
            {
                CompleteCheckPoint();
            }

            else
            {
                _currentWave = _waves[_currentWaveIndex];
                _currentWave.StartWave();
            }
        }
        
        private void CompleteCheckPoint()
        {
            OnCheckpointComplete?.Invoke();
        }

        public void CheckpointReached()
        {
            OnCheckpointReached?.Invoke();
            _currentWave.StartWave();
        }
    }

    [System.Serializable]
    public class Wave
    {
        [field: SerializeField] public List<FlyTarget> Enemies { get; private set; }
        public bool IsCompleted { get; private set; }
        public event Action OnWaveComplete;

        public void StartWave()
        {
            ActivateEnemies();
        }
        
        public void ActivateEnemies()
        {
            foreach (FlyTarget baseTarget in Enemies)
            {
                baseTarget.gameObject.SetActive(true);
            }
        }

        public void WaveComplete()
        {
            OnWaveComplete?.Invoke();
        }
    }
}