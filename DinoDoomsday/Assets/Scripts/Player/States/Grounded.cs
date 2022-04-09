using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Grounded : State
    {
        public Grounded(Player player) : base(player)
        {
            stateKey = StateKey.Grounded;
            Debug.Log("Grounded instantiated");
        }
    }
}
