using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AirMove : Walk
    {
        private readonly float MOVING_SPEED = 6f;

        public AirMove(Player player) : base(player)
        {
            Debug.Log("AirMove instantiated");
        }

        public override void onStateChange()
        {
            onEnter();
        }

        public override void onEnter()
        {
            direction = getDirection();
            horizontalVelocity = direction * MOVING_SPEED;
        }

        public override void Perform()
        {
            Movement.SetVelocityX(rb, horizontalVelocity);

            // will have to change for joystick input
            direction = getDirection();

            horizontalVelocity = direction * MOVING_SPEED;
        }

        public override void onExit()
        {
            horizontalVelocity = 0f;
            Movement.SetVelocityX(rb, horizontalVelocity);
        }
    }
}
