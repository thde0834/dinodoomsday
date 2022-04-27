using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayManager : MonoBehaviour
{
    //List reference for C#: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0
    public List<Transform> heartPrefabs = new List<Transform>();
    public List<Vector3> positions = new List<Vector3>();
    public Transform heartPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //List reference for C#: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0
        heartPrefabs.Add(Instantiate(heartPrefab));
        heartPrefabs[0].position = positions[0];
        heartPrefabs.Add(Instantiate(heartPrefab));
        heartPrefabs[1].position = positions[1];
        heartPrefabs.Add(Instantiate(heartPrefab));
        heartPrefabs[2].position = positions[2];
    }

    public void changeLocation(Vector3 pos) {
        for (int i = 0; i < heartPrefabs.Count; i++) {
            heartPrefabs[i].position = positions[i] + pos;
        }
    }

    public void deleteHeart() {
        //List reference for C#: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0
        if (heartPrefabs.Count != 0) {
            Destroy(heartPrefabs[heartPrefabs.Count-1].gameObject);
            heartPrefabs.RemoveAt(heartPrefabs.Count-1);
        }
    }
}
