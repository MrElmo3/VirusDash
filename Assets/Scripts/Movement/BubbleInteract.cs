using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BubbleInteract : MonoBehaviour
{
    public float force = 10f;
        private Rigidbody2D rb;
     
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
            rb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}
