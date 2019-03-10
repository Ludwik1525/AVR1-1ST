using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform anchor;
    public float speed;
    public float maxDistancce;
    public Transform center;
    
	void Start () {

	}
	
	void Update ()
    {
        if(OVRInput.GetDown(OVRInput.Button.DpadDown) && Vector3.Distance(transform.position + (-anchor.forward * speed), center.position) < maxDistancce)
		{
			transform.Translate((-anchor.forward * speed) * Time.deltaTime);
		}
		else if (OVRInput.GetDown(OVRInput.Button.DpadUp) && Vector3.Distance(transform.position + (anchor.forward * speed), center.position) < maxDistancce)
		{
			transform.Translate((anchor.forward * speed) * Time.deltaTime);
		}
		else if (OVRInput.GetDown(OVRInput.Button.DpadLeft) && Vector3.Distance(transform.position + (-anchor.right * speed), center.position) < maxDistancce)
		{
			transform.Translate((-anchor.right * speed) * Time.deltaTime);
		}
		else if (OVRInput.GetDown(OVRInput.Button.DpadRight) && Vector3.Distance(transform.position + (anchor.right * speed), center.position) < maxDistancce)
		{
			transform.Translate((anchor.right * speed) * Time.deltaTime);
		}
	}
}
