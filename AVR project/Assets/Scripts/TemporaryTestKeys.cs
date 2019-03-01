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
    public GameObject drumstick;
    private int count0 = 0;
    private int count1 = 0;
    private int count2 = 0;
    private int count3 = 0;
    private int count4 = 0;

    void Start ()
    {

    }
	
	void Update () {

        if(drumstick.gameObject.tag=="Active")
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                source.PlayOneShot(key0lowestClip);
                count0++;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                source.PlayOneShot(key1Clip);
                count1++;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                source.PlayOneShot(key2Clip);
                count2++;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                source.PlayOneShot(key3Clip);
                count3++;
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                source.PlayOneShot(key4highestClip);
                count4++;
            }

            Debug.Log("K0: " + count0 + " " + "K1: " + count1 + " " + "K2: " + count2 + " " + "K3: " + count3 + " " +
                      "K4: " + count4 + "   " + "AVERAGE: " + CountAverage(count0, count1, count2, count3, count4));
        }
    }

    float CountAverage(int k0, int k1, int k2, int k3, int k4)
    {
        float result = 1f*(k0 + 2 * k1 + 3 * k2 + 4 * k3 + 5 * k4) / (k0 + k1 + k2 + k3 + k4);
        return result;
    }
}
