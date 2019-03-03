using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            if (Input.GetKeyDown(KeyCode.Space) && !wasPressed)
            {
                keyInformation.gameObject.SetActive(false);
                StartCoroutine(Counter(30, counter.GetComponent<Text>()));
                wasPressed = true;
                drumstick.gameObject.tag = "Active";
            }

            //KeyTriggers keyTriggers = drumstick.GetComponent<KeyTriggers>();
            TemporaryTestKeys keyTriggers = drumstick.GetComponent<TemporaryTestKeys>();
            average = keyTriggers.average;

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
                keyTriggers.count0 = 0;
                keyTriggers.count1 = 0;
                keyTriggers.count2 = 0;
                keyTriggers.count3 = 0;
                keyTriggers.count4 = 0;
                keyTriggers.sub0 = false;
                keyTriggers.sub1 = false;
                keyTriggers.sub2 = false;
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
