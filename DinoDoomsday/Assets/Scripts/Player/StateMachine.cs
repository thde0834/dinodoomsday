using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StateMachine
    {
        private static StateMachine instance = new StateMachine();
        //private State defaultState;
        //public State CurrentState { get; private set; }

        private StateMachine()
        {
            instance = this;
            //CurrentState = null;    // TO DO: set 'default' state
        }

        public static StateMachine getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StateMachine();
                }
                return instance;
            }
        }

        //public void ChangeState(State state)
        //{
        //    CurrentState = state;
        //}

        public void Update()
        {
            // if currentstate == null then currentstate = idlestate
            //CurrentState.performAction();
        }

    }
}