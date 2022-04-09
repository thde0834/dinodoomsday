using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Android;

namespace Player
{
    public class ActionFactory
    {
        private Player player;

        private Dictionary<ActionKey, PlayerAction> playerActions;

        public ActionFactory(Player player)
        {
            this.player = player;
            InitializeActions();
        }

        private void InitializeActions()
        {
            
        }

        public void CreateAction(ActionKey key)
        {

        }
    }
}