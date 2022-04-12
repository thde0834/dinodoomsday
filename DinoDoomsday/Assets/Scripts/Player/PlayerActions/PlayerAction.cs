using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class PlayerAction
    {
        protected Player player;
        protected GameObject gameObject;

        protected InputManager inputManager;

        protected ActionKey actionKey;

        public PlayerAction(Player player)
        {
            this.player = player;
            gameObject = player.gameObject;
        }

        // Called in child constructor
        protected void InitializeAction()
        {
            inputManager = InputManager.instance;
            inputManager.AddKey(actionKey);
        }
        public abstract void Perform();
    }
}
