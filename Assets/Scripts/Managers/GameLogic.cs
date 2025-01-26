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

    [Header("Debug")]
    private Vector3 startposition;
    private Vector3 targetposition;
    [SerializeField] private float duration;
    [SerializeField] private float elapsedTime = 0f;

    private float targetHeightGame;
    private float speedWaterLevelGame;

    public float TargetHeightGame=> targetHeightGame - gap_tube_water;

    public static System.Action<string> onGameEnd;
    public static System.Action<string> onGameMode;
    public static float gap_tube_water = 5f; // gap porque no se puede reducir el render del agua

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
        onGameMode+= OnGameMode;
    }

    void OnDestroy(){
        onGameEnd -= OnGameEnd;
        onGameMode -= OnGameMode;
    }

    void Start(){
        duration = targetHeightGame / speedWaterLevelGame;
        duration += 2f;
        startposition = waterLevel.transform.position;
        targetposition = new Vector3(startposition.x, startposition.y + targetHeightGame, startposition.z);
                tube.transform.position = (Vector2)targetposition + new Vector2(0, -gap_tube_water);


        if(TutorialManager.Instance && TutorialManager.Instance.CheckEnableTutorial()){
            TutorialManager.Instance.ShowTutorial();
        }
        modifier = true;
    }
    bool modifier;
    float speedMultiple = 1f;
    void Update(){
        if(!gameManager.isStarted) return;

        elapsedTime+= Time.deltaTime * speedMultiple;
        waterLevel.transform.position= Vector3.Lerp(startposition, targetposition , elapsedTime / duration);

        if(elapsedTime >= duration / 2 && modifier){
            modifier  = false;
            GameMode("speed-up");
        }

        if(waterLevel.transform.position == targetposition){
            GameEnd("time");
        }        
    }
    
    public void GameEnd(string code){
        if(onGameEnd != null){
            onGameEnd.Invoke(code);
            onGameEnd = null;
        }
    }

     public void GameMode(string code){
        if(onGameMode != null){
            onGameMode.Invoke(code);
        }
    }
    
    void OnGameMode(string code){
        switch(code){
            case "speed-up":
                speedMultiple = 2f;
            break;
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
            //LevelManager.Instance.ResetLevel();
            SceneGameManager.Instance.GoToBoot();
        }else{
            LevelManager.Instance.SetLevel();
		    SceneGameManager.Instance.GoToGame();
        }
        
    }
    
}
