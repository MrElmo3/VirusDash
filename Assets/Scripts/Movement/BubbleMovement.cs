using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float bubbleVelocity = 1.0f;
    public Vector3 bubbleDisplacement = new Vector3(0, 0, 0);
    private Vector3 bubbleDisplacementGame;
    private Vector3 startPosition;
    void Awake(){
        if(!LevelManager.Instance){
            bubbleDisplacementGame = bubbleDisplacement;
        }
        else{
            LevelManager.LevelDTO level = LevelManager.Instance.GetCurrentLevelDTO();
            bubbleDisplacementGame = new Vector3(level.bubbleMovement.x, level.bubbleMovement.y,0);
        }
    }
    private void Start() {
        startPosition = transform.position;
    }

    void Update(){
        transform.position = 
            startPosition + Mathf.Lerp(-1, 1, (Mathf.Sin(Time.time * bubbleVelocity) + 1 ) / 2) 
            * bubbleDisplacement;
    }
}
