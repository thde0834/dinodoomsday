using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Player : MonoBehaviour
    {
        // Should NOT be referenced in an Awake() function
        public static Player instance { get; private set; }
        public Rigidbody2D rb => GetComponent<Rigidbody2D>();

        public StateFactory stateFactory => StateFactory.getInstance;
        public ActionFactory actionFactory => ActionFactory.instance;

        public HealthDisplayManager healthDisplayManager;

        private int health;
        //referenced https://www.youtube.com/watch?v=hkaysu1Z-N8 to add animations
        public Animator animator;

        public void Awake()
        {
            instance = this;
            health = 3;
        }

        void Update() {
            healthDisplayManager.changeLocation(transform.position);
        }

        //for collision detection info referenced https://www.youtube.com/watch?v=0ZJPmjA5Hv0
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.transform.tag == "Meteorite" || collision.transform.tag == "Enemy") {
                health -= 1;
                Debug.Log("reduced health");
                healthDisplayManager.deleteHeart();
            }
            if (health == 0) {
                Debug.Log("Player died");
                Destroy(this.gameObject);
            }
        }

        public bool isDead() {
            if (health <= 0) {
                return true;
            } 
            return false;
        }
    }
}
