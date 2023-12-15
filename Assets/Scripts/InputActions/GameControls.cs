//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputActions/GameControls.inputactions
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

namespace Assets.Scripts.InputActions
{
    public partial class @GameControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""5096ef9e-062d-4c22-872a-177a673e8699"",
            ""actions"": [
                {
                    ""name"": ""MoveW"",
                    ""type"": ""Button"",
                    ""id"": ""819b258a-f7f6-4eba-bc80-3b033037979f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveA"",
                    ""type"": ""Button"",
                    ""id"": ""400b7bed-b317-4339-96d5-9bde21b56a14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveS"",
                    ""type"": ""Button"",
                    ""id"": ""4b888e93-64b3-4efd-b865-5da078b01986"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveD"",
                    ""type"": ""Button"",
                    ""id"": ""4d4a03a6-bef3-47e9-8c1b-3a880735f90b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Apply"",
                    ""type"": ""Button"",
                    ""id"": ""9cb2269d-0521-4ed4-825c-febcfe3475a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0fe9474c-926d-4c3e-9a9d-e8091c34a0fb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b921b21-f24e-4a87-b6fd-5d347da47f42"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5649310d-e8fe-42aa-86c8-34637aaffa4f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""054828a6-8844-40f8-a89e-53e6b310524f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b662317d-5438-4bde-b54e-792da9789a76"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apply"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_MoveW = m_Player.FindAction("MoveW", throwIfNotFound: true);
            m_Player_MoveA = m_Player.FindAction("MoveA", throwIfNotFound: true);
            m_Player_MoveS = m_Player.FindAction("MoveS", throwIfNotFound: true);
            m_Player_MoveD = m_Player.FindAction("MoveD", throwIfNotFound: true);
            m_Player_Apply = m_Player.FindAction("Apply", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_MoveW;
        private readonly InputAction m_Player_MoveA;
        private readonly InputAction m_Player_MoveS;
        private readonly InputAction m_Player_MoveD;
        private readonly InputAction m_Player_Apply;
        public struct PlayerActions
        {
            private @GameControls m_Wrapper;
            public PlayerActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveW => m_Wrapper.m_Player_MoveW;
            public InputAction @MoveA => m_Wrapper.m_Player_MoveA;
            public InputAction @MoveS => m_Wrapper.m_Player_MoveS;
            public InputAction @MoveD => m_Wrapper.m_Player_MoveD;
            public InputAction @Apply => m_Wrapper.m_Player_Apply;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @MoveW.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveW;
                    @MoveW.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveW;
                    @MoveW.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveW;
                    @MoveA.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveA;
                    @MoveA.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveA;
                    @MoveA.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveA;
                    @MoveS.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveS;
                    @MoveS.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveS;
                    @MoveS.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveS;
                    @MoveD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveD;
                    @MoveD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveD;
                    @MoveD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveD;
                    @Apply.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnApply;
                    @Apply.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnApply;
                    @Apply.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnApply;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveW.started += instance.OnMoveW;
                    @MoveW.performed += instance.OnMoveW;
                    @MoveW.canceled += instance.OnMoveW;
                    @MoveA.started += instance.OnMoveA;
                    @MoveA.performed += instance.OnMoveA;
                    @MoveA.canceled += instance.OnMoveA;
                    @MoveS.started += instance.OnMoveS;
                    @MoveS.performed += instance.OnMoveS;
                    @MoveS.canceled += instance.OnMoveS;
                    @MoveD.started += instance.OnMoveD;
                    @MoveD.performed += instance.OnMoveD;
                    @MoveD.canceled += instance.OnMoveD;
                    @Apply.started += instance.OnApply;
                    @Apply.performed += instance.OnApply;
                    @Apply.canceled += instance.OnApply;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnMoveW(InputAction.CallbackContext context);
            void OnMoveA(InputAction.CallbackContext context);
            void OnMoveS(InputAction.CallbackContext context);
            void OnMoveD(InputAction.CallbackContext context);
            void OnApply(InputAction.CallbackContext context);
        }
    }
}
