using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumstickControl : MonoBehaviour
{

    //   private Vector3 mousePosition;
    //   private Rigidbody rb;
    //   private Vector3 direction;
    //   private float moveSpeed = 100f;

    //void Start ()
    //   {
    //       rb = GetComponent<Rigidbody>();
    //   }

    //void Update ()
    //   {
    //       if(Input.GetMouseButton(0))
    //       {
    //           mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    //           direction = (mousePosition - transform.position).normalized;
    //           rb.velocity = new Vector3(direction.x * moveSpeed, direction.y * moveSpeed, direction.y * moveSpeed);
    //       }
    //       else
    //       {
    //           rb.velocity = Vector3.zero;
    //       }
    //   }

    public float speed = 10f;
    public Vector3 targetPos;
    public bool isMoving;
    const int MOUSE = 0;
    // Use this for initialization1
    void Start()
    {

        targetPos = transform.position;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(MOUSE))
        {
            SetTarggetPosition();
        }
        if (isMoving)
        {
            MoveObject();
        }
    }
    void SetTarggetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPos = ray.GetPoint(point);

        isMoving = true;
    }
    void MoveObject()
    {
        transform.LookAt(targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
            isMoving = false;
        Debug.DrawLine(transform.position, targetPos, Color.red);

    }
}
