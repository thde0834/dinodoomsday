using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For this class code modified from: https://docs.unity3d.com/ScriptReference/Bounds.Intersects.html
public class BoundsIntersecting : MonoBehaviour
{
    public GameObject player;
    public Meteorite obstacle;
    Collider playerCollider, obstacleCollider;
    // Start is called before the first frame update
    void Start()
    {
        if (player != null) {
            playerCollider = player.GetComponent<Collider>();
        }
        if (obstacle != null) {
            obstacleCollider = obstacle.GetComponent<Collider>();
        }
        
    }

    public BoundsIntersecting(GameObject player, Meteorite obstacle) {
        // this.player = player;
        // this.obstacle = obstacle;
    }

    // Update is called once per frame
    void Update()
    {
        // if (obstacleCollider.bounds.Intersects(playerCollider.bounds)) {
        //     obstacle.setCollided(true);
        // }
    }
}
