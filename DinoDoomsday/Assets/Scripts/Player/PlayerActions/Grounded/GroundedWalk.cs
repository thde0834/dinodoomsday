using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class GroundedWalk : Walk
    {
        public GroundedWalk(Player player) : base(player)
        {
            Debug.Log("Grounded Walk instantiated");
        }

        public override void Perform()
        {
            var moveValue = playerControls.Player.Move.ReadValue<Vector2>();
            rb.velocity = moveValue * 4;
        }
    }
}
