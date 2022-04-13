using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Player
{
    public class AirJump : PlayerAction
    {
        public AirJump(Player player) : base(player)
        {
            actionKey = ActionKey.Jump;
            InitializeAction();
            Debug.Log("AirJump instantiated");
        }

        public override void Perform()
        {
            //rigidbody.velocity += Vector2.up * 5;
            Debug.Log("Air Jump performed");
        }
    }
}
