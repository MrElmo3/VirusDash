using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCredits : MonoBehaviour
{
    void Start(){
        if(audioManager.instance) audioManager.instance.Play("music-menu");
    }
    public void GoToGame(){
        SceneGameManager.Instance.GoToMainMenu();
    }

     public void OnClick(){
        audioManager.instance.Play("click-1");
    }
}
