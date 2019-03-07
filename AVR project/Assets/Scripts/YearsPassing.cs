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
    private float sunMass;

    void Start ()
    {
        planetSpawner = GetComponent<PlanetSpawner>();
        distanceToSun = Vector3.Distance(sunLocation.gameObject.transform.position, this.transform.position);
        switch (GameObject.FindGameObjectWithTag("Star").name)
        {
            case "LowestToneStar":
                sunMass = 2;
                break;
            case "LowToneStar":
                sunMass = 4;
                break;
            case "MiddleToneStar":
                sunMass = 6;
                break;
            case "BigToneStar":
                sunMass = 10;
                break;
            case "HighToneStar":
                sunMass = 14;
                break;
            default:
                sunMass = 1;
                break;
        }
    }
	
	void Update () {
        transform.RotateAround(sunLocation.transform.position, sunLocation.transform.up, speed * Time.deltaTime);
        speed = sunMass*(15000/(mass * distanceToSun));
    }
}
