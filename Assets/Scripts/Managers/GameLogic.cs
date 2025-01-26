using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance{ get;set;}
   
   void Awake()
   {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Awakee();
   }


    [Header("Variables only for testing")]
    public float targetHeightTest = 50f;
    public float speedWaterTest = 5f;


    [Header("References")]
    public GameManager gameManager;
    public GameObject waterLevel;
    public GameObject tube;

        
    private float duration;
    private Vector3 startposition;
    private Vector3 targetposition;
    private float elapsedTime = 0f;

    private float targetHeightGame;
    private float speedWaterLevelGame;

    public float TargetHeightGame=> targetHeightGame;

    public static System.Action<string> onGameEnd;


    void Awakee(){
        if(!LevelManager.Instance){
            targetHeightGame = targetHeightTest;
            speedWaterLevelGame = speedWaterTest;

        }else{
            LevelManager.LevelDTO level = LevelManager.Instance.GetCurrentLevelDTO();
            targetHeightGame = level.heightTube;
            speedWaterLevelGame = level.speedTube;
        }
        onGameEnd+= OnGameEnd;
    }

    void OnDestroy(){
        onGameEnd -= OnGameEnd;
    }

    void Start(){
        duration = targetHeightGame / speedWaterLevelGame;
        startposition = waterLevel.transform.position;
        targetposition = new Vector3(startposition.x, startposition.y + targetHeightGame, startposition.z);
        tube.transform.position = targetposition + new Vector3(0, 0, 3f);

        if(TutorialManager.Instance && TutorialManager.Instance.CheckEnableTutorial()){
            TutorialManager.Instance.ShowTutorial();
        }

    }

    void Update(){
        if(!gameManager.isStarted) return;
        elapsedTime+= Time.deltaTime;
        waterLevel.transform.position= Vector3.Lerp(startposition, targetposition , elapsedTime / duration);
        if(elapsedTime >= duration){
            waterLevel.transform.position = targetposition;
            GameEnd("time");
        }
    }
    
    public void GameEnd(string code){
        if(onGameEnd != null){
            onGameEnd.Invoke(code);
            onGameEnd = null;
        }
    }

    void OnGameEnd(string code){
        if(LevelManager.Instance){
            switch(code){
                case "time": 
                    MessageCanvasManager.Instance.SetMessage(false);
                    Debug.Log("se lleno la barra, perdiste");
                    break;
                case "water":
                    MessageCanvasManager.Instance.SetMessage(false);
                    Debug.Log("chocaste agua");
                    break;
                case "win":
                    MessageCanvasManager.Instance.SetMessage(true);
                    Debug.Log("chocaste agua");
                    break;
            }
        }else{
             Debug.Log("end game " + code);
            #if UNITY_EDITOR
                UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
            #else
                Debug.LogError("Error en la matrix");
            #endif
        }
    }

    public void RestartGame(){
        SceneGameManager.Instance.GoToGame();
    }

    public void QuitGame(){
       SceneGameManager.Instance.GoQuit();
    }
    public void NextLevel(){
        if(LevelManager.Instance.CheckEndLevels()){
            //SceneGameManager.Instance.GoToCredits();
            SceneGameManager.Instance.GoToBoot();
        }else{
            LevelManager.Instance.SetLevel();
		    SceneGameManager.Instance.GoToGame();
        }
        
    }
    
}
