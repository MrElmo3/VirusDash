using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCutAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(EndCutAnimation),2.5f);
    }


    void EndCutAnimation(){
        SceneGameManager.Instance.GoToGame();
    }
}
