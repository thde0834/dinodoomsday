using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public Transform meteoritePrefab;
    public Transform enemyPrefab;
    public GameObject player;
    public float probMeteorite = 0f; //probability that meteorite will fall; if higher than more meteorites over course of game
    
    // Update is called once per frame
    void Update()
    {
        float result = Random.Range(0f,1f);
        if (result < probMeteorite) {
            createMeteorite();
        }
    }

    private void createMeteorite() {
        Instantiate(meteoritePrefab);
    }

    private void createEnemy() {
        Instantiate(enemyPrefab);
    }
}
