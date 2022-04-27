using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Player
{
    public class StateManager : MonoBehaviour
    {
        public static StateManager instance { get; private set; }
        
        [SerializeField] private StateMachine stateMachine;
        [SerializeField] private LayerMask platformLayer;

        public StateKey currentStateKey { get; private set; }

        private readonly string PLATFORM_LAYER_NAME = "Platform";

        public void Awake()
        {
            instance = this;
            platformLayer = (LayerMask)LayerMask.GetMask(PLATFORM_LAYER_NAME);

            // StateMachine's default state is Aerial
            // Changes to Grounded immediately if the Player is grounded initially
            currentStateKey = StateKey.Aerial;
        }

        public void Start()
        {
            stateMachine = StateMachine.instance;
        }

        // Called when Player touches ground
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var isGrounded = collider != null && (((1 << collider.gameObject.layer) & platformLayer) != 0);
            if (isGrounded && StateKey.Grounded != currentStateKey)
            {
                currentStateKey = StateKey.Grounded;
                stateMachine.onStateChanged?.Invoke(currentStateKey);
            }
        }

        // Called when Player leaves ground (e.g. when Player jumps)
        private void OnTriggerExit2D(Collider2D collider)
        {
            if (StateKey.Grounded == currentStateKey)
            {
                currentStateKey = StateKey.Aerial;
                stateMachine.onStateChanged?.Invoke(currentStateKey);
            }
        }


    }
}
