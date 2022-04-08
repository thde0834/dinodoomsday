using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum StateKey
    {
        // Don't add subclasses?
        Jump,
        Move, Walk, Dash,
        Attack,

        // Jump + Attack
        JumpingAttack
    };
}
