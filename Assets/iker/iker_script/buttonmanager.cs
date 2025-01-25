using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonmanager : MonoBehaviour
{


    public Canvas canvas1; // Canvas que quieres ocultar
    public Canvas canvas2; // Canvas que quieres mostrar


    public void playgame()
    {
        SceneManager.LoadSceneAsync("iker_scene");
    }


    public void gotocredits()
    {
        if (canvas1 != null && canvas2 != null)
        {
            canvas1.gameObject.SetActive(false); // Oculta el Canvas 1
            canvas2.gameObject.SetActive(true);  // Muestra el Canvas 2
        }
        else
        {
            Debug.LogWarning("Canvas no asignados en el inspector.");
        }
    }

    public void gotomainmenu()
    {
        if (canvas1 != null && canvas2 != null)
        {
            canvas1.gameObject.SetActive(true); // Oculta el Canvas 1
            canvas2.gameObject.SetActive(false);  // Muestra el Canvas 2
        }
        else
        {
            Debug.LogWarning("Canvas no asignados en el inspector.");
        }
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit()
    {
        Debug.Log("adios");
        Application.Quit();
    }
}
