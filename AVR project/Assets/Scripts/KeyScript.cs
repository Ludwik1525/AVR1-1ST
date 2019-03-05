using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

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

    public GameObject drumstick;

    public AudioSource audioSource;
    
    private AverageCalc averageCalc;
    
   


    void Start()
    {
        this.averageCalc = drumstick.GetComponent<AverageCalc>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (drumstick.gameObject.tag == "Active")
        {
            if (this.gameObject == this.key0lowest)
            {
                this.audioSource.PlayOneShot(this.key0lowestClip);
                this.averageCalc.count0++;
            }
            if (this.gameObject == this.key1)
            {
                this.audioSource.PlayOneShot(this.key1Clip);
                this.averageCalc.count1++;
            }
            if (this.gameObject == this.key2)
            {
                this.audioSource.PlayOneShot(this.key2Clip);
                this.averageCalc.count2++;
            }
            if (this.gameObject == this.key3)
            {
                this.audioSource.PlayOneShot(this.key3Clip);
                this.averageCalc.count3++;
            }
            if (this.gameObject == this.key4highest)
            {
                this.audioSource.PlayOneShot(this.key4highestClip);
                this.averageCalc.count4++;
            }
            this.averageCalc.first = false;
            this.averageCalc.second = false;
            this.averageCalc.third = false;
        }
    }
}
