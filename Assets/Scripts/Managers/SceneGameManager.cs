using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
    using UnityEditor;
#endif  

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
    public void GoToMainMenu(){
         ChangeScene("MainMenu");
    }
    public void GoToGame(){
         ChangeScene("Gameplay");
    }
    public void GoToCredits(){
         ChangeScene("Credits");
    } 
    public void GoToBoot(){
         ChangeScene("Boot");
    }
    public void GoToTutorial(){
        //"tutoria" is scene animation
         ChangeScene("CutAnimation");
    }
    public void GoQuit(){
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
       #else
            Application.Quit();
       #endif
    }
}
