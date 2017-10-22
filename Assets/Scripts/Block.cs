using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	private new Rigidbody rigidbody;

	void Awake () {
		this.rigidbody = GetComponent<Rigidbody> ();
	}

	public void Fire(Vector3 force) {
		rigidbody.isKinematic = false;
		rigidbody.AddForce (force, ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Block") || collision.gameObject.CompareTag ("Wall")
			|| collision.gameObject.CompareTag ("Player")) {
			Destroy (gameObject);
		}
	}
}
