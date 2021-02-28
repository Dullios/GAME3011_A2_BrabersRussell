// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/MouseControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MouseControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MouseControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MouseControls"",
    ""maps"": [
        {
            ""name"": ""MouseActionMap"",
            ""id"": ""78f54592-9da3-4382-adc4-1a3dde1053f9"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d13640cc-2b76-450a-8230-3e859d2572e6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClickDown"",
                    ""type"": ""Button"",
                    ""id"": ""849ee150-7836-4d51-ba81-0a36ea3f17c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.01)""
                },
                {
                    ""name"": ""ClickRelease"",
                    ""type"": ""Button"",
                    ""id"": ""f30b6d52-fd93-4e61-92de-d642aff2e14e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""c984af4c-05d2-4abe-ba71-ab49722e791b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""19a3d54d-a733-419b-b3b9-809b2b31a077"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce8033dd-2b15-4bf7-837d-17e553d58223"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a763c49-efa8-4f2f-bc97-dc72a60f88f4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d7511c2-ec2c-4f6a-a1f5-7ff232105e8d"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MouseActionMap
        m_MouseActionMap = asset.FindActionMap("MouseActionMap", throwIfNotFound: true);
        m_MouseActionMap_Movement = m_MouseActionMap.FindAction("Movement", throwIfNotFound: true);
        m_MouseActionMap_ClickDown = m_MouseActionMap.FindAction("ClickDown", throwIfNotFound: true);
        m_MouseActionMap_ClickRelease = m_MouseActionMap.FindAction("ClickRelease", throwIfNotFound: true);
        m_MouseActionMap_MousePosition = m_MouseActionMap.FindAction("MousePosition", throwIfNotFound: true);
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

    // MouseActionMap
    private readonly InputActionMap m_MouseActionMap;
    private IMouseActionMapActions m_MouseActionMapActionsCallbackInterface;
    private readonly InputAction m_MouseActionMap_Movement;
    private readonly InputAction m_MouseActionMap_ClickDown;
    private readonly InputAction m_MouseActionMap_ClickRelease;
    private readonly InputAction m_MouseActionMap_MousePosition;
    public struct MouseActionMapActions
    {
        private @MouseControls m_Wrapper;
        public MouseActionMapActions(@MouseControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MouseActionMap_Movement;
        public InputAction @ClickDown => m_Wrapper.m_MouseActionMap_ClickDown;
        public InputAction @ClickRelease => m_Wrapper.m_MouseActionMap_ClickRelease;
        public InputAction @MousePosition => m_Wrapper.m_MouseActionMap_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_MouseActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActionMapActions instance)
        {
            if (m_Wrapper.m_MouseActionMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnMovement;
                @ClickDown.started -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnClickDown;
                @ClickDown.performed -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnClickDown;
                @ClickDown.canceled -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnClickDown;
                @ClickRelease.started -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnClickRelease;
                @ClickRelease.performed -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnClickRelease;
                @ClickRelease.canceled -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnClickRelease;
                @MousePosition.started -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MouseActionMapActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_MouseActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @ClickDown.started += instance.OnClickDown;
                @ClickDown.performed += instance.OnClickDown;
                @ClickDown.canceled += instance.OnClickDown;
                @ClickRelease.started += instance.OnClickRelease;
                @ClickRelease.performed += instance.OnClickRelease;
                @ClickRelease.canceled += instance.OnClickRelease;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public MouseActionMapActions @MouseActionMap => new MouseActionMapActions(this);
    public interface IMouseActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnClickDown(InputAction.CallbackContext context);
        void OnClickRelease(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
