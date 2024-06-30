using System.Collections.Generic;
using UnityEngine;
using System;
using Project.Weapons;

namespace Project.Systems
{
    public class Checkpoint : MonoBehaviour
    {
        [field: SerializeField] public WeaponType WeaponType { get; private set; }
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
            if (FindObjectsOfType<FlyTarget>(false).Length == 0)
            {
                Debug.Log("Check");
                CompleteCheckPoint();
            }
        }
        
        private void CompleteCheckPoint()
        {
            OnCheckpointComplete?.Invoke();
        }

        public void CheckpointReached()
        {
            OnCheckpointReached?.Invoke();
            ActivateEnemies();
        }
    }
}