using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageCalc : MonoBehaviour {
    
    public GameObject drumstick;
    public float count0 = 0;
    public float count1 = 0;
    public float count2 = 0;
    public float count3 = 0;
    public float count4 = 0;
    public float average = 0;
    public bool startedCoroutine = false;
    public bool first = false;
    public bool second = false;
    public bool third = false;
    public bool sub0 = false;
    public bool sub1 = false;
    public bool sub2 = false;

    void Start () {
		
	}
	
	void Update () {
	}

    void OnTriggerEnter(Collider col)
    {
        if (drumstick.gameObject.tag == "Active")
        {
            if (!startedCoroutine)
            {
                StartCoroutine(Counter(30));
                this.startedCoroutine = true;
            }
        }
        else
        {
            StopAllCoroutines();
            this.startedCoroutine = false;
        }

        CountAverage(this.count0, this.count1, this.count2, this.count3, count4);
    }

    float CountAverage(float k0, float k1, float k2, float k3, float k4)
    {
        int temp = 0;
        float result = 0;
        if (this.sub2)
        {
            k0 = k0 * 10;
            k1 = k1 * 5;
            k3 = 0.5f * k3;
            k4 = 0;
        }
        else if (sub1)
        {
            k0 = k0 * 5;
            k1 = k1 * 1.5f;
            k3 = 0.8f * k3;
            k4 = 0.5f * k4;
        }
        else if (sub0)
        {
            k0 = k0 * 2;
            k1 = k1 * 1.1f;
            k3 = 0.9f * k3;
            k4 = 0.8f * k4;
        }

        if (k0 == 0 && k1 == 0 && k2 == 0 && k3 == 0 && k4 == 0)
        {
            temp = 1;
        }
        if (1f * (1f * (k0 + 2f * k1 + 3 * k2 + 4 * k3 + 5 * k4) / ((k0 + k1 + k2 + k3 + k4) + temp)) < 0)
        {
            result = 0;
            return result;
        }
        else
        {
            result = 1f * (1f * (k0 + 2f * k1 + 3 * k2 + 4 * k3 + 5 * k4) / ((k0 + k1 + k2 + k3 + k4) + temp));
            average = result;
            return result;
        }
    }

    public IEnumerator Counter(int sec)
    {

        while (sec > 0)
        {
            sec--;
            if (third)
            {
                if (!this.sub0)
                {
                    this.sub0 = true;
                }
                else if (!this.sub1)
                {
                    this.sub1 = true;
                }
                else
                {
                    this.sub2 = true;
                }
                third = false;
                second = false;
                first = false;
            }
            if (second)
            {
                third = true;
            }
            if (first)
            {
                second = true;
            }
            first = true;
            yield return new WaitForSeconds(1);
        }

    }
}
