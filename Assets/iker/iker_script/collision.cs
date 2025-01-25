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
            // Verificar si el objeto está completamente dentro
            if (IsColliderCompletelyInside(collision))
            {
                Debug.Log("El collider está completamente dentro.");
                FreezeObject();
            }
            else
            {
                Debug.Log("El collider no está completamente dentro.");
            }
        }
    }

    void FreezeObject()
    {
        // Congela el movimiento y la rotación del objeto
        if (rb2d != null)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Objeto congelado.");
        }

        // Si también quieres deshabilitar la colisión (opcional)
        if (col2d != null)
        {
            col2d.enabled = false;  // Desactiva el Collider2D si no quieres que siga detectando colisiones
            Debug.Log("Collider deshabilitado.");
        }
    }

    bool IsColliderCompletelyInside(Collider2D other)
    {
        // Verificamos si el collider del objeto está completamente dentro del área del trigger
        var thisBounds = GetComponent<Collider2D>().bounds;
        var otherBounds = other.bounds;

        Debug.Log($"Bounds del Trigger: {thisBounds}");
        Debug.Log($"Bounds del Objecto: {otherBounds}");

        // Comprobamos si los límites del otro collider están completamente dentro del trigger
        return thisBounds.Contains(otherBounds.min) && thisBounds.Contains(otherBounds.max);
    }
}
