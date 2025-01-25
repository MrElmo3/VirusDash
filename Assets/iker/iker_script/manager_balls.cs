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


    void Awake(){
         if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if(!LevelManager.Instance){
            countBallsGame = countBallsTest;
        }
        else{
            LevelManager.LevelDTO level = LevelManager.Instance.GetCurrentLevelDTO();
            countBallsGame = level.enemiesCount;
          
        }
    }
    void Start()
    {
        int i = 0;
        float acumulative = 4f;
        Vector3 newPos = new Vector3(2,4); 
//        bool isLeft = true;
        for (i = 0; i < countBallsGame; i++){
            float random_x = UnityEngine.Random.Range( limit_left.transform.position.x ,limit_right.transform.position.x  );
            float random_y = UnityEngine.Random.Range(minDistance,maxDistance);
            acumulative+= random_y;
  //          isLeft=!isLeft;
            GameObject b = Instantiate(ballPrefab, new Vector3(random_x,acumulative), Quaternion.identity);

            b.transform.SetParent(ballContainer);
            bolas.Add(b);
       }     

     
        for (i = 2; i < bolas.Count; i++)
        {
            bolas[i].SetActive(false);
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
