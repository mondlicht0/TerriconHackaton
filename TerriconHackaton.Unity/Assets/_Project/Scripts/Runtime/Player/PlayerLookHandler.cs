using System;
using UnityEngine;
using Zenject;

namespace Project.Player
{
    public class PlayerLookHandler : MonoBehaviour
    {
        private PlayerCamera _playerCamera;

        /*[Inject]
        private void Construct(PlayerCamera playerCamera)
        {
            _playerCamera = playerCamera;
        }*/

        private void Start()
        {
            _playerCamera = FindFirstObjectByType<PlayerCamera>();
        }

        private void Update()
        {
            HandleRotationByAim();
        }

        private void HandleRotationByAim()
        {
            Vector3 playerEulerAngles = transform.eulerAngles;
            float yRotation = _playerCamera.Camera.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(playerEulerAngles.x, yRotation, playerEulerAngles.z);
        }
    }
}
