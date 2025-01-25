using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class VirusController : MonoBehaviour {

    [SerializeField] private float JumpForce;
    [SerializeField] private bool isInBubble;
    [SerializeField] private GameObject Bubble;

    [SerializeField] private GameObject Arrow;
    
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartJump() {
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        rb.gravityScale = 1;
    }

    private void Update() {
        if(!isInBubble) return;

        transform.position = Bubble.transform.position + new Vector3(0, 0, -1);

        ShowArrow();

        if(Input.GetKeyDown(KeyCode.Space)) {
           ActionInBubble();
        }
    }

    private void ShowArrow() {
        Arrow.SetActive(true);
        Arrow.GetComponent<ArrowController>().MoveArrow();
    }

    private void ActionInBubble() {
        Arrow.SetActive(false);
        rb.gravityScale = 1;
        isInBubble = false;
        float radiands = Mathf.Deg2Rad * Arrow.transform.rotation.eulerAngles.z;
        Vector2 direction = new Vector2(Mathf.Cos(radiands), Mathf.Sin(radiands));

        rb.AddForce(direction * JumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bubble")) {
            BolaManager.Instance.NextVisible();
            Bubble = other.gameObject;
            isInBubble = true;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }else if(other.CompareTag("water")){
            GameLogic.Instance.GameEnd("water");
        }else if(other.CompareTag("win")){
            GameLogic.Instance.GameEnd("win");
        }

    }
}
