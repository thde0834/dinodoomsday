using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class ActionQueue
    {
        private static ActionQueue instance = new ActionQueue();
        private List<ActionKey> activeStates;

        private event Action onUpdateQueue;

        private ActionQueue()
        {
            instance = this;
            activeStates = new List<ActionKey>();

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
        public void AddKey(ActionKey key)
        {
            // adding logic HERE
            activeStates.Add(key);

            // then add result ActionKey
            string keys = "";
            foreach (var k in activeStates)
            {
                keys += k + " ";
            }

            //Debug.Log(keys);

            onUpdateQueue();
        }

        // Remove Action from Queue
        public void RemoveKey(ActionKey key)
        {
            activeStates.Remove(key);

            string keys = "";
            foreach (var k in activeStates)
            {
                keys += k + " ";
            }

            //Debug.Log(keys);

            onUpdateQueue();
        }

        private void SendKey()
        {
            if (activeStates.Count == 0)
            {
                // send null
                Debug.Log("idle");
                return;
            }
            Debug.Log(activeStates.Last());
            
        }


    }
}