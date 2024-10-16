using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableExample : MonoBehaviour
{
    public Rigidbody rb;

    public Vector3 force = new Vector3(0, 0, 5f);
    void Start()
    {
        if (rb == null) {
            Debug.LogWarning("No rigidbody.");
        }
    }

   
    void Update()
    {
        if (rb != null) {
            rb.AddForce(force);
        }
    }
}
