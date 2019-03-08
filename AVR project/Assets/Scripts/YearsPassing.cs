using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearsPassing : MonoBehaviour
{
    public float mass;
    private float speed;
    private float distanceToSun;
    private float sunMass;
    private Vector3 sunLocation;

    void Start ()
    {
        sunLocation = new Vector3(0, 0, -440);
        distanceToSun = Vector3.Distance(sunLocation, this.transform.position);
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
        transform.RotateAround(sunLocation, new Vector3(0, 1, 0), speed * Time.deltaTime);
        speed = sunMass*(80000/(mass * distanceToSun));
    }
}
