// GENERATED AUTOMATICALLY FROM 'Assets/Game/inputManager/input_manager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input_manager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input_manager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""input_manager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""bca64184-9999-49e3-beb4-ef17eb665c9f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""660b42b6-c8e7-4179-9e62-5843e278654f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""move_wasd"",
                    ""id"": ""e440da16-d861-4f58-98d4-c39c3c061098"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c19a8d6e-bb84-4ddb-82b4-4e2327d69b54"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8669b4b7-ca26-4210-a0ec-64d7df724964"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fdca7851-b042-48cb-a369-c57a9390b594"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""74d4ac23-2371-45d0-9c8e-66cada86d2de"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""move_arrows"",
                    ""id"": ""227cfed3-b225-4bd4-a8ed-7c32c10a2b07"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a5c0b2a1-9c36-4092-a7a7-5c439d1bf0bc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""scheme_keyboard_and_mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f4796f58-d053-4e01-99ed-d562dfeaf3ac"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""scheme_keyboard_and_mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a5822b2a-054e-4b32-a416-64f329e1e79a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""scheme_keyboard_and_mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""15655946-3412-445a-9305-0c0a8ae0d758"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""scheme_keyboard_and_mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""btns"",
            ""id"": ""5e8570a5-d8e4-41f2-b890-7bedfa889e1a"",
            ""actions"": [
                {
                    ""name"": ""click"",
                    ""type"": ""Button"",
                    ""id"": ""940764a1-9f8b-413b-a52e-4bd528392b71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0d084282-4c48-4312-b922-0240a141598b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""scheme_keyboard_and_mouse"",
                    ""action"": ""click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""active_with_obj"",
            ""id"": ""732663c1-7059-4076-9a80-73db8f3dd494"",
            ""actions"": [
                {
                    ""name"": ""activity"",
                    ""type"": ""Button"",
                    ""id"": ""e0d803b2-430b-4db2-a08a-e8647a5d1702"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""pass_trash"",
                    ""type"": ""Button"",
                    ""id"": ""47df2321-119d-4205-8cc7-ea563c940549"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6867364b-8d8d-46a1-a2a3-a9713d3ec0db"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""scheme_keyboard_and_mouse"",
                    ""action"": ""activity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""120de431-89d1-4d08-90e0-314816c02859"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""scheme_keyboard_and_mouse"",
                    ""action"": ""pass_trash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""scheme_keyboard_and_mouse"",
            ""bindingGroup"": ""scheme_keyboard_and_mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        // btns
        m_btns = asset.FindActionMap("btns", throwIfNotFound: true);
        m_btns_click = m_btns.FindAction("click", throwIfNotFound: true);
        // active_with_obj
        m_active_with_obj = asset.FindActionMap("active_with_obj", throwIfNotFound: true);
        m_active_with_obj_activity = m_active_with_obj.FindAction("activity", throwIfNotFound: true);
        m_active_with_obj_pass_trash = m_active_with_obj.FindAction("pass_trash", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    public struct PlayerActions
    {
        private @Input_manager m_Wrapper;
        public PlayerActions(@Input_manager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // btns
    private readonly InputActionMap m_btns;
    private IBtnsActions m_BtnsActionsCallbackInterface;
    private readonly InputAction m_btns_click;
    public struct BtnsActions
    {
        private @Input_manager m_Wrapper;
        public BtnsActions(@Input_manager wrapper) { m_Wrapper = wrapper; }
        public InputAction @click => m_Wrapper.m_btns_click;
        public InputActionMap Get() { return m_Wrapper.m_btns; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BtnsActions set) { return set.Get(); }
        public void SetCallbacks(IBtnsActions instance)
        {
            if (m_Wrapper.m_BtnsActionsCallbackInterface != null)
            {
                @click.started -= m_Wrapper.m_BtnsActionsCallbackInterface.OnClick;
                @click.performed -= m_Wrapper.m_BtnsActionsCallbackInterface.OnClick;
                @click.canceled -= m_Wrapper.m_BtnsActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_BtnsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @click.started += instance.OnClick;
                @click.performed += instance.OnClick;
                @click.canceled += instance.OnClick;
            }
        }
    }
    public BtnsActions @btns => new BtnsActions(this);

    // active_with_obj
    private readonly InputActionMap m_active_with_obj;
    private IActive_with_objActions m_Active_with_objActionsCallbackInterface;
    private readonly InputAction m_active_with_obj_activity;
    private readonly InputAction m_active_with_obj_pass_trash;
    public struct Active_with_objActions
    {
        private @Input_manager m_Wrapper;
        public Active_with_objActions(@Input_manager wrapper) { m_Wrapper = wrapper; }
        public InputAction @activity => m_Wrapper.m_active_with_obj_activity;
        public InputAction @pass_trash => m_Wrapper.m_active_with_obj_pass_trash;
        public InputActionMap Get() { return m_Wrapper.m_active_with_obj; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Active_with_objActions set) { return set.Get(); }
        public void SetCallbacks(IActive_with_objActions instance)
        {
            if (m_Wrapper.m_Active_with_objActionsCallbackInterface != null)
            {
                @activity.started -= m_Wrapper.m_Active_with_objActionsCallbackInterface.OnActivity;
                @activity.performed -= m_Wrapper.m_Active_with_objActionsCallbackInterface.OnActivity;
                @activity.canceled -= m_Wrapper.m_Active_with_objActionsCallbackInterface.OnActivity;
                @pass_trash.started -= m_Wrapper.m_Active_with_objActionsCallbackInterface.OnPass_trash;
                @pass_trash.performed -= m_Wrapper.m_Active_with_objActionsCallbackInterface.OnPass_trash;
                @pass_trash.canceled -= m_Wrapper.m_Active_with_objActionsCallbackInterface.OnPass_trash;
            }
            m_Wrapper.m_Active_with_objActionsCallbackInterface = instance;
            if (instance != null)
            {
                @activity.started += instance.OnActivity;
                @activity.performed += instance.OnActivity;
                @activity.canceled += instance.OnActivity;
                @pass_trash.started += instance.OnPass_trash;
                @pass_trash.performed += instance.OnPass_trash;
                @pass_trash.canceled += instance.OnPass_trash;
            }
        }
    }
    public Active_with_objActions @active_with_obj => new Active_with_objActions(this);
    private int m_scheme_keyboard_and_mouseSchemeIndex = -1;
    public InputControlScheme scheme_keyboard_and_mouseScheme
    {
        get
        {
            if (m_scheme_keyboard_and_mouseSchemeIndex == -1) m_scheme_keyboard_and_mouseSchemeIndex = asset.FindControlSchemeIndex("scheme_keyboard_and_mouse");
            return asset.controlSchemes[m_scheme_keyboard_and_mouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IBtnsActions
    {
        void OnClick(InputAction.CallbackContext context);
    }
    public interface IActive_with_objActions
    {
        void OnActivity(InputAction.CallbackContext context);
        void OnPass_trash(InputAction.CallbackContext context);
    }
}
