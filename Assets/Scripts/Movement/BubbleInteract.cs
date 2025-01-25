using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BubbleInteract : MonoBehaviour
{
    public float force = 10f;
        private Rigidbody2D rb;
public float angle = 45f;     
public ArrowFollow arrowFollow;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }
    public bool is_jumping;
    public LayerMask collisionLayer;
    // Update is called once per frame
    void Update()
    {
        if(!is_jumping && Input.GetMouseButtonDown(0)){
            float radiands = Mathf.Deg2Rad * angle;
            Vector3 direction = new Vector3(Mathf.Sin(radiands),0f,Mathf.Cos(radiands));
            rb.AddForce(direction * force, ForceMode2D.Impulse);
            
            is_jumping = true;
        }
    }
}
