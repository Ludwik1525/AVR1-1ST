using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InputTracking = UnityEngine.XR.InputTracking;
using Node = UnityEngine.XR.XRNode;
using Settings = UnityEngine.XR.XRSettings;

public class Stage1 : MonoBehaviour
{

    public Text keyInformation;
    public Text counter;
    private bool wasPressed = false;
    public GameObject drumstick;
    private bool spawnObject = false;
    public GameObject highToneStar;
    public GameObject middleToneStar;
    public GameObject lowToneStar;
    private float average;
    private bool stageDone=false;
    public bool nextReady = false;


    void Start ()
    {
        drumstick.gameObject.tag = "Inactive";
        lowToneStar.gameObject.SetActive(false);
        middleToneStar.gameObject.SetActive(false);
        highToneStar.gameObject.SetActive(false);
    }
	
	void Update () {

        if(!nextReady)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !wasPressed)
            {
                keyInformation.gameObject.SetActive(false);
                StartCoroutine(Counter(30, counter.GetComponent<Text>()));
                wasPressed = true;
                drumstick.gameObject.tag = "Active";
            }

            AverageCalc averageCalc = drumstick.GetComponent<AverageCalc>();
            average = averageCalc.average;

            if (spawnObject)
            {
                if (average < 2)
                {
                    lowToneStar.gameObject.SetActive(true);
                }
                else if (average < 4)
                {
                    middleToneStar.gameObject.SetActive(true);
                }
                else
                {
                    highToneStar.gameObject.SetActive(true);
                }
            }

            if (stageDone)
            {
                StopAllCoroutines();
                averageCalc.count0 = 0;
                averageCalc.count1 = 0;
                averageCalc.count2 = 0;
                averageCalc.count3 = 0;
                averageCalc.count4 = 0;
                averageCalc.sub0 = false;
                averageCalc.sub1 = false;
                averageCalc.sub2 = false;
                keyInformation.gameObject.SetActive(true);
                wasPressed = false;
                drumstick.gameObject.tag = "Inactive";
                counter.GetComponent<Text>().text = "" + 30;
                counter.GetComponent<Text>().color = new Color(1255, 255, 255, 1);
                nextReady = true;
            }
        }
	}

    public IEnumerator Counter(float t, Text i)
    {
        while (int.Parse(i.text) > 0)
        {
            if(int.Parse(i.text) > 0)
            {
                i.text = "" + (int.Parse(i.text) - 1);
                if (int.Parse(i.text) < 6)
                {
                    i.color = new Color(1, 0.2f, 0.2f, 1);
                }
            }
            if (int.Parse(i.text) == 0)
            {
                spawnObject = true;
                stageDone = true;
            }

            yield return new WaitForSeconds(1);
        }
    }
}
