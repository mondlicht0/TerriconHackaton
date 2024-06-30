//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Project/Scripts/Runtime/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Project.Controls
{
    public partial class @Controls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""628e1499-d07a-4f76-9222-3b7f45aa55c3"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""31094660-0b68-48d8-a978-768f2670fc2b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""QuickAttack"",
                    ""type"": ""Button"",
                    ""id"": ""dbb5661d-140e-4a11-b470-e7810dc2409d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ChargedAttack"",
                    ""type"": ""Button"",
                    ""id"": ""94356bae-5476-4c36-8f38-46a2d3bc1891"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold,Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""5d768667-afb3-4a8b-acce-7b8d7a235ba1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FirstWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""b8b37854-c30f-462a-bfa0-952c6d885052"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""da90823d-2e66-4e71-a7a0-6a6f2ff78794"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThirdWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""ee360bf6-be9d-4b3b-8568-553de37ff950"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""725f7749-fdec-48e6-bbf3-86ffe8c661ea"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""665cbc12-ce23-4dd9-b01b-ef5b032fa73d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b0e9fcc-2133-4d4b-9782-70a344eea0f3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargedAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19033bc5-3310-4b6c-91dc-0b2ec3f2d084"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c071620-3ea0-4c1f-b7bc-682313325af1"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55eda5d8-f604-4e11-b9f4-0fbb25df77e0"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2247d1bb-531a-46dc-8caf-a656c5b84869"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThirdWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerMap
            m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
            m_PlayerMap_Look = m_PlayerMap.FindAction("Look", throwIfNotFound: true);
            m_PlayerMap_QuickAttack = m_PlayerMap.FindAction("QuickAttack", throwIfNotFound: true);
            m_PlayerMap_ChargedAttack = m_PlayerMap.FindAction("ChargedAttack", throwIfNotFound: true);
            m_PlayerMap_Aim = m_PlayerMap.FindAction("Aim", throwIfNotFound: true);
            m_PlayerMap_FirstWeapon = m_PlayerMap.FindAction("FirstWeapon", throwIfNotFound: true);
            m_PlayerMap_SecondWeapon = m_PlayerMap.FindAction("SecondWeapon", throwIfNotFound: true);
            m_PlayerMap_ThirdWeapon = m_PlayerMap.FindAction("ThirdWeapon", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // PlayerMap
        private readonly InputActionMap m_PlayerMap;
        private List<IPlayerMapActions> m_PlayerMapActionsCallbackInterfaces = new List<IPlayerMapActions>();
        private readonly InputAction m_PlayerMap_Look;
        private readonly InputAction m_PlayerMap_QuickAttack;
        private readonly InputAction m_PlayerMap_ChargedAttack;
        private readonly InputAction m_PlayerMap_Aim;
        private readonly InputAction m_PlayerMap_FirstWeapon;
        private readonly InputAction m_PlayerMap_SecondWeapon;
        private readonly InputAction m_PlayerMap_ThirdWeapon;
        public struct PlayerMapActions
        {
            private @Controls m_Wrapper;
            public PlayerMapActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Look => m_Wrapper.m_PlayerMap_Look;
            public InputAction @QuickAttack => m_Wrapper.m_PlayerMap_QuickAttack;
            public InputAction @ChargedAttack => m_Wrapper.m_PlayerMap_ChargedAttack;
            public InputAction @Aim => m_Wrapper.m_PlayerMap_Aim;
            public InputAction @FirstWeapon => m_Wrapper.m_PlayerMap_FirstWeapon;
            public InputAction @SecondWeapon => m_Wrapper.m_PlayerMap_SecondWeapon;
            public InputAction @ThirdWeapon => m_Wrapper.m_PlayerMap_ThirdWeapon;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerMapActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Add(instance);
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @QuickAttack.started += instance.OnQuickAttack;
                @QuickAttack.performed += instance.OnQuickAttack;
                @QuickAttack.canceled += instance.OnQuickAttack;
                @ChargedAttack.started += instance.OnChargedAttack;
                @ChargedAttack.performed += instance.OnChargedAttack;
                @ChargedAttack.canceled += instance.OnChargedAttack;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @FirstWeapon.started += instance.OnFirstWeapon;
                @FirstWeapon.performed += instance.OnFirstWeapon;
                @FirstWeapon.canceled += instance.OnFirstWeapon;
                @SecondWeapon.started += instance.OnSecondWeapon;
                @SecondWeapon.performed += instance.OnSecondWeapon;
                @SecondWeapon.canceled += instance.OnSecondWeapon;
                @ThirdWeapon.started += instance.OnThirdWeapon;
                @ThirdWeapon.performed += instance.OnThirdWeapon;
                @ThirdWeapon.canceled += instance.OnThirdWeapon;
            }

            private void UnregisterCallbacks(IPlayerMapActions instance)
            {
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
                @QuickAttack.started -= instance.OnQuickAttack;
                @QuickAttack.performed -= instance.OnQuickAttack;
                @QuickAttack.canceled -= instance.OnQuickAttack;
                @ChargedAttack.started -= instance.OnChargedAttack;
                @ChargedAttack.performed -= instance.OnChargedAttack;
                @ChargedAttack.canceled -= instance.OnChargedAttack;
                @Aim.started -= instance.OnAim;
                @Aim.performed -= instance.OnAim;
                @Aim.canceled -= instance.OnAim;
                @FirstWeapon.started -= instance.OnFirstWeapon;
                @FirstWeapon.performed -= instance.OnFirstWeapon;
                @FirstWeapon.canceled -= instance.OnFirstWeapon;
                @SecondWeapon.started -= instance.OnSecondWeapon;
                @SecondWeapon.performed -= instance.OnSecondWeapon;
                @SecondWeapon.canceled -= instance.OnSecondWeapon;
                @ThirdWeapon.started -= instance.OnThirdWeapon;
                @ThirdWeapon.performed -= instance.OnThirdWeapon;
                @ThirdWeapon.canceled -= instance.OnThirdWeapon;
            }

            public void RemoveCallbacks(IPlayerMapActions instance)
            {
                if (m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerMapActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerMapActions @PlayerMap => new PlayerMapActions(this);
        public interface IPlayerMapActions
        {
            void OnLook(InputAction.CallbackContext context);
            void OnQuickAttack(InputAction.CallbackContext context);
            void OnChargedAttack(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
            void OnFirstWeapon(InputAction.CallbackContext context);
            void OnSecondWeapon(InputAction.CallbackContext context);
            void OnThirdWeapon(InputAction.CallbackContext context);
        }
    }
}
