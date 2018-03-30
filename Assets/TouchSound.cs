namespace VRTK
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class TouchSound : MonoBehaviour {

		public AudioSource rockSound;
		public AudioSource woodSound;
		public AudioSource bloodSound;
		public GameObject impactMetalPrefab;
		public GameObject impactWoodPrefab;
		public GameObject impactBloodPrefab;
		public GameObject impactPos;
		private GameObject instantiatedObj;
		private VRTK_InteractableObject interact;

		public bool IsHeld() {
			return interact.IsGrabbed();
		}

		private void Start() {
			interact = GetComponent<VRTK_InteractableObject>();
		}

		void OnTriggerEnter(Collider other) {

			if ((IsHeld ()) || (!IsHeld() && gameObject.CompareTag("Arrow"))) {
				if (other.gameObject.CompareTag ("Rock")) {
					instantiatedObj = (GameObject) Instantiate (impactMetalPrefab, impactPos.transform.position, impactPos.transform.rotation);
					rockSound.pitch = (Random.Range (0.9f, 1.2f));
					rockSound.volume = 0.5F;
					rockSound.Play ();
					Destroy (instantiatedObj, 3.0F);

				} else if ((other.gameObject.CompareTag ("Wood")) || (other.gameObject.CompareTag ("DestroyWood"))) {
					instantiatedObj = (GameObject) Instantiate (impactWoodPrefab, impactPos.transform.position, impactPos.transform.rotation);
					woodSound.pitch = (Random.Range (0.9f, 1.2f));
					woodSound.volume = 0.5F;
					woodSound.Play ();
					Destroy (instantiatedObj, 3.0F);
				} else if ((other.gameObject.CompareTag ("Blood"))) {
					instantiatedObj = (GameObject) Instantiate (impactBloodPrefab, impactPos.transform.position, impactPos.transform.rotation);
					bloodSound.pitch = (Random.Range (0.9f, 1.2f));
					bloodSound.volume = 0.5F;
					bloodSound.Play ();
					Destroy (instantiatedObj, 3.0F);
				}
			}
		}
	}
}
