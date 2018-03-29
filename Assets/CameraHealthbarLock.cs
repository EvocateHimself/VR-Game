using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHealthbarLock : MonoBehaviour {

	public GameObject camera_rig;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(transform.position + camera_rig.transform.rotation * Vector3.back,
			camera_rig.transform.rotation * Vector3.down);
	}
}
