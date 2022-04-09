using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StateFactory
    {
        private readonly Player player;
        private Dictionary<StateKey, State> playerStates;
        public StateFactory(Player player)
        {
            this.player = player;
            InitializeStates();
        }

        private void InitializeStates()
        {
            playerStates = new Dictionary<StateKey, State>()
            {
                {StateKey.Grounded, new Grounded(player)},
            };
        }

        public void CreateState(StateKey key)
        {
            if (playerStates.ContainsKey(key))
            {
                return;
            }

        }
    }
}