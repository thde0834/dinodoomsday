using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class Jump : PlayerAction
    {
        protected Jump(Player player) : base(player)
        {
            
        }

        protected sealed override ActionKey SetActionKey()
        {
            return ActionKey.Jump;
        }
        
    }
}