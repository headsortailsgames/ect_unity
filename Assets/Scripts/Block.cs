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
}
