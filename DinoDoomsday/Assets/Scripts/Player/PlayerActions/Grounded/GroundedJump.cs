using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class GroundedJump : Jump
    {
        public GroundedJump(Player player) : base(player)
        {
            changeOnStateChange = false;
            Debug.Log("Grounded Jump instantiated");
        }

        public override void Perform()
        {
            rb.velocity += Vector2.up * 1;
        }
    }
}
