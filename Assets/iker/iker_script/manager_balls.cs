using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BolaManager : MonoBehaviour
{
    public static BolaManager Instance{ get;set;}
  

    [Header("Variables only for testing")]
    public float countBallsTest = 50f;

    [Header("References")]
    
    public GameObject ballPrefab;
    public Transform ballContainer;
    public GameObject limit_left, limit_right;


    public List<GameObject> bolas = new List<GameObject>();
    public float tiempoEntreBolas = 2f; // Tiempo entre cada bola que se vuelve visible
    public float minDistance, maxDistance;
    private float countBallsGame;
    private float spaceHeightGame;
    private float initSpace = 5f;
    void Awake(){
         if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if(!LevelManager.Instance){
            spaceHeightGame = 20-initSpace;
            countBallsGame = countBallsTest;
        }
        else{
            LevelManager.LevelDTO level = LevelManager.Instance.GetCurrentLevelDTO();
            countBallsGame = level.enemiesCount;
            spaceHeightGame = level.heightTube - initSpace;
        }
    }
    void Start()
    {
        
        SpawnBubbles();
    }
    void SpawnBubbles(){
        float _currentHeight = 0f;
        float _spaceHeight = GameLogic.Instance.TargetHeightGame;
        int _bubbleCount = 0;

        while(_bubbleCount < countBallsGame || _currentHeight < _spaceHeight){
            float randomHeight = Random.Range(minDistance,maxDistance);
            float random_x = UnityEngine.Random.Range( limit_left.transform.position.x ,limit_right.transform.position.x  );
            if(_currentHeight + randomHeight > _spaceHeight && _bubbleCount >= 5){
                break;
            }
            Vector2 _position = new Vector2(random_x, initSpace + _currentHeight);
            GameObject b = Instantiate(ballPrefab, ballContainer);
            _currentHeight+= randomHeight;
            _bubbleCount++;
            bolas.Add(b);
            b.transform.SetParent(ballContainer);
            b.gameObject.SetActive(false);
        }
    }
    [SerializeField]int index = 0; 
    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)) {
            NextVisible();
        }
    }
    public void NextVisible()
    {
        index++;
        if(index >= 2){
            for (int i = 0; i < bolas.Count; i++)
            {
                if (!bolas[i].activeSelf) // Si la bola no está activa
                {
                    bolas[i].SetActive(true); // La hace visible
                    break; // Sale del bucle después de hacer visible la bola
                }
            }
        }

        
    }
}
