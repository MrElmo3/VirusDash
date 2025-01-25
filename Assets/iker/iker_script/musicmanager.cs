using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicmanager : MonoBehaviour
{
    [SerializeField] AudioSource musicsource;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        musicsource.Play();
    }

  
}
