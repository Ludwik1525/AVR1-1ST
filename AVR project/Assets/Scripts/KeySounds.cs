using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySounds : MonoBehaviour {


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
    public AudioSource key0source;
    public AudioSource key1source;
    public AudioSource key2source;
    public AudioSource key3source;
    public AudioSource key4source;
    public GameObject drumstick;

    void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (drumstick.gameObject.tag == "Active")
        {
            if (col == key0lowest)
            {
                key0source.PlayOneShot(key0lowestClip);
            }

            if (col == key1)
            {
                key1source.PlayOneShot(key1Clip);
            }

            if (col == key2)
            {
                key2source.PlayOneShot(key2Clip);
            }

            if (col == key3)
            {
                key3source.PlayOneShot(key3Clip);
            }

            if (col == key4highest)
            {
                key4source.PlayOneShot(key4highestClip);
            }
        }
        
    }
}
