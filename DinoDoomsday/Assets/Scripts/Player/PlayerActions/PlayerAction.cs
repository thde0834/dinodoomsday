using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class PlayerAction
    {
        protected Player player;
        protected GameObject gameObject;
        protected Rigidbody2D rb;

        protected InputManager inputManager;

        public ActionKey actionKey { get; private set; }

        // need a better name for this variable
        public bool changeOnStateChange { get; protected set; }

        protected PlayerAction(Player player)
        {
            this.player = player;
            gameObject = player.gameObject;
            rb = player.rb;

            actionKey = SetActionKey();
            inputManager = InputManager.instance;
            inputManager.AddKey(actionKey);

            // assume true unless declared false in child class
            changeOnStateChange = true;
        }

        protected abstract ActionKey SetActionKey();
        public abstract void Perform();
    }
}
