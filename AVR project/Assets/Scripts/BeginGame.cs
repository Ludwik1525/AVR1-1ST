using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginGame : MonoBehaviour
{

    public Text keyInformation;
    private bool wasPressed = false;
    public GameObject drumstick;
    private bool spawnObject = false;
    public GameObject highToneStar;
    public GameObject middleToneStar;
    public GameObject lowToneStar;
    private float average;


    void Start ()
    {
        drumstick.gameObject.tag = "Inactive";
        lowToneStar.gameObject.SetActive(false);
        middleToneStar.gameObject.SetActive(false);
        highToneStar.gameObject.SetActive(false);
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && !wasPressed)
        {
            keyInformation.gameObject.SetActive(false);
            StartCoroutine(Counter(30, GetComponent<Text>()));
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
	}

    public IEnumerator Counter(float t, Text i)
    {
        while (int.Parse(i.text) > 0)
        {
            i.text = "" + (int.Parse(i.text) - 1);
            if (int.Parse(i.text) < 6)
            {
                i.color = new Color(1, 0.2f, 0.2f, 1);
            }
            if (int.Parse(i.text) == 0)
            {
                spawnObject = true;
            }


            yield return new WaitForSeconds(1);
        }
    }
}
