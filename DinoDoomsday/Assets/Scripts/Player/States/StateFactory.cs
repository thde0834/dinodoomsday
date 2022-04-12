using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StateFactory
    {
        private StateMachine stateMachine;

        public static StateFactory instance { get; private set; }
        private StateFactory()
        {
            instance = this;
            
            stateMachine = StateMachine.instance;
        }

        public static StateFactory getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StateFactory();
                }

                return instance;
            }
        }

        public void CreateState(StateKey stateKey, State state)
        {
            if (stateMachine.availableStates.ContainsKey(stateKey))
            {
                return;
            }

            stateMachine.AddState(stateKey, state);
        }

    }
}