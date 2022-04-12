using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Player
{
    public class Aerial : State
    {
        public Aerial(Player player) : base(player)
        {
            stateKey = StateKey.Aerial;
            Debug.Log(stateKey + " instantiated");

        }

        protected override Dictionary<ActionKey, PlayerAction> initializeActions()
        {
            var initialActions = new Dictionary<ActionKey, PlayerAction>()
            {

            };

            return initialActions;
        }
    }
}
