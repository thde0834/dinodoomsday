using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class Jump : PlayerAction
    {
        protected readonly float UPWARD_GRAVITY_STRENGTH = 10f;
        protected readonly float DOWNWARD_GRAVITY_STRENGTH = 12f;

        protected Jump(Player player) : base(player)
        {
            //
        }

        protected sealed override ActionKey SetActionKey()
        {
            return ActionKey.Jump;
        }
        
    }
}