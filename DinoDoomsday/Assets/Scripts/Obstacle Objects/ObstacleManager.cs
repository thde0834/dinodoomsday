using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private List<Meteorite> meteorites;
    private List<Enemy> enemies;
    public Transform meteoritePrefab;
    public Transform enemyPrefab;
    public GameObject player;
    public float probMeteorite = 0f; //probability that meteorite will fall

    void Start()
    {
        // meteorites = new  List<Meteorite>();
        // enemies = new List<Enemy>();
    }

    void Awake() {
        // createMeteorite();
        // createEnemy();
    }

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
