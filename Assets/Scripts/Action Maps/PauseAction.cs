// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Action Maps/PauseAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PauseAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PauseAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PauseAction"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""d25ba4d4-93c0-4bc0-9f28-b4e8c897ed6f"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""cb1e3476-eb73-469e-a845-f1cecad7a759"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""81ce6ee5-ea98-49ab-868f-6f96d1d906e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cheat"",
                    ""type"": ""Button"",
                    ""id"": ""5ed87aba-a713-488c-bfd8-a4ce8c1563b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc8a458c-69c8-4e2f-a97a-4f0e392ddd79"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f213da3-1710-4a5f-af42-912b0cba016c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d672273-ebd2-410b-b432-ea37fb1e2327"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cheat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
        m_UI_Quit = m_UI.FindAction("Quit", throwIfNotFound: true);
        m_UI_Cheat = m_UI.FindAction("Cheat", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Pause;
    private readonly InputAction m_UI_Quit;
    private readonly InputAction m_UI_Cheat;
    public struct UIActions
    {
        private @PauseAction m_Wrapper;
        public UIActions(@PauseAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputAction @Quit => m_Wrapper.m_UI_Quit;
        public InputAction @Cheat => m_Wrapper.m_UI_Cheat;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Quit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnQuit;
                @Cheat.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCheat;
                @Cheat.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCheat;
                @Cheat.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCheat;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Cheat.started += instance.OnCheat;
                @Cheat.performed += instance.OnCheat;
                @Cheat.canceled += instance.OnCheat;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnCheat(InputAction.CallbackContext context);
    }
}
