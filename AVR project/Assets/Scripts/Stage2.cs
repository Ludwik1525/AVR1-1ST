using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2 : MonoBehaviour {

    public Text keyInformation;
    public Text counter;
    private bool wasPressed = false;
    public GameObject drumstick;
    private bool spawnObject = false;
    private float average;
    private bool moveCam;
    private bool stageDone = false;
    public bool nextReady = false;
    private bool isPlaying = false;
    public GameObject rockPlanet;
    public GameObject gasPlanet;

    private Stage1 stage1;

    private AverageCalc averageCalc;


    void Start()
    {
        rockPlanet.gameObject.SetActive(false);
        gasPlanet.gameObject.SetActive(false);
        stage1 = GetComponent<Stage1>();
        averageCalc = drumstick.GetComponent<AverageCalc>();
    }

    void Update()
    {
        if(!nextReady)

        {
            average = averageCalc.average;

            if (stage1.nextReady)
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !wasPressed)
                {
                    keyInformation.gameObject.SetActive(false);
                    StartCoroutine(Counter(30, counter.GetComponent<Text>()));
                    wasPressed = true;
                    drumstick.gameObject.tag = "Active";
                }

                if (spawnObject)
                {
                    if (average < 2.5)
                    {
                        rockPlanet.gameObject.SetActive(true);
                    }
                    else
                    {
                        gasPlanet.gameObject.SetActive(true);
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
    }

    public IEnumerator Counter(float t, Text i)
    {
        while (int.Parse(i.text) > 0)
        {
            if (int.Parse(i.text) > 0)
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
