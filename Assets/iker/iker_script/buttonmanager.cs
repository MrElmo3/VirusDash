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
            SceneGameManager.Instance.GoToTutorial();
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
