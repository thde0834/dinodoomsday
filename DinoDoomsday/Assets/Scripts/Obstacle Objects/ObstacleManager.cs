using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private List<Meteorite> meteorites;
    public Transform meteoritePrefab;
    public GameObject player;

    void Start()
    {
        // meteorites = new  List<Meteorite>();
    }

    void Awake() {
        createMeteorite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createMeteorite() {
        //GameObject meteorite = 
        Instantiate(meteoritePrefab);
        // BoundsIntersecting meteoriteBoundsIntersecting = new BoundsIntersecting(meteorite, player);
        //meteorites.Add(meteorite);
    }
}
