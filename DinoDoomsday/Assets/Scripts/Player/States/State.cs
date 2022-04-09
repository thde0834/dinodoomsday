using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class State
    {
        protected StateKey stateKey;

        protected Player player;
        protected GameObject gameObject;

        public State(Player player)
        {
            this.player = player;
        }
    }
}
