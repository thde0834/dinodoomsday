using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Walk : PlayerAction
    {
        private PlayerControls playerControls;
        public Walk(Player player) : base(player)
        {
            actionKey = ActionKey.Move;
            InitializeAction();

            playerControls = inputManager.playerControls;

            Debug.Log("Walk instantiated");
        }

        public override void Perform()
        {
            var moveValue = playerControls.Player.Move.ReadValue<Vector2>();
            rigidbody.velocity = moveValue * 4;
        }
    }
}
