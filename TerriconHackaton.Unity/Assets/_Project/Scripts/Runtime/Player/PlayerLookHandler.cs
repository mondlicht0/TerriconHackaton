using System;
using UnityEngine;

namespace Project.Player
{
    public class PlayerLookHandler : MonoBehaviour
    {
        [SerializeField] private Transform _weaponHolder;
        private PlayerCamera _playerCamera;

        /*[Inject]
        private void Construct(PlayerCamera playerCamera)
        {
            _playerCamera = playerCamera;
        }*/

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

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
            Vector3 playerAngles = transform.eulerAngles;
            float yRotation = _playerCamera.Camera.transform.eulerAngles.y;
            
            // Model rotation
            transform.eulerAngles = new Vector3(playerAngles.x, yRotation, playerAngles.z);
        }

        private void LateUpdate()
        {
            _weaponHolder.eulerAngles = _playerCamera.Camera.transform.eulerAngles;
        }
    }
}
