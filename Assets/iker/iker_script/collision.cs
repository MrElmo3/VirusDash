using UnityEngine;

public class StaticOnCollision : MonoBehaviour
{
    // Este es el objeto que quieres que se quede estático
    public GameObject objectToFreeze;
    private Rigidbody2D rb2d;

    void Start()
    {
        // Obtenemos el Rigidbody2D del objeto
        if (objectToFreeze != null)
        {
            rb2d = objectToFreeze.GetComponent<Rigidbody2D>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Bola"))
        {
            FreezeObject();
        }
    }

    void FreezeObject()
    {
        // Desactivamos la gravedad y bloqueamos la velocidad
        if (rb2d != null)
        {
            rb2d.gravityScale = 0;   // Desactivamos la gravedad
            rb2d.velocity = Vector2.zero;  // Detenemos cualquier movimiento inmediato (velocidad)
            rb2d.angularVelocity = 0f;  // Detenemos cualquier rotación
            rb2d.isKinematic = true;  // Bloqueamos la física del objeto para que no se mueva

            // Añadimos un control adicional para asegurarnos de que no haya fuerzas aplicadas al objeto
            rb2d.drag = Mathf.Infinity;  // Aplicamos una resistencia infinita para que no se desplace
            rb2d.angularDrag = Mathf.Infinity; // Detenemos cualquier rotación inducida por fuerzas
        }

        // Asegúrate de que la gravedad global también se desactive si es necesario
        Physics2D.gravity = Vector2.zero; // Desactiva la gravedad globalmente durante la congelación
    }

    // Método para restaurar la gravedad y permitir el movimiento nuevamente
    public void RestoreObject()
    {
        if (rb2d != null)
        {
            rb2d.gravityScale = 1;   // Restauramos la gravedad individual (ajusta según necesites)
            rb2d.isKinematic = false;  // Restauramos la física normal del objeto

            // Restauramos la resistencia física a valores normales
            rb2d.drag = 0;  // Restablecemos la resistencia a cero
            rb2d.angularDrag = 0;  // Restablecemos la resistencia angular
        }

        // Restauramos la gravedad global si fue desactivada
        Physics2D.gravity = new Vector2(0, -9.81f); // Restauramos la gravedad global a la normal
    }
}
