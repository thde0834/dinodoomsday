using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Player
{
    public class AirJump : Jump
    {
        protected readonly float JUMP_STRENGTH = 9f;

        // move to state
        private readonly int TOTAL_AIR_JUMPS = 1;

        private float verticalVelocity;
        private int airJumpsLeft;


        public AirJump(Player player) : base(player)
        {
            Debug.Log("AirJump instantiated");
        }

        public override void onStateChange()
        {
            airJumpsLeft = TOTAL_AIR_JUMPS;
        }

        public override void onEnter()
        {
            verticalVelocity = JUMP_STRENGTH;
        }
        
        public override void Perform()
        {
            if (airJumpsLeft <= 0)
            {
                return;
            }

            Movement.SetVelocityY(rb, verticalVelocity);

            if (verticalVelocity > 0)
            {
                verticalVelocity -= UPWARD_GRAVITY_STRENGTH * Time.deltaTime;
            }
            else
            {
                verticalVelocity = -DOWNWARD_GRAVITY_STRENGTH;
            }

        }

        public override void onExit()
        {
            airJumpsLeft--;

            verticalVelocity = -DOWNWARD_GRAVITY_STRENGTH;
            Movement.SetVelocityY(rb, verticalVelocity);
        }
        
    }
}
