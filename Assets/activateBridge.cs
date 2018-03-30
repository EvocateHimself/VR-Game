namespace VRTK
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class activateBridge : MonoBehaviour {

		private VRTK_Lever lever;
		public GameObject bridge;
		public Transform target;
		public float speed;
		public AudioSource bridgeStone;

		// Use this for initialization
		private void Start () {
			lever = GetComponent<VRTK_Lever>();
		}
		
		// Update is called once per frame
		void Update () {
			if (lever.angle >= lever.maxAngle) {
				openBridge();
			}
		}

		void openBridge() {
			float step = speed * Time.deltaTime;
			bridge.transform.position = Vector3.MoveTowards(bridge.transform.position, target.position, step);
			bridgeStone.Play();
			bridgeStone.volume = 1F;
		}
	}
}