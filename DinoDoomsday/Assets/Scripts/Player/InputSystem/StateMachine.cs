using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class StateMachine : MonoBehaviour
    {
        public static StateMachine instance { get; private set; }

        [SerializeField]
        private Player player;

        public State CurrentState { get; private set; }
        public Dictionary<StateKey, State> availableStates { get; private set; }

        private Dictionary<ActionKey, PlayerAction> activeActions;

        public Action<StateKey> onStateChanged;

        public void Awake()
        {
            instance = this;
            activeActions = new Dictionary<ActionKey, PlayerAction>();
        }

        public void Start()
        {
            player = Player.instance;

            availableStates = InitializeStates();
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

        public void OnEnable()
        {
            onStateChanged += ChangeState;
        }

        public void OnDisable()
        {
            onStateChanged -= ChangeState;
        }

        public void FixedUpdate()
        {
            foreach (var playerAction in activeActions.Values)
            {
                playerAction?.Perform();
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

            foreach (var action in activeActions.ToList())
            {
                var playerAction = action.Value;

                // playerAction != null && playerAction.changeOnStateChange == false
                if (playerAction is { changeOnStateChange: false })
                {
                    continue;
                }

                activeActions[action.Key] = CurrentState.GetAction(action.Key);
            }
        }

        // Only called when a button goes from:
        // unpressed --> pressed OR pressed --> unpressed
        public void SetActiveActionKeys(List<ActionKey> list)
        {
            activeActions.Clear();
            foreach (var actionKey in list)
            {
                var playerAction = CurrentState.GetAction(actionKey);
                if (playerAction != null)
                {
                    activeActions.Add(actionKey, playerAction);
                }
                else
                {
                    activeActions.Add(actionKey, null);
                }
            }
        }
    }
}