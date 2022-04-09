using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class ActionQueue
    {
        private static ActionQueue instance = new ActionQueue();
        private List<ActionKey> activeActions;

        private event Action onUpdateQueue;

        private ActionQueue()
        {
            instance = this;
            activeActions = new List<ActionKey>();

            onUpdateQueue += SendKey;
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

        // Add ACTIVE Action to Queue
        // Combine Actions if valid
        public void Enqueue(ActionKey key)
        {
            // adding logic HERE
            activeActions.Add(key);

            // then add result ActionKey
            string keys = "";
            foreach (var k in activeActions)
            {
                keys += k + " ";
            }

            //Debug.Log(keys);

            onUpdateQueue();
        }

        // Remove Action from Queue
        public void Dequeue(ActionKey key)
        {
            
            activeActions.Remove(key);

            string keys = "";
            foreach (var k in activeActions)
            {
                keys += k + " ";
            }

            //Debug.Log(keys);

            onUpdateQueue();
        }

        private void SendKey()
        {
            if (activeActions.Count == 0)
            {
                // send null
                Debug.Log("idle");
                return;
            }
            Debug.Log(activeActions.Last());
            
        }


    }
}