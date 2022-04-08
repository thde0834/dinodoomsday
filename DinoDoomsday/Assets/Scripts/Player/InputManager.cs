using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance { get; private set; }

        private ActionQueue actionQueue = ActionQueue.getInstance;
        private PlayerControls playerControls;

        // All ActionKeys that the Player has unlocked
        private HashSet<ActionKey> availableStates = new HashSet<ActionKey>();

        // ActionKeys that are accessible to the Player in real time
        private HashSet<ActionKey> activeStates = new HashSet<ActionKey>();

        public void Awake()
        {
            instance = this;

            playerControls = new PlayerControls();
            playerControls.Player.Enable();
        }

        public void Start()
        {
        }

        public void AddKey(ActionKey key)
        {
            if (availableStates.Contains(key))
            {
                return;
            }

            availableStates.Add(key);

            if (activeStates != null && !activeStates.Contains(key))
            {
                EnableKey(key);
            }
        }

        public void RemoveKey(ActionKey key)
        {
            if (!availableStates.Contains(key))
            {
                return;
            }

            availableStates.Remove(key);

            if (activeStates != null && activeStates.Contains(key))
            {
                DisableKey(key);
            }
        }

        public void EnableKey(ActionKey key)
        {
            if (activeStates.Contains(key))
            {
                return;
            }

            activeStates.Add(key);

            switch (key)
            {
                case ActionKey.Move:
                    {
                        playerControls.Player.Movement.performed += delegate (InputAction.CallbackContext context) { SendKey(key, context); };
                        playerControls.Player.Movement.canceled += delegate (InputAction.CallbackContext context) { RemoveKey(key, context); };

                        break;
                    }
                case ActionKey.Attack:
                    {
                        playerControls.Player.Attack.performed += delegate (InputAction.CallbackContext context) { SendKey(key, context); };
                        playerControls.Player.Attack.canceled += delegate (InputAction.CallbackContext context) { RemoveKey(key, context); };

                        break;
                    }
                case ActionKey.Jump:
                    {
                        playerControls.Player.Jump.performed += delegate (InputAction.CallbackContext context) { SendKey(key, context); };
                        playerControls.Player.Jump.canceled += delegate (InputAction.CallbackContext context) { RemoveKey(key, context); };

                        break;
                    }
                case ActionKey.Dash:
                    {
                        playerControls.Player.Dash.performed += delegate (InputAction.CallbackContext context) { SendKey(key, context); };
                        playerControls.Player.Dash.canceled += delegate (InputAction.CallbackContext context) { RemoveKey(key, context); };

                        break;
                    }
                case ActionKey.Crouch:
                    {
                        break;
                    }
                default:
                    break;
            }
        }

        public void DisableKey(ActionKey key)
        {
            if (!activeStates.Contains(key))
            {
                return;
            }

            activeStates.Remove(key);

            switch (key)
            {
                case ActionKey.Move:
                    {
                        playerControls.Player.Movement.performed -= delegate (InputAction.CallbackContext context) { SendKey(key, context); };
                        playerControls.Player.Movement.canceled -= delegate (InputAction.CallbackContext context) { RemoveKey(key, context); };

                        break;
                    }
                case ActionKey.Attack:
                    {
                        playerControls.Player.Attack.performed -= delegate (InputAction.CallbackContext context) { SendKey(key, context); };
                        playerControls.Player.Attack.canceled -= delegate (InputAction.CallbackContext context) { RemoveKey(key, context); };

                        break;
                    }
                case ActionKey.Jump:
                    {
                        playerControls.Player.Jump.performed -= delegate (InputAction.CallbackContext context) { SendKey(key, context); };
                        playerControls.Player.Jump.canceled -= delegate (InputAction.CallbackContext context) { RemoveKey(key, context); };

                        break;
                    }
                case ActionKey.Dash:
                    {
                        playerControls.Player.Dash.performed -= delegate (InputAction.CallbackContext context) { SendKey(key, context); };
                        playerControls.Player.Dash.canceled -= delegate (InputAction.CallbackContext context) { RemoveKey(key, context); };

                        break;
                    }
                default:
                    break;
            }
        }

        private void SendKey(ActionKey key, InputAction.CallbackContext context)
        {
            actionQueue.AddKey(key);
        }

        private void RemoveKey(ActionKey key, InputAction.CallbackContext context)
        {
            actionQueue.RemoveKey(key);
        }
    }
}