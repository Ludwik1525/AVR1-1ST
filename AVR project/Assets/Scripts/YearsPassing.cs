using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearsPassing : MonoBehaviour
{
    public GameObject sunLocation;
    public float mass;
    private float speed;
    private PlanetSpawner planetSpawner;
    private float distanceToSun;

    void Start ()
    {
        planetSpawner = GetComponent<PlanetSpawner>();
        distanceToSun = Vector3.Distance(sunLocation.gameObject.transform.position, this.transform.position);
    }
	
	void Update () {
        transform.RotateAround(sunLocation.transform.position, sunLocation.transform.up, speed * Time.deltaTime);
        speed = 150000/(mass * distanceToSun);
    }
}
