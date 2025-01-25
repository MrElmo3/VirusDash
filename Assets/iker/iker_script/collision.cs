using UnityEngine;

public class StaticOnCollision : MonoBehaviour
{
    // Este es el objeto que quieres que se quede estático
    public GameObject objectToFreeze;
    private Rigidbody2D rb2d;
    private Collider2D col2d;

    void Start()
    {
        // Obtenemos el Rigidbody2D y el Collider2D del objeto
        if (objectToFreeze != null)
        {
            rb2d = objectToFreeze.GetComponent<Rigidbody2D>();
            col2d = objectToFreeze.GetComponent<Collider2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Hola"))
        {
            FreezeObject();
        }
    }

    void FreezeObject()
    {
        // Congela el movimiento y la rotación del objeto
        if (rb2d != null)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        // Si también quieres deshabilitar la colisión (opcional)
        if (col2d != null)
        {
            col2d.enabled = false;  // Desactiva el Collider2D si no quieres que siga detectando colisiones
        }
    }
}