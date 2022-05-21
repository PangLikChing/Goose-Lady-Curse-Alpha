//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Game/Scripts/Player/Input/Player Controls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e55c5bde-0eda-4408-8f85-f15cde7656ae"",
            ""actions"": [
                {
                    ""name"": ""Movements"",
                    ""type"": ""Button"",
                    ""id"": ""2206c472-6fc4-423d-985e-6848dff51ed7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""9986a283-af5c-44e7-a9a5-de006a574b6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Button"",
                    ""id"": ""d7ddb60f-c858-405c-9635-3b0741b10bf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""05d0cef4-54fc-40ec-89ba-9df78c03fa7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Open Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""b564266d-f1dd-4eb9-aa3e-4abc4368fe86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Character Panel"",
                    ""type"": ""Button"",
                    ""id"": ""1aa0bdac-a156-45a8-b992-fcd29994ab58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Open Crafting Menu"",
                    ""type"": ""Button"",
                    ""id"": ""59c80afd-55fa-4b41-b5d5-bbdb7bf822c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Open Help Menu"",
                    ""type"": ""Button"",
                    ""id"": ""70271ffd-0414-405c-a82a-152a08a59d90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Open Pause Menu"",
                    ""type"": ""Button"",
                    ""id"": ""e1150ac4-d573-403e-9856-4ae0143182f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Open Build Menu"",
                    ""type"": ""Button"",
                    ""id"": ""cf269481-662d-413a-a232-0588cf567dd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zoom Camera"",
                    ""type"": ""Value"",
                    ""id"": ""cf40c54b-1316-43e3-bb02-45578cfacf11"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""06d3af0a-c7fd-47c3-8e2d-77f33bac0479"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f44f7a1b-0407-4a51-adb2-41bdb7d8e795"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3ab20da-1304-4833-94dc-1f8ff0560231"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""917a5a78-0448-4795-bd28-d99eca3b4523"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Open Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36d0dc5e-af57-4812-ba9b-08d9000b081c"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Character Panel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fa08b66-04b4-44b3-b286-8b695695633f"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Crafting Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5dba4bf-a652-4c60-8333-5b43a6c5abd2"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Help Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cc4f511-ab0b-41c4-a71d-176a63b645e4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Pause Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cec7db8-1531-42ca-ac7e-b46865a3a3a6"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Build Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9327a424-74cf-46ad-b7f9-764daeab6cce"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""439e8165-dd8c-4d18-85de-510a38dd07b1"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Zoom Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movements = m_Player.FindAction("Movements", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Pickup = m_Player.FindAction("Pickup", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_OpenInventory = m_Player.FindAction("Open Inventory", throwIfNotFound: true);
        m_Player_CharacterPanel = m_Player.FindAction("Character Panel", throwIfNotFound: true);
        m_Player_OpenCraftingMenu = m_Player.FindAction("Open Crafting Menu", throwIfNotFound: true);
        m_Player_OpenHelpMenu = m_Player.FindAction("Open Help Menu", throwIfNotFound: true);
        m_Player_OpenPauseMenu = m_Player.FindAction("Open Pause Menu", throwIfNotFound: true);
        m_Player_OpenBuildMenu = m_Player.FindAction("Open Build Menu", throwIfNotFound: true);
        m_Player_ZoomCamera = m_Player.FindAction("Zoom Camera", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Movements;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Pickup;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_OpenInventory;
    private readonly InputAction m_Player_CharacterPanel;
    private readonly InputAction m_Player_OpenCraftingMenu;
    private readonly InputAction m_Player_OpenHelpMenu;
    private readonly InputAction m_Player_OpenPauseMenu;
    private readonly InputAction m_Player_OpenBuildMenu;
    private readonly InputAction m_Player_ZoomCamera;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movements => m_Wrapper.m_Player_Movements;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Pickup => m_Wrapper.m_Player_Pickup;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @OpenInventory => m_Wrapper.m_Player_OpenInventory;
        public InputAction @CharacterPanel => m_Wrapper.m_Player_CharacterPanel;
        public InputAction @OpenCraftingMenu => m_Wrapper.m_Player_OpenCraftingMenu;
        public InputAction @OpenHelpMenu => m_Wrapper.m_Player_OpenHelpMenu;
        public InputAction @OpenPauseMenu => m_Wrapper.m_Player_OpenPauseMenu;
        public InputAction @OpenBuildMenu => m_Wrapper.m_Player_OpenBuildMenu;
        public InputAction @ZoomCamera => m_Wrapper.m_Player_ZoomCamera;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movements.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovements;
                @Movements.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovements;
                @Movements.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovements;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Pickup.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickup;
                @Pickup.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickup;
                @Pickup.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickup;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @OpenInventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @CharacterPanel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCharacterPanel;
                @CharacterPanel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCharacterPanel;
                @CharacterPanel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCharacterPanel;
                @OpenCraftingMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenCraftingMenu;
                @OpenCraftingMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenCraftingMenu;
                @OpenCraftingMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenCraftingMenu;
                @OpenHelpMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenHelpMenu;
                @OpenHelpMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenHelpMenu;
                @OpenHelpMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenHelpMenu;
                @OpenPauseMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenPauseMenu;
                @OpenPauseMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenPauseMenu;
                @OpenPauseMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenPauseMenu;
                @OpenBuildMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenBuildMenu;
                @OpenBuildMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenBuildMenu;
                @OpenBuildMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenBuildMenu;
                @ZoomCamera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomCamera;
                @ZoomCamera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomCamera;
                @ZoomCamera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoomCamera;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movements.started += instance.OnMovements;
                @Movements.performed += instance.OnMovements;
                @Movements.canceled += instance.OnMovements;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
                @CharacterPanel.started += instance.OnCharacterPanel;
                @CharacterPanel.performed += instance.OnCharacterPanel;
                @CharacterPanel.canceled += instance.OnCharacterPanel;
                @OpenCraftingMenu.started += instance.OnOpenCraftingMenu;
                @OpenCraftingMenu.performed += instance.OnOpenCraftingMenu;
                @OpenCraftingMenu.canceled += instance.OnOpenCraftingMenu;
                @OpenHelpMenu.started += instance.OnOpenHelpMenu;
                @OpenHelpMenu.performed += instance.OnOpenHelpMenu;
                @OpenHelpMenu.canceled += instance.OnOpenHelpMenu;
                @OpenPauseMenu.started += instance.OnOpenPauseMenu;
                @OpenPauseMenu.performed += instance.OnOpenPauseMenu;
                @OpenPauseMenu.canceled += instance.OnOpenPauseMenu;
                @OpenBuildMenu.started += instance.OnOpenBuildMenu;
                @OpenBuildMenu.performed += instance.OnOpenBuildMenu;
                @OpenBuildMenu.canceled += instance.OnOpenBuildMenu;
                @ZoomCamera.started += instance.OnZoomCamera;
                @ZoomCamera.performed += instance.OnZoomCamera;
                @ZoomCamera.canceled += instance.OnZoomCamera;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_MouseandKeyboardSchemeIndex = -1;
    public InputControlScheme MouseandKeyboardScheme
    {
        get
        {
            if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
            return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovements(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
        void OnCharacterPanel(InputAction.CallbackContext context);
        void OnOpenCraftingMenu(InputAction.CallbackContext context);
        void OnOpenHelpMenu(InputAction.CallbackContext context);
        void OnOpenPauseMenu(InputAction.CallbackContext context);
        void OnOpenBuildMenu(InputAction.CallbackContext context);
        void OnZoomCamera(InputAction.CallbackContext context);
    }
}
