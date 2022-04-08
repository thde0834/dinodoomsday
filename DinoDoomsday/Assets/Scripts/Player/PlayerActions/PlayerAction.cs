using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class PlayerAction
    {
        protected ActionKey actionKey;

        protected Player player;
        protected GameObject gameObject;
    }
}
