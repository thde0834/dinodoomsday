using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private ActionFactory actionFactory;
        private StateFactory stateFactory;
        private int health;

        public void Awake()
        {
            health = 3;
        }

        public void Start()
        {
            actionFactory = new ActionFactory(this);
            stateFactory = new StateFactory(this);
        }

        //for collision detection info referenced https://www.youtube.com/watch?v=0ZJPmjA5Hv0
        private void OnCollisionEnter2D(Collision2D collision) {
            Debug.Log("in collsion:" + collision.transform.tag);
            if (collision.transform.tag == "Meteorite") {
                health -= 1;
                Debug.Log("reduced health");
            }
            if (health == 0) {
                Debug.Log("Player died");
                //TODO: dying scene change
            }
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
