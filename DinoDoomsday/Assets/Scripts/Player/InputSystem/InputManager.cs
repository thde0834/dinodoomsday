using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance { get; private set; }

        private ActionQueue actionQueue;
        private PlayerControls playerControls;

        // All ActionKeys that the Player has unlocked
        private HashSet<ActionKey> availableActions = new HashSet<ActionKey>();

        // ActionKeys that are accessible to the Player in real time
        private HashSet<ActionKey> activeActions = new HashSet<ActionKey>();

        public void Awake()
        {
            instance = this;

            playerControls = new PlayerControls();
            playerControls.Player.Enable();
        }

        public void Start()
        {
            actionQueue = ActionQueue.getInstance;
        }

        public void AddKey(ActionKey key)
        {
            if (availableActions.Contains(key))
            {
                return;
            }

            availableActions.Add(key);

            if (activeActions != null && !activeActions.Contains(key))
            {
                EnableKey(key);
            }
        }

        public void RemoveKey(ActionKey key)
        {
            if (!availableActions.Contains(key))
            {
                return;
            }

            availableActions.Remove(key);

            if (activeActions != null && activeActions.Contains(key))
            {
                DisableKey(key);
            }
        }

        public void EnableKey(ActionKey key)
        {
            if (activeActions.Contains(key))
            {
                return;
            }

            activeActions.Add(key);

            switch (key)
            {
                case ActionKey.Move:
                    {
                        playerControls.Player.Move.performed += delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Move.canceled += delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                case ActionKey.Attack:
                    {
                        playerControls.Player.Attack.performed += delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Attack.canceled += delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                case ActionKey.Jump:
                    {
                        playerControls.Player.Jump.performed += delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Jump.canceled += delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                case ActionKey.Dash:
                    {
                        playerControls.Player.Dash.performed += delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Dash.canceled += delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                case ActionKey.Crouch:
                    {
                        playerControls.Player.Crouch.performed += delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Crouch.canceled += delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                default:
                    break;
            }
        }

        public void DisableKey(ActionKey key)
        {
            if (!activeActions.Contains(key))
            {
                return;
            }

            activeActions.Remove(key);

            switch (key)
            {
                case ActionKey.Move:
                    {
                        playerControls.Player.Move.performed -= delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Move.canceled -= delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                case ActionKey.Attack:
                    {
                        playerControls.Player.Attack.performed -= delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Attack.canceled -= delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                case ActionKey.Jump:
                    {
                        playerControls.Player.Jump.performed -= delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Jump.canceled -= delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                case ActionKey.Dash:
                    {
                        playerControls.Player.Dash.performed -= delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Dash.canceled -= delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                case ActionKey.Crouch:
                    {
                        playerControls.Player.Crouch.performed -= delegate (InputAction.CallbackContext context) { Enqueue(key, context); };
                        playerControls.Player.Crouch.canceled -= delegate (InputAction.CallbackContext context) { Dequeue(key, context); };

                        break;
                    }
                default:
                    break;
            }
        }

        private void Enqueue(ActionKey key, InputAction.CallbackContext context)
        {
            actionQueue.Enqueue(key);
        }

        private void Dequeue(ActionKey key, InputAction.CallbackContext context)
        {
            actionQueue.Dequeue(key);
        }
    }
}