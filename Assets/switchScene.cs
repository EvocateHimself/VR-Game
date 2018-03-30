namespace VRTK
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class switchScene : MonoBehaviour {

		void OnTriggerEnter(Collider other) {
			if (other.gameObject.CompareTag ("switchScene")) {
				SceneManager.LoadScene(1);
			}
		}
	}
}
