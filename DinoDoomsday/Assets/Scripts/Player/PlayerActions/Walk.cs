using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Walk : PlayerAction
    {
        public Walk(Player player) : base(player)
        {
            actionKey = ActionKey.Move;
            InitializeAction();
            Debug.Log("Walk instantiated");
        }

        public override void Perform()
        {
            Debug.Log("Walking");
        }
    }
}
