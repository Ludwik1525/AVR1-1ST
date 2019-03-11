using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlanetSpawner : MonoBehaviour {

    public Text keyInformation;
    public Text counter;
    public Text error;
    [FormerlySerializedAs("drumstick")] public GameObject ball;
    private float average;
    private bool wasPressed = false;
    private bool spawnObject = false;
    public bool planetSpawned = false;

    private Stage1 stage1;
    private AverageCalc averageCalc;

    public float spawnDistance = 50;
    private Quaternion playerRotation;
    public Vector3 spawnPos;
    public Transform CameraTransform;

    public GameObject lowestTonePlanet;
    public GameObject lowTonePlanet;
    public GameObject smallTonePlanet;
    public GameObject middleMinusTonePlanet;
    public GameObject middleTonePlanet;
    public GameObject middlePlusTonePlanet;
    public GameObject bigTonePlanet;
    public GameObject highTonePlanet;
    public GameObject highestTonePlanet;
    public GameObject Asteroids;

    void Start()
    {
        stage1 = GetComponent<Stage1>();
        error.gameObject.SetActive(false);
        averageCalc = ball.GetComponent<AverageCalc>();
    }

    void Update()
    {
            average = averageCalc.average;
            spawnPos = this.transform.position + CameraTransform.forward * spawnDistance;
            playerRotation = this.transform.rotation;

            if (stage1.nextReady)
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !wasPressed)
                {
                    /*if (Physics.CheckSphere(spawnPos, 30))
                    {
                        error.gameObject.SetActive(true);
                    }
                    else
                    {*/
                        error.gameObject.SetActive(false);
                        keyInformation.gameObject.SetActive(false);
                        StartCoroutine(Counter(20, counter.GetComponent<Text>()));
                        wasPressed = true;
                        ball.gameObject.tag = "Active";
                        this.gameObject.tag = "Immovable";
                    //}
                }

                if (spawnObject)
                {
                    if (average < 0.8f)
                    {
                        Instantiate(lowestTonePlanet, spawnPos, playerRotation);
                }
                    else if (average < 1.1f)
                    {
                        Instantiate(Asteroids, spawnPos, playerRotation);
                    }
                else if (average < 1.4f)
                    {
                        Instantiate(lowTonePlanet, spawnPos, playerRotation);
                }
                    else if (average < 1.5f)
                    {
                        Instantiate(Asteroids, spawnPos, playerRotation);
                    }
                else if (average < 1.8f)
                    {
                        Instantiate(smallTonePlanet, spawnPos, playerRotation);
                    }
                    else if (average < 2.4f)
                    {
                        Instantiate(middleMinusTonePlanet, spawnPos, playerRotation);
                }
                    else if (average < 2.6f)
                    {
                        Instantiate(Asteroids, spawnPos, playerRotation);
                    }
                else if (average < 2.8f)
                    {
                        Instantiate(middleTonePlanet, spawnPos, playerRotation);
                }
                    else if (average < 3.3f)
                    {
                        Instantiate(middlePlusTonePlanet, spawnPos, playerRotation);
                }
                    else if (average < 3.5f)
                    {
                        Instantiate(Asteroids, spawnPos, playerRotation);
                    }
                else if (average < 3.8f)
                    {
                        Instantiate(bigTonePlanet, spawnPos, playerRotation);
                }
                    else if (average < 4.4f)
                    {
                        Instantiate(highTonePlanet, spawnPos, playerRotation);
                }
                    else
                    {
                        Instantiate(highestTonePlanet, spawnPos, playerRotation);
                }
                }

                if (planetSpawned)
                {
                    StopAllCoroutines();
                    keyInformation.gameObject.SetActive(true);
                    counter.GetComponent<Text>().text = "" + 20;
                    counter.GetComponent<Text>().color = new Color(1255, 255, 255, 1);

                    averageCalc.count0 = 0;
                    averageCalc.count1 = 0;
                    averageCalc.count2 = 0;
                    averageCalc.count3 = 0;
                    averageCalc.count4 = 0;
                    averageCalc.sub0 = false;
                    averageCalc.sub1 = false;
                    averageCalc.sub2 = false;

                    ball.gameObject.tag = "Inactive";
                    this.gameObject.tag = "Movable";

                    wasPressed = false;
                    spawnObject = false;
                    planetSpawned = false;
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
                planetSpawned = true;
            }

            yield return new WaitForSeconds(1);
        }
    }
}
