namespace VRTK
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class lightTorch : MonoBehaviour {

		private VRTK_InteractableObject interact;

		public AudioSource igniteSound;
		public AudioSource burnSound;

		public bool IsHeld() {
			return interact.IsGrabbed();
		}

		private void Start() {
			interact = GetComponent<VRTK_InteractableObject>();

			//If any torch in the scene is active, play the sound on start
			if (transform.Find("Torch").gameObject.activeSelf) {
				burnSound.Play();
			}

		}

		void OnTriggerEnter(Collider other) {

			//If the torch is lit and it collides with another torch
			if (transform.Find("Torch").gameObject.activeSelf) {
				if (other.gameObject.CompareTag("Torches")) {
					other.transform.Find("Torch").gameObject.SetActive(true);
				}
			}
		}
	}
}