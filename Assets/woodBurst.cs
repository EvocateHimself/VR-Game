namespace VRTK
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class woodBurst : MonoBehaviour {

		public float maxHealth = 50;
		private float currentHealth;

		private VRTK_InteractableObject interact;

		public bool IsHeld() {
			return interact.IsGrabbed();
		}

		private void Start() {
			currentHealth = maxHealth;
			interact = GetComponent<VRTK_InteractableObject>();
		}

		void OnTriggerEnter(Collider other) {
			if ((IsHeld() && gameObject.CompareTag("Sword")) || (!IsHeld() && gameObject.CompareTag("Arrow"))) {
				if (other.gameObject.CompareTag ("DestroyWood")) {
					currentHealth -= 10;
					if (currentHealth <= 0) {
						Destroy(other.gameObject);
					}
				}
			}
		}
	}
}
