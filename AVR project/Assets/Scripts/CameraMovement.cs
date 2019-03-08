using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform anchor;
    public float speed;
    
	void Start () {
	}
	
	void Update () {
		if(OVRInput.GetDown(OVRInput.Button.DpadDown))
		{
			transform.Translate(-anchor.forward * speed);
		}
		else if (OVRInput.GetDown(OVRInput.Button.DpadUp))
		{
			transform.Translate(anchor.forward * speed);
		}
		else if (OVRInput.GetDown(OVRInput.Button.DpadLeft))
		{
			transform.Translate(-anchor.right * speed);
		}
		else if (OVRInput.GetDown(OVRInput.Button.DpadRight))
		{
			transform.Translate(anchor.right * speed);
		}
	}
}
