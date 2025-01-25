using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [Header("Variables only for testing")]
    public float targetHeightTest = 50f;
    public float speedWaterTest = 5f;


    [Header("References")]
    public GameObject waterLevel;
    public GameObject tube;

        
    private float duration;
    private Vector3 startposition;
    private Vector3 targetposition;
    private float elapsedTime = 0f;

    private float targetHeightGame;
    private float speedWaterLevelGame;

    public System.Action onGameEnd;


    void Awake(){
        if(!LevelManager.Instance){
            targetHeightGame = targetHeightTest;
            speedWaterLevelGame = speedWaterTest;

        }else{
            LevelManager.LevelDTO level = LevelManager.Instance.GetCurrentLevelDTO();
            targetHeightGame = level.heightTube;
            speedWaterLevelGame = level.speedTube;
        }
        onGameEnd+= GameEnd;
    }

    void OnDestroy(){
        onGameEnd -= GameEnd;
    }

    void Start(){
        duration = targetHeightGame / speedWaterLevelGame;
        startposition = waterLevel.transform.position;
        targetposition = new Vector3(startposition.x, startposition.y + targetHeightGame, startposition.z);
        tube.transform.position = targetposition;
    }

    void Update(){
        elapsedTime+= Time.deltaTime;
        waterLevel.transform.position= Vector3.Lerp(startposition, targetposition , elapsedTime / duration);
        if(elapsedTime >= duration){
            waterLevel.transform.position = targetposition;
            if(onGameEnd != null){
                onGameEnd.Invoke();
                onGameEnd = null;
            }
        }
    }
    void GameEnd(){
        Debug.Log("se lleno la barra, perdiste");
    }
}
