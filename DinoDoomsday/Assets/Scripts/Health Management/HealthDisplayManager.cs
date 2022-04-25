using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayManager : MonoBehaviour
{
    //List reference for C#: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0
    public List<Transform> heartPrefabs = new List<Transform>();
    public Transform heartPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //List reference for C#: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0
        heartPrefabs.Add(Instantiate(heartPrefab));
        heartPrefabs.Add(Instantiate(heartPrefab));
        heartPrefabs[1].position = new Vector2(-8f, 4f);
        heartPrefabs.Add(Instantiate(heartPrefab));
        heartPrefabs[2].position = new Vector2(-7f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteHeart() {
        //List reference for C#: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0
        if (heartPrefabs.Count != 0) {
            Destroy(heartPrefabs[heartPrefabs.Count-1].gameObject);
            heartPrefabs.RemoveAt(heartPrefabs.Count-1);
        }
    }
}
