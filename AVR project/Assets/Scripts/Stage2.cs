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
    public Animator anim;
    private bool isPlaying = false;
    public GameObject rockPlanet;
    public GameObject gasPlanet;


    void Start()
    {
        anim = GetComponent<Animator>();
        rockPlanet.gameObject.SetActive(false);
        gasPlanet.gameObject.SetActive(false);
    }

    void Update()
    {
        if(!nextReady)

        {
            //KeyTriggers keyTriggers = drumstick.GetComponent<KeyTriggers>();
            Stage1 stage1 = GetComponent<Stage1>();

            //KeyTriggers keyTriggers = drumstick.GetComponent<KeyTriggers>();
            TemporaryTestKeys keyTriggers = drumstick.GetComponent<TemporaryTestKeys>();
            average = keyTriggers.average;

            if (stage1.nextReady)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !wasPressed)
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
                    keyTriggers.count0 = 0;
                    keyTriggers.count1 = 0;
                    keyTriggers.count2 = 0;
                    keyTriggers.count3 = 0;
                    keyTriggers.count4 = 0;
                    keyInformation.gameObject.SetActive(true);
                    wasPressed = false;
                    drumstick.gameObject.tag = "Inactive";
                    anim.Play("CamMove");
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
