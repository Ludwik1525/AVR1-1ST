using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using InputTracking = UnityEngine.XR.InputTracking;
using Node = UnityEngine.XR.XRNode;
using Settings = UnityEngine.XR.XRSettings;

public class Stage1 : MonoBehaviour
{

    public Text keyInformation;
    public Text counter;
    private bool wasPressed = false;
    [FormerlySerializedAs("ball")] public GameObject ball;
    private bool spawnObject = false;
    public GameObject highToneStar;
    public GameObject bigToneStar;
    public GameObject middleToneStar;
    public GameObject lowToneStar;
    public GameObject lowestToneStar;
    private float average;
    private bool stageDone=false;
    public bool nextReady = false;


    void Start ()
    {
        this.gameObject.tag = "Immovable";
        ball.gameObject.tag = "Inactive";
        lowestToneStar.gameObject.SetActive(false);
        lowToneStar.gameObject.SetActive(false);
        middleToneStar.gameObject.SetActive(false);
        bigToneStar.gameObject.SetActive(false);
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
                ball.gameObject.tag = "Active";
            }

            AverageCalc averageCalc = ball.GetComponent<AverageCalc>();
            average = averageCalc.average;

            if (spawnObject)
            {
                if (average < 1.1)
                {
                    lowestToneStar.gameObject.SetActive(true);
                }
                else if (average <2)
                {
                    lowToneStar.gameObject.SetActive(true);
                }
                if (average < 3)
                {
                    middleToneStar.gameObject.SetActive(true);
                }
                else if (average < 4)
                {
                    bigToneStar.gameObject.SetActive(true);
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
                ball.gameObject.tag = "Inactive";
                counter.GetComponent<Text>().text = "" + 30;
                counter.GetComponent<Text>().color = new Color(1255, 255, 255, 1);
                this.gameObject.tag = "Movable";
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
