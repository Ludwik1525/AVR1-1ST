using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearsPassing : MonoBehaviour
{
    public GameObject sunLocation;
    public float speed;

	void Start () {
		
	}
	
	void Update () {
        transform.RotateAround(sunLocation.transform.position, sunLocation.transform.up, speed * Time.deltaTime);
    }
}
