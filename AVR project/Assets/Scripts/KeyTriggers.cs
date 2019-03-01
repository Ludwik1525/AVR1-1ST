using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTriggers : MonoBehaviour {


    public GameObject key0lowest;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4highest;
    public AudioClip key0lowestClip;
    public AudioClip key1Clip;
    public AudioClip key2Clip;
    public AudioClip key3Clip;
    public AudioClip key4highestClip;
    public AudioSource source;
    
    void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col == key0lowest)
        {
           source.PlayOneShot(key0lowestClip);
        }

        if (col == key1)
        {
            source.PlayOneShot(key1Clip);
        }

        if (col == key2)
        {
            source.PlayOneShot(key2Clip);
        }

        if (col == key3)
        {
            source.PlayOneShot(key3Clip);
        }

        if (col == key4highest)
        {
            source.PlayOneShot(key4highestClip);
        }
    }
}
