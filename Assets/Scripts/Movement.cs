using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 5f;

	private new Rigidbody rigidbody;


	void Awake () {
		this.rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
		Move ();
	}

	public void Move () {
		Vector3 velocity = new Vector3 ();
		velocity.x = Input.GetAxis("Horizontal");
		velocity.z = Input.GetAxis ("Vertical");

		velocity *= this.speed;

		this.rigidbody.velocity = velocity;
	}
}
