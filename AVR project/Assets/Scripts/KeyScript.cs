using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public AudioClip keyClip;

    public GameObject drumstick;

    private AudioSource audioSource;

    public int keyNumber;
    
    private AverageCalc averageCalc;
    
   


    void Start()
    {
        this.averageCalc = drumstick.GetComponent<AverageCalc>();
        this.audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (drumstick.gameObject.tag == "Active")
        {
            this.audioSource.PlayOneShot(this.keyClip);
            this.averageCalc.Increment(this.keyNumber);

            this.averageCalc.first = false;
            this.averageCalc.second = false;
            this.averageCalc.third = false;
        }
    }
}
