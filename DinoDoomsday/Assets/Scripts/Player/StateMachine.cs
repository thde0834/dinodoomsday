using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField]
        private Player player;
        
        public static StateMachine instance { get; private set; }

        public State CurrentState { get; private set; }
        public Dictionary<StateKey, State> availableStates { get; private set; }
        public List<ActionKey> activeActions;

        public void Awake()
        {
            instance = this;
            activeActions = new List<ActionKey>();
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

    }
}