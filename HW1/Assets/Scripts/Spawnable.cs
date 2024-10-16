using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    
    public GameObject objectSpawn;

    public Transform spawnPoint;

    public KeyCode spawnKey = KeyCode.Space; //key to spawn
 
    void Update()
    {
        if (Input.GetKeyDown(spawnKey)) {
            Instantiate(objectSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
