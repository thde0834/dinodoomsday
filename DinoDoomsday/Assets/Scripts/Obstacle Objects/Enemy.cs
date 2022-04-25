using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3f;
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        float prob = Random.Range(0f,1f);
        if (prob <=0.5) {
            transform.position = new Vector2(-6f, -2f);
        } else {
            transform.position = new Vector2(6f, -2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0f,-2f), step);
    }

    //for collision detection info referenced https://www.youtube.com/watch?v=0ZJPmjA5Hv0
    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("in collsion enemy:" + collision.transform.tag);
        if (collision.transform.tag == "Player") {
            die();
        }
    }

    void die() {
        //TODO: Create dying animation
        Debug.Log("Enemy Dying");
        //Referenced https://unphayzed.com/2020/08/07/how-to-destroy-an-object-on-collision-in-unity/#:~:text=To%20destroy%20an%20object%20on%20collision%20within%20the%20using%20ty,()%20method%20for%203D%20games. to destroy game object on collision
        Destroy(this.gameObject);
    }
}
