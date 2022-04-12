using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Player : MonoBehaviour
    {
        // Should NOT be referenced in an Awake() function
        public static Player instance { get; private set; }
        public Rigidbody2D rigidBody { get; private set; }

        public StateFactory stateFactory => StateFactory.getInstance;
        public ActionFactory actionFactory => ActionFactory.instance;

        public void Awake()
        {
            instance = this;
            rigidBody = GetComponent<Rigidbody2D>();
        }

        public void Start()
        {

        }
        
    }
}
