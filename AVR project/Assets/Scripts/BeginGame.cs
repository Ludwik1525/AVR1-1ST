using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginGame : MonoBehaviour
{

    public Text keyInformation;
    private bool wasPressed = false;
    public GameObject drumstick;

	void Start ()
    {
        drumstick.gameObject.tag = "Inactive";
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && !wasPressed)
        {
            keyInformation.gameObject.SetActive(false);
            StartCoroutine(Counter(30, GetComponent<Text>()));
            wasPressed = true;
            drumstick.gameObject.tag = "Active";
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
            yield return new WaitForSeconds(1);
        }
    }
}
