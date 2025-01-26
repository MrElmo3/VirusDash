using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class buttonmanager : MonoBehaviour
{


    public GameObject canvas1; // Canvas que quieres ocultar
    public GameObject canvas2; // Canvas que quieres mostrar


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

    public void gotomainmenu()
    {
        if (canvas1 != null && canvas2 != null)
        {
            canvas1.SetActive(true); // Oculta el Canvas 1
            canvas2.SetActive(false);  // Muestra el Canvas 2
        }
        else
        {
            Debug.LogWarning("Canvas no asignados en el inspector.");
        }
    }

    public void quit()
    {
       SceneGameManager.Instance.GoQuit();
    }
}
