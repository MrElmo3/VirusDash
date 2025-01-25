using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float liquidDensity = 1000f;
    public float dragCo = 0.47f;
    private Rigidbody2D rb;
    private float volObject;
    
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        float objectDensity = 50;
        volObject = rb.mass/objectDensity;
    }

    void FixedUpdate(){
        float forcePush = liquidDensity * volObject * Physics.gravity.magnitude;
        Vector3 forceVector = forcePush * Vector3.up;

        float velocity = rb.velocity.magnitude;
        Vector3 directionVel = rb.velocity.normalized;
        float area= Mathf.PI * Mathf.Pow(transform.localScale.x / 2, 2);
        float forceDrag = 0.5f * liquidDensity* velocity *velocity * dragCo;
        Vector3 forceDragResult = -forceDrag * directionVel;

        rb.AddForce(forceVector + forceDragResult);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
