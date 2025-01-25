using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
   public static SceneGameManager Instance{ get;set;}
   
   void Awake()
   {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Awakee();
        DontDestroyOnLoad(gameObject);
   }

    void Awakee(){
    }
    
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    public void GoToUI(){
         ChangeScene("TEST_ui");
    }
        public void GoToGame(){
         ChangeScene("MaxScene");
    }
}
