using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class Walk : PlayerAction
    {
        protected PlayerControls playerControls;

        protected float horizontalVelocity;
        protected int direction;

        public Walk(Player player) : base(player)
        {
            playerControls = inputManager.playerControls;
        }

        protected sealed override ActionKey SetActionKey()
        {
            return ActionKey.Move;
        }

        protected int getDirection()
        {
            var inputValue = playerControls.Player.Move.ReadValue<Vector2>().x;

            if (inputValue == 0)
            {
                return 0;
            }

            int newDirection = (inputValue > 0) ? 1 : -1;

            Flip(newDirection);

            return newDirection;
        }

        private void Flip(int newDirection)
        {
            switch (newDirection)
            {
                case -1:    // face left
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 180f, 0);
                    return;
                }
                case 1:     // face right
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    return;
                }
                default:
                {
                    return;
                }
            }
        }

    }
}
