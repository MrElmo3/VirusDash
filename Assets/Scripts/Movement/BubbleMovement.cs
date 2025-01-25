using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float bubbleVelocity = 1.0f;
    public Vector3 bubbleDisplacement = new Vector3(0, 0, 0);

    private Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
    }

    void Update(){
        transform.position = 
            startPosition + Mathf.Lerp(-1, 1, (Mathf.Sin(Time.time * bubbleVelocity) + 1 ) / 2) 
            * bubbleDisplacement;
    }
}
