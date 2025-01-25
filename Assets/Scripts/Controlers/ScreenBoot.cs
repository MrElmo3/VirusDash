using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneGameManager.Instance.GoToMainMenu();
    }
       
}
