using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        //Camera movement reference: https://forum.unity.com/threads/making-camera-follow-an-object.32831/
        if (player != null) {
            transform.position = player.position + new Vector3(0f,0f,-10f);   
        }
    }
}
