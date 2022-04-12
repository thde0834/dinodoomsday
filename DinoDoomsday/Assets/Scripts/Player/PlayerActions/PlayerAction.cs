using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class PlayerAction
    {
        protected Player player;
        protected GameObject gameObject;

        public PlayerAction(Player player)
        {
            this.player = player;
            gameObject = player.gameObject;
        }
        public abstract void Perform();
    }
}
