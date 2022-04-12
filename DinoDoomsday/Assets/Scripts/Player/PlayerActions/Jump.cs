using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Jump : PlayerAction
    {
        public Jump(Player player) : base(player)
        {
            actionKey = ActionKey.Jump;
            InitializeAction();
            Debug.Log("Jump instantiated");
        }

        public override void Perform()
        {
            Debug.Log("Jumping");
        }
    }
}