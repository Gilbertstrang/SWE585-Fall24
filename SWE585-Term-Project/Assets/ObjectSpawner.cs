using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private int spawnCount;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int width;
    [SerializeField] private float objectDistance;


    void Awake()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var instance = Instantiate(objectPrefab);
            var x = i % width;
            var z = i / width;
            instance.transform.position = new Vector3(x, 0, z) * objectDistance * 2;
        }    
    }

    
}
