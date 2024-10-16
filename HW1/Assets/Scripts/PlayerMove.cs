using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public Rigidbody rb;
    public float moveForce = 5f;


    void Start()
    {
        if (rb == null) {
            rb = GetComponent<Rigidbody>();
            if (rb == null) {
                Debug.LogError("No rigidbody.");
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(move * moveForce);
    }
}
