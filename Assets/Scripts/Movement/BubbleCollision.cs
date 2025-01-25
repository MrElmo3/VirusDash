using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public ArrowFollow arrowFollow;
    private BubbleInteract interact;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        interact= GetComponent<BubbleInteract>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        interact.is_jumping = false;
        if(collision.gameObject.tag == "left"){
            arrowFollow.SetSideway(1);
        }else if(collision.gameObject.tag == "down")
            arrowFollow.SetSideway(-1);
        else{
            arrowFollow.SetSideway(0);
        }
    }
}
