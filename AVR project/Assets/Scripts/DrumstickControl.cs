using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumstickControl : MonoBehaviour
{

    private Vector3 mousePosition;
    private Rigidbody rb;
    private Vector3 direction;
    private float moveSpeed = 100f;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        if(Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector3(direction.x * moveSpeed, direction.y * moveSpeed, direction.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
