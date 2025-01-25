using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] int segundosTotales; // Ingresar solo segundos aquí
    [SerializeField] TextMeshProUGUI tiempo;

    private float restante;
    private bool enMarcha;

    private void Awake()
    {
        restante = segundosTotales;
        enMarcha = true;
    }

    void Update()
    {
        if (enMarcha)
        {
            restante -= Time.deltaTime;
            if (restante <= 0)
            {
                enMarcha = false;
                restante = 0;
                // Acción cuando el tiempo se acabe
                Debug.Log("¡Tiempo agotado!");
            }

            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{0:00}:{1:00}", tempMin, tempSeg);
        }
    }
}
