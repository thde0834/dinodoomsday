using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Player
{
    public class Grounded : State
    {
        public Grounded(Player player) : base(player)
        {
            stateKey = StateKey.Grounded;
            Debug.Log(stateKey + " instantiated");
            
        }

        protected override Dictionary<ActionKey, PlayerAction> initializeActions()
        {
            var initialActions = new Dictionary<ActionKey, PlayerAction>()
            {
                {ActionKey.Move, new Walk(player)},

            };

            return initialActions;
        }
    }
}
