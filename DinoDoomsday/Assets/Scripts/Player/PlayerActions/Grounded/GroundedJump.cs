using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace Player
{
    public class GroundedJump : Jump
    {
        // move to jump class?
        protected readonly float JUMP_STRENGTH = 10f;

        private float verticalVelocity;

        public GroundedJump(Player player) : base(player)
        {
            changeOnStateChange = false;
            Debug.Log("Grounded Jump instantiated");
        }

        public override void onStateChange()
        {
            onEnter();
        }

        // called when Jump key is pressed
        public override void onEnter()
        {
            verticalVelocity = JUMP_STRENGTH;
        }

        // called in StateMachine.FixedUpdate()
        public override void Perform()
        {
            Movement.SetVelocityY(rb, verticalVelocity);

            if (rb.velocity.y > 0)  // Player is moving upwards
            {
                verticalVelocity -= UPWARD_GRAVITY_STRENGTH * Time.deltaTime;
            }
            else                    // Player is falling downwards
            {
                verticalVelocity -= DOWNWARD_GRAVITY_STRENGTH * Time.deltaTime;
            }
        }

        // called when Jump key is released
        public override void onExit()
        {
            verticalVelocity = -DOWNWARD_GRAVITY_STRENGTH;
            Movement.SetVelocityY(rb, verticalVelocity);
        }
    }
}
