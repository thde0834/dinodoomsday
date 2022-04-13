using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class ActionQueue
    {
        private static ActionQueue instance;
        private StateMachine stateMachine;

        private List<ActionKey> activeActions;

        private ActionQueue()
        {
            instance = this;
            activeActions = new List<ActionKey>();
            stateMachine = StateMachine.instance;
        }

        public static ActionQueue getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ActionQueue();
                }
                return instance;
            }
        }
        
        public void Enqueue(ActionKey key)
        {
            if (!stateMachine.CurrentState.actions.ContainsKey(key))
            {
                return;
            }

            activeActions.Add(key);

            SendKey();
        }
        
        public void Dequeue(ActionKey key)
        {
            if (!activeActions.Contains(key))
            {
                return;
            }

            activeActions.Remove(key);

            SendKey();
        }

        private void SendKey()
        {
            stateMachine.activeActions = activeActions;
        }

    }
}