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
    public bool shaking = true; //changes if stable platform
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shaking) {
            shake();
        }
    }

    //Rotation reference adapted from : https://docs.unity3d.com/ScriptReference/Transform.Rotate.html and https://answers.unity.com/questions/1602053/localrotation-and-transform-rotate.html
    private void shake() {
        if (!completeHalfCycle) {
            z = Time.deltaTime * rotationSpeed;
            cummulativeRotation += z;
            transform.Rotate(0, 0, z, Space.Self);
            if (cummulativeRotation >= rotationLimit) {
                completeHalfCycle = true;
            }
        }
        if (completeHalfCycle) {
            z = -(Time.deltaTime * rotationSpeed);
            cummulativeRotation += z;
            transform.Rotate(0, 0, z, Space.Self);
            if (cummulativeRotation <= -rotationLimit) {
                completeHalfCycle = false;
            }
        }
    }
}
