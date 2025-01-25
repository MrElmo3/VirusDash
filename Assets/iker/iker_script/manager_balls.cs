using UnityEngine;

public class BolaManager : MonoBehaviour
{
    public GameObject[] bolas; // Array para las 7 bolas
    public float tiempoEntreBolas = 2f; // Tiempo entre cada bola que se vuelve visible

    void Start()
    {
        // Asegura que la primera bola siempre esté visible
        if (bolas.Length > 0)
        {
            bolas[0].SetActive(true); // Hace visible la primera bola desde el inicio
        }

        // Inicializa el resto de bolas como invisibles
        for (int i = 1; i < bolas.Length; i++)
        {
            bolas[i].SetActive(false); // Desactiva las bolas restantes
        }

        // Llama a la función para hacer las bolas visibles una por una cada 2 segundos
        for (int i = 1; i < bolas.Length; i++)
        {
            int index = i; // Necesario para capturar el índice correctamente dentro del bucle
            Invoke(nameof(HacerVisible), tiempoEntreBolas * index); // Llama a HacerVisible para cada bola
        }
    }

    void HacerVisible()
    {
        // Asegura que se hace visible la bola en el índice correcto
        for (int i = 1; i < bolas.Length; i++)
        {
            if (!bolas[i].activeSelf) // Si la bola no está activa
            {
                bolas[i].SetActive(true); // La hace visible
                break; // Sale del bucle después de hacer visible la bola
            }
        }
    }
}
