using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTriggers : MonoBehaviour {

    public GameObject key0lowest;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4highest;
    public GameObject drumstick;
    private int count0 = 0;
    private int count1 = 0;
    private int count2 = 0;
    private int count3 = 0;
    private int count4 = 0;

    void Start () {
		
	}
	
	void Update () {
        if (drumstick.gameObject.tag == "Active")
        {
           
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (drumstick.gameObject.tag == "Active")
        {
            if (col == key0lowest)
            {
                count0++;
            }

            if (col == key1)
            {
                count1++;
            }

            if (col == key2)
            {
                count2++;
            }

            if (col == key3)
            {
                count3++;
            }

            if (col == key4highest)
            {
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
