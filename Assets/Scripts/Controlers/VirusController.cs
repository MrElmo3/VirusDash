using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour {

    [SerializeField] private float JumpForce;
    [SerializeField] private bool isInBubble;
    
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartJump() {
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        rb.gravityScale = 1;
    }

    private void ActionInBubble() {
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bubble")) {
            isInBubble = true;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            transform.position = other.transform.position;
            ActionInBubble();
        }
    }
}
