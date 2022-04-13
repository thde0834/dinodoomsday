using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Player
{
    public class AirJump : Jump
    {
        public AirJump(Player player) : base(player)
        {
            Debug.Log("AirJump instantiated");
        }
        
        public override void Perform()
        {
            //rb.velocity += Vector2.up * 5;
            Debug.Log("Air Jump performed");
        }
    }
}
