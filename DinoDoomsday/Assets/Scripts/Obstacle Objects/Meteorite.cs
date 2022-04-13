using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    private float speed = 10f;
    private bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        //Random Range reference: https://docs.unity3d.com/ScriptReference/Random.Range.html
        transform.position = new Vector2(Random.Range(-6f, 6f), 5f);   
    }

    // Gradual movement reference: https://docs.unity3d.com/ScriptReference/Transform-position.html and https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0f,-1.8f), step);
    }

    //for collision detection info referenced https://www.youtube.com/watch?v=0ZJPmjA5Hv0
    private void OnCollisionEnter2D(Collision2D collision) {
        explode();
    }

    void explode() {
        //TODO: Create explosion animation
        Debug.Log("Exploding");
        //Referenced https://unphayzed.com/2020/08/07/how-to-destroy-an-object-on-collision-in-unity/#:~:text=To%20destroy%20an%20object%20on%20collision%20within%20the%20using%20ty,()%20method%20for%203D%20games. to destroy game object on collision
        Destroy(this.gameObject);
    }
}