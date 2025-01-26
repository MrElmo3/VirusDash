using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCredits : MonoBehaviour
{
    
    public void GoToGame(){
        SceneGameManager.Instance.GoToMainMenu();
    }
}
