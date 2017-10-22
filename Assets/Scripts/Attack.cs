using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

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

	public void OnAttackEnd() {
		this.isAttacking = false;
		this.movement.enabled = true;
	}
}
