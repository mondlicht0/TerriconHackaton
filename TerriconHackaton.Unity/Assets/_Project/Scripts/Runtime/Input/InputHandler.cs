using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Controls
{
    public class InputHandler : MonoBehaviour
    {
        private Controls _controls;
        
        public bool FireTriggered { get; private set; }
        public bool SpecialAttackTriggered { get; private set; }
        public Vector2 LookDirection { get; private set; }

        private void Awake()
        {
            _controls = new Controls();
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookDirection = context.ReadValue<Vector2>();
        }

        public void OnAttackPerformed(InputAction.CallbackContext context)
        {
            FireTriggered = context.started;
        }
        
        public void OnSpecialAttackPerformed(InputAction.CallbackContext context)
        {
            SpecialAttackTriggered = context.performed;
        }
    }
}
