using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFollow : MonoBehaviour
{
    public float speedRotation = 100f;
    public SpriteRenderer sr;
    public float current_angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

        Vector3 positionMouse = Input.mousePosition;
        positionMouse.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(positionMouse);
        Vector3 direction  = worldMousePosition - transform.position;
        current_angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,current_angle));

    }
}
