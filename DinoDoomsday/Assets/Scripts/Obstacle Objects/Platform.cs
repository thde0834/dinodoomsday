using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float rotationSpeed = 50f;
    float z = 0f;
    private bool completeHalfCycle = false;
    private float cummulativeRotation = 0f;
    public int rotationLimit = 25;
    public bool shaking = false; //changes if stable platform
    public bool endPlatform = false; //denotes state as last platform of level!
    private bool active = false;

    // Update is called once per frame
    void Update()
    {
        if (shaking) {
            shake();
        }
    }

    //Rotation reference adapted from : https://docs.unity3d.com/ScriptReference/Transform.Rotate.html and https://answers.unity.com/questions/1602053/localrotation-and-transform-rotate.html
    private void shake() {
        //rotates the platform down to some bound
        if (!completeHalfCycle) {
            z = Time.deltaTime * rotationSpeed;
            cummulativeRotation += z;
            transform.Rotate(0, 0, z, Space.Self);
            if (cummulativeRotation >= rotationLimit) {
                completeHalfCycle = true;
            }
        }
        if (completeHalfCycle) { //rotates the platform up to some bound
            z = -(Time.deltaTime * rotationSpeed);
            cummulativeRotation += z;
            transform.Rotate(0, 0, z, Space.Self);
            if (cummulativeRotation <= -rotationLimit) {
                completeHalfCycle = false;
            }
        }
    }

    public bool getActive() {
        return active;
    }

    //for collision detection info referenced https://www.youtube.com/watch?v=0ZJPmjA5Hv0
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {
            active = true;
        }
    }

    //referenced for on collision exit method name: https://answers.unity.com/questions/1220752/how-to-detect-if-not-colliding.html
    private void OnCollisionExit2D(Collision2D collision)
    {
        active = false;
    }
}
