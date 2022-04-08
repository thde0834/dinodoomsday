using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private StateFactory stateFactory;

        public void Awake()
        {

        }

        public void Start()
        {
            InitializeStates();
        }

        private void InitializeStates()
        {
            

        }

        #region To Move

        // Player stats (MOVE TO ScriptableObject LATER)
        public float walkingSpeed = 1;
        public float runningSpeed = 2;

        public float jumpingPower = 5;

        public int facingDirection = 1;

        #endregion
    }
}
