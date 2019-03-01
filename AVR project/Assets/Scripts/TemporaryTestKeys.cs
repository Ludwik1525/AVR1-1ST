using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryTestKeys : MonoBehaviour {

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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            source.PlayOneShot(key0lowestClip);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            source.PlayOneShot(key1Clip);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            source.PlayOneShot(key2Clip);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            source.PlayOneShot(key3Clip);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            source.PlayOneShot(key4highestClip);
        }
    }
}
