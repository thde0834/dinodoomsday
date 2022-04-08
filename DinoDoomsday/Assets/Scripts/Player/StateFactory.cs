using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StateFactory
    {
        private Player player;
        //private Dictionary<StateKey, State> availableStates;

        private InputManager inputManager;

        public StateFactory(Player player)
        {
            this.player = player;

            //availableStates = new Dictionary<StateKey, State>();
            inputManager = InputManager.instance;
        }

        private void Initialize()
        {

        }

        //public void CreateState(StateKey key, State state)
        //{
        //    if (availableStates.ContainsKey(key))
        //    {
        //        return;
        //    }

        //    availableStates.Add(key, state);
        //    inputManager.AddKey(key);

        //    Debug.Log(key + " created");
        //}
    }
}