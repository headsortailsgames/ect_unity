using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByForce : MonoBehaviour {

	public float multiplier = 10f;

	private new Rigidbody rigidbody;


	void Awake () {
		this.rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		Move ();
	}

	public void Move () {
		Vector3 force = new Vector3 ();
		force.x = Input.GetAxis("Horizontal");
		force.z = Input.GetAxis ("Vertical");

		force *= this.multiplier;

		this.rigidbody.AddForce (force);
	}
}
