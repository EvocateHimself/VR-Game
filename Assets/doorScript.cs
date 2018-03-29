namespace VRTK
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class doorScript : MonoBehaviour {

		//Gameobjects that can be dragged from the inspector
		public GameObject Door;
		public GameObject Key;

		public AudioSource SoundSource1;

		//Call the script component from the gameobject 'key'
		private VRTK_InteractableObject interactComponent;

		private bool openDoor = false;

		void Start() {
			//Initiate the script component from gameobject 'key'
			interactComponent = Key.GetComponent<VRTK_InteractableObject>();
		}

		void Update() {
			//if openDoor equals true, execute a function
			if (openDoor) {
				//Start corountine waitforseconds 1
				StartCoroutine(DoorTurn());
				openDoor = false;
			}
		}

		//If the gameobject 'key' collides, set boolean openDoor to true
		void OnTriggerEnter(Collider other) {
			if(other.gameObject == Key) {
				openDoor = true;
			}
		}

		//StartCorountine executor
		IEnumerator DoorTurn() {
			//Change variables from the script 'VRTK_InteractableObject' in gameobject 'key'
			interactComponent.isGrabbable = false;
			interactComponent.touchHighlightColor = new Vector4(0, 0, 0, 0);
			yield return new WaitForSeconds(1);
			SoundSource1.Play();

			float currentRotation = transform.eulerAngles.y;
			float endRotation = transform.eulerAngles.y - 30.0f;

			while(endRotation < currentRotation)
			{
				
				if (Door.gameObject.name == "HingeFront") {
					var newRot = Quaternion.RotateTowards (Door.transform.rotation, Quaternion.Euler (0.0f, 0.0f, 0.0f), Time.deltaTime * 100);
					Door.transform.rotation = newRot;
				} else if (Door.gameObject.name == "HingeLeft") {
					var newRot = Quaternion.RotateTowards (Door.transform.rotation, Quaternion.Euler (0.0f, -90.0f, 0.0f), Time.deltaTime * 100);
					Door.transform.rotation = newRot;
				}

				yield return new WaitForEndOfFrame();
			}


		}
	}
}
