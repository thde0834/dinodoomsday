using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public enum Color {
        Blue,
        Red,
        Pink
    }

    public enum Hat {
        None,
        Cowboy,
        Helmet
    }
    public class Player : MonoBehaviour
    {
        // Should NOT be referenced in an Awake() function
        public static Player instance { get; private set; }
        public Rigidbody2D rb { get; private set; }

        public StateFactory stateFactory => StateFactory.getInstance;
        public ActionFactory actionFactory => ActionFactory.instance;

        public HealthDisplayManager healthDisplayManager;

        private int health;
        private Color primaryColor;
        private Color secondaryColor;
        private Hat hat;
        private ReadCustomizationData jsonReader;

        public void Awake()
        {
            instance = this;
            rb = GetComponent<Rigidbody2D>();
            health = 3;
            jsonReader = new ReadCustomizationData();
            CustomizationDataObj customizationDataObj = jsonReader.readJson();
            if (customizationDataObj.primaryColor != null) {
                primaryColor = customizationDataObj.primaryColor;
                secondaryColor = customizationDataObj.secondaryColor;
                hat = customizationDataObj.hat;
            } else { //setting default dinosaur settings if they have not customized their character
                primaryColor = Color.Blue;
                secondaryColor = Color.Red;
                hat = Hat.None;
            }
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
                //TODO: dying scene change
            }
        }

        public void changePrimaryColor(Color color) {
            this.primaryColor = color;
        }

        public void changeSecondaryColor(Color color) {
            this.secondaryColor = color;
        }

        public void changeHat(Hat hat) {
            this.hat = hat;
        }
    }
}
