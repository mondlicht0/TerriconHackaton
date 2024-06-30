using System.Collections.Generic;
using Project.Targets;
using UnityEngine;
using System;

namespace Project.Systems
{
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField] private List<FlyTarget> _amountOfEnemies;

        public event Action OnCheckpointComplete;
        public event Action OnCheckpointReached;

        private void Awake()
        {
            foreach (FlyTarget baseTarget in _amountOfEnemies)
            {
                //baseTarget.OnTargetHit += CheckIsClear;
                baseTarget.OnDead += CheckIsClear;
            }
        }

        private void ActivateEnemies()
        {
            foreach (FlyTarget baseTarget in _amountOfEnemies)
            {
                baseTarget.gameObject.SetActive(true);
            }
        }

        private void CheckIsClear()
        {
            Debug.Log(FindObjectsOfType<FlyTarget>(false).Length);
            if (FindObjectsOfType<FlyTarget>(false).Length == 0)
            {
                Debug.Log("True");
                CompleteCheckPoint();
            }
        }
        
        private void CompleteCheckPoint()
        {
            OnCheckpointComplete?.Invoke();
        }

        public void CheckpointReached()
        {
            ActivateEnemies();
            OnCheckpointReached?.Invoke();
        }
    }
}