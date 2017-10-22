using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 5f;

	private new Rigidbody rigidbody;
	private Animator animator;

	void Awake () {
		this.rigidbody = GetComponent<Rigidbody> ();
		this.animator = this.transform.Find("Model").GetComponent<Animator> ();
	}

	void FixedUpdate () {
		Move ();
	}

	public void Move () {
		Vector3 velocity = new Vector3 ();
		velocity.x = Input.GetAxis("Horizontal");
		velocity.z = Input.GetAxis ("Vertical");

		velocity *= this.speed;

		if (velocity.sqrMagnitude > 0) {
			this.transform.forward = velocity;
			this.animator.SetBool ("Running", true);
		} else {
			this.animator.SetBool ("Running", false);
		}

		this.rigidbody.velocity = velocity;
	}
}
