using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public float force = 50.0f;

	private bool isAttacking = false;
	private Animator animator;
	private Movement movement;

	void Awake() {
		this.animator = this.transform.Find("Model").GetComponent<Animator> ();
		this.movement = GetComponent<Movement> ();
	}

	void Update() {
		if (!this.isAttacking && Input.GetButtonDown ("Attack")) {
			this.isAttacking = true;
			this.movement.enabled = false;
			this.animator.SetTrigger ("Attack");
		}
	}

	public void OnPunch() {
		Vector3 origin = transform.position;
		origin.y = 0.5f;

		RaycastHit hit;

		int layerMask = LayerMask.GetMask ("Block");
		bool hitted = Physics.Raycast (origin, transform.forward, out hit, Mathf.Infinity, layerMask);
		if (hitted) {
			GameObject block = hit.collider.gameObject;
			Rigidbody blockBody = block.GetComponent<Rigidbody> ();
			blockBody.isKinematic = false;
			blockBody.AddForce (transform.forward * force, ForceMode.Impulse);
		}
	}

	public void OnAttackEnd() {
		this.isAttacking = false;
		this.movement.enabled = true;
	}
}
