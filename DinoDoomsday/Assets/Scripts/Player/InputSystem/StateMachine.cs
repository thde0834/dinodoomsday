using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StateMachine : MonoBehaviour
    {
        public static StateMachine instance { get; private set; }

        [SerializeField]
        private Player player;

        [SerializeField] 
        private ActionQueue actionQueue;
        public State CurrentState { get; private set; }
        public Dictionary<StateKey, State> availableStates { get; private set; }

        private List<ActionKey> activeActionKeys;
        private List<PlayerAction> activePlayerActions;

        public Action<StateKey> onStateChanged;

        public void Awake()
        {
            instance = this;
            activeActionKeys = new List<ActionKey>();
            activePlayerActions = new List<PlayerAction>();
        }

        public void Start()
        {
            player = Player.instance;
            actionQueue = ActionQueue.getInstance;

            availableStates = InitializeStates();
        }

        public void OnEnable()
        {
            onStateChanged += ChangeState;
        }

        public void OnDisable()
        {
            onStateChanged -= ChangeState;
        }

        private Dictionary<StateKey, State> InitializeStates()
        {
            var initialStates = new Dictionary<StateKey, State>()
            {
                {StateKey.Grounded, new Grounded(player)},
                {StateKey.Aerial, new Aerial(player)}
            };

            return initialStates;
        }
        
        public void FixedUpdate()
        {
            foreach (var playerAction in activePlayerActions)
            {
                playerAction.Perform();
            }
        }

        // Called by StateFactory
        public void AddState(StateKey stateKey, State state)
        {
            if (availableStates.ContainsKey(stateKey))
            {
                return;
            }
            availableStates.Add(stateKey, state);
        }

        // Automatically called by StateManager
        public void ChangeState(StateKey key)
        {
            if (!availableStates.ContainsKey(key))
            {
                throw new Exception("StateMachine does not have StateKey: " + key);
            }

            CurrentState = availableStates[key];

            foreach (var playerAction in activePlayerActions)
            {
                if (playerAction.changeOnStateChange == true)
                {
                    activePlayerActions.Remove(playerAction);

                    var newAction = CurrentState.GetAction(playerAction.actionKey);
                    if (newAction != null)
                    {
                        activePlayerActions.Add(newAction);
                    }
                }
            }
        }

        // Only called when a button goes from unpressed --> pressed
        public void SetActiveActionKeys(List<ActionKey> list)
        {
            activeActionKeys = list;

            activePlayerActions.Clear();
            foreach (var actionKey in list)
            {
                var action = CurrentState.GetAction(actionKey);
                if (action != null)
                {
                    activePlayerActions.Add(action);
                }
            }
        }

    }
}