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

        public List<ActionKey> activeActions;

        public Action<StateKey> onStateChanged;

        public void Awake()
        {
            instance = this;
            activeActions = new List<ActionKey>();
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
            foreach (var key in activeActions)
            {
                CurrentState.performAction(key);
            }
        }

        public void AddState(StateKey stateKey, State state)
        {
            if (availableStates.ContainsKey(stateKey))
            {
                return;
            }
            availableStates.Add(stateKey, state);
        }

        public void ChangeState(StateKey key)
        {
            if (!availableStates.ContainsKey(key))
            {
                throw new Exception("StateMachine does not have StateKey: " + key);
            }

            CurrentState = availableStates[key];
        }

    }
}