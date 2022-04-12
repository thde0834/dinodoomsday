using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Player
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] private StateMachine stateMachine;
        [SerializeField] private LayerMask platformLayer;

        private StateKey currentStateKey;

        private readonly string PLATFORM_LAYER_NAME = "Platform";

        public void Awake()
        {
            platformLayer = LayerMask.GetMask(PLATFORM_LAYER_NAME);
        }

        public void Start()
        {
            stateMachine = StateMachine.instance;
            currentStateKey = StateKey.Aerial;
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
            var isGrounded = false;
            if (StateKey.Grounded == currentStateKey)
            {
                currentStateKey = StateKey.Aerial;
                stateMachine.onStateChanged?.Invoke(currentStateKey);
            }
        }




    }
}
