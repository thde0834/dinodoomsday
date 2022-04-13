using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class Walk : PlayerAction
    {
        protected PlayerControls playerControls;
        public Walk(Player player) : base(player)
        {
            playerControls = inputManager.playerControls;
        }

        protected sealed override ActionKey SetActionKey()
        {
            return ActionKey.Move;
        }
        
    }
}
