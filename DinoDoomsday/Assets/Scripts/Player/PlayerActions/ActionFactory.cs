using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Android;

namespace Player
{
    public class ActionFactory
    {
        public static ActionFactory instance { get; private set; }

        private Player player;
        private Dictionary<StateKey, Dictionary<ActionKey, PlayerAction>> unlockedActions;

        private InputManager inputManager;
        private ActionFactory()
        {
            instance = this;

            this.player = Player.instance;
            inputManager = InputManager.instance;

            unlockedActions = new Dictionary<StateKey, Dictionary<ActionKey, PlayerAction>>();
        }

        public static ActionFactory getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ActionFactory();
                }

                return instance;
            }
        }
        
    }
}