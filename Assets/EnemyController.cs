namespace VRTK.Examples
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class EnemyController : MonoBehaviour {

		public Image healthBar;

		public float maxHealth = 100;
		private float currentHealth;

		void Start () {
			currentHealth = maxHealth;
			GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
			//InvokeRepeating ("ReduceHealth",1,1);
		}

		private void OnCollisionEnter(Collision collision) {
			if (collision.collider.name.Contains("Sword")) {
				currentHealth -= 10;
				healthBar.fillAmount = currentHealth / maxHealth;
			}
			if (collision.collider.name.Contains("Arrow")) {
				currentHealth -= 10;
				healthBar.fillAmount = currentHealth / maxHealth;
			}
			if (currentHealth <= 0) {
				Destroy(gameObject);
			}
		}

		/*
		void ReduceHealth() {
			currentHealth -= 10;
			healthBar.fillAmount = currentHealth / maxHealth;

			if (currentHealth <= 0) {
				Destroy(gameObject);
			}
		}
		*/
	}
}
