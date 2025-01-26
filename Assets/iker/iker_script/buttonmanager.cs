using System.Collections;
using System.Collections.Generic;

using UnityEngine;
//supuestamente es el script del main menu xd
public class buttonmanager : MonoBehaviour
{


    public GameObject canvas1; 

    void Awake(){
         audioManager.instance.PlayBGM("music-menu");
    }

    public void OnClick(){
        audioManager.instance.Play("click-1");
    }

    public void playgame()
    {
        if(LevelManager.Instance.GetLevel()== 0)
            SceneGameManager.Instance.GoToTutorial();
        else
            SceneGameManager.Instance.GoToGame();
    }


    public void gotocredits()
    {
       SceneGameManager.Instance.GoToCredits();
    }


    public void quit()
    {
       SceneGameManager.Instance.GoQuit();
    }
}
