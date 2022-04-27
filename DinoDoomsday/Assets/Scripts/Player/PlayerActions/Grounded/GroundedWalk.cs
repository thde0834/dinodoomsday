using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class GroundedWalk : Walk
    {
        private readonly float MIN_WALKING_SPEED = 4f;
        private readonly float WALKING_ACCELERATION = 2f;
        private readonly float MAX_WALKING_SPEED = 8f;

        public GroundedWalk(Player player) : base(player)
        {
            Debug.Log("Grounded Walk instantiated");
        }

        public override void onStateChange()
        {
            onEnter();
        }

        public override void onEnter()
        {
            direction = getDirection();
            horizontalVelocity = direction * MIN_WALKING_SPEED;
        }

        public override void Perform()
        {
            Movement.SetVelocityX(rb, horizontalVelocity);

            // v = v0 + a*t
            horizontalVelocity += direction * WALKING_ACCELERATION * Time.deltaTime;

            if (direction * horizontalVelocity > MAX_WALKING_SPEED)
            {
                horizontalVelocity = direction * MAX_WALKING_SPEED;
            }

        }

        public override void onExit()
        {
            horizontalVelocity = 0f;
            Movement.SetVelocityX(rb, horizontalVelocity);
        }
    }
}
