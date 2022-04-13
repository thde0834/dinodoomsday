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
        // public Rigidbody2D rigidbody { get; private set; }
        public Rigidbody2D rigidBody;

        public StateFactory stateFactory => StateFactory.getInstance;
        public ActionFactory actionFactory => ActionFactory.instance;

        private int health;
        private Color primaryColor;
        private Color secondaryColor;
        private Hat hat;
        private ReadCustomizationData jsonReader;

        public void Awake()
        {
            instance = this;
            rigidBody = GetComponent<Rigidbody2D>();
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
            Debug.Log("in collsion:" + collision.transform.tag);
            if (collision.transform.tag == "Meteorite") {
                health -= 1;
                Debug.Log("reduced health");
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
