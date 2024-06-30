using System;
using System.Collections.Generic;
using DG.Tweening;
using ModestTree;
using Project.Systems;
using UnityEngine;

namespace Project.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _timeToMove;
        [SerializeField] private List<Checkpoint> _checkpoints = new();
        
        private Dictionary<Transform, Checkpoint> _checkpointsDictionary = new();
        private Queue<Transform> _checkpointsQueue = new();
        private Player _player;

        public event Action OnFinalCheckpoint;

        private void Awake()
        {
            foreach (Checkpoint checkpoint in _checkpoints)
            {
                _checkpointsDictionary.Add(checkpoint.transform, _checkpoints[_checkpoints.IndexOf(checkpoint)]);
                _checkpointsQueue.Enqueue(checkpoint.transform);
                checkpoint.OnCheckpointComplete += MoveToNextCheckpoint;
            }
        }

        private void Start()
        {
            MoveToNextCheckpoint();
        }

        private void MoveToNextCheckpoint()
        {
            if (_checkpointsQueue.IsEmpty()) return;
            Transform checkpoint = _checkpointsQueue.Dequeue();

            transform.DOMove(checkpoint.position, _timeToMove);
            _checkpointsDictionary[checkpoint].CheckpointReached();

            if (checkpoint == _checkpointsQueue.Peek())
            {
                OnFinalCheckpoint?.Invoke();
            }
        }
    }
}
