using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class PlayerAction
    {
        protected Player player;
        protected GameObject gameObject;
        protected Rigidbody2D rigidbody;

        protected InputManager inputManager;

        protected ActionKey actionKey;

        public PlayerAction(Player player)
        {
            this.player = player;
            gameObject = player.gameObject;
            rigidbody = player.rigidbody;
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
