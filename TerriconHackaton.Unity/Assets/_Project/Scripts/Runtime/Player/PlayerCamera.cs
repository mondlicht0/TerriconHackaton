using Cinemachine;
using UnityEngine;
using Zenject;

namespace Project.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        private CinemachineVirtualCamera _camera;
        private Player _player;

        public CinemachineVirtualCamera Camera => _camera;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }
        
        private void Awake()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
            _camera.Follow = _player.FollowTarget;
            _camera.LookAt = _player.LookAtTarget;
        }
    }
}