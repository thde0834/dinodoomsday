using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * Adapter/Singleton Class
 * Takes ActionKeys from the InputManager and sends them to the StateMachine
 */
namespace Player
{
    public class ActionQueue
    {
        private static ActionQueue instance;
        private StateMachine stateMachine;

        private List<ActionKey> activeActionKeys;

        private ActionQueue()
        {
            instance = this;
            activeActionKeys = new List<ActionKey>();
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
            if (activeActionKeys.Contains(key)) // redundant?
            {
                return;
            }

            activeActionKeys.Add(key);
            stateMachine.AddActiveActionKey(key);
        }
        
        public void Dequeue(ActionKey key)
        {
            if (!activeActionKeys.Contains(key))
            {
                return;
            }

            activeActionKeys.Remove(key);
            stateMachine.RemoveActiveActionKey(key);
        }

    }
}