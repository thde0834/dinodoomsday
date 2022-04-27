using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class State
    {
        protected static StateKey stateKey;

        protected Player player;
        protected GameObject gameObject;
        public Dictionary<ActionKey, PlayerAction> actions { get; private set; }
        public State(Player player)
        {
            this.player = player;
            gameObject = player.gameObject;

            actions = initializeActions();
        }

        protected abstract Dictionary<ActionKey, PlayerAction> initializeActions();

        public virtual void onEnter()
        {
            foreach (var action in actions.Values)
            {
                action.onStateChange();
            }
        }

        public virtual void onExit() { }

        public PlayerAction GetAction(ActionKey key)
        {
            if (!actions.ContainsKey(key))
            {
                return null;
            }

            return actions[key];
        }
    }
}
