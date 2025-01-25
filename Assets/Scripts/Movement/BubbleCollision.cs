using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        rb.velocity = Vector3.zero;
    }
}
