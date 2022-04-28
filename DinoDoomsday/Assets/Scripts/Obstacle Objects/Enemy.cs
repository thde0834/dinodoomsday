using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    //for collision detection info referenced https://www.youtube.com/watch?v=0ZJPmjA5Hv0
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {
            die();
        }
    }

    void die() {
        //Referenced https://unphayzed.com/2020/08/07/how-to-destroy-an-object-on-collision-in-unity/#:~:text=To%20destroy%20an%20object%20on%20collision%20within%20the%20using%20ty,()%20method%20for%203D%20games. to destroy game object on collision
        Destroy(this.gameObject);
    }
}
