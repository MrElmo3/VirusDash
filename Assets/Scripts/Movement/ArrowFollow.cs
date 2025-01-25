using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFollow : MonoBehaviour
{
    public float speedRotation = 100f;
    public SpriteRenderer sr;
    public float current_angle;
    private bool is_active;
    public int is_left;
    // Start is called before the first frame update
    void Start()
    {
        EnableArrow();
        is_left = -1;
    }
    
    public void SetSideway(int value){
        this.is_left = value;
    }
    
    void EnableArrow(){
        is_active = true;
        sr.gameObject.SetActive(true);
    }
    void DisableArrow(){
        current_angle = 0;
        is_active = false;
        sr.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!is_active) return;
       
        current_angle += speedRotation*Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0,0,current_angle- 90f));
    }

    float directionToAngle( Vector3 direction){
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ;
    }

    
}
