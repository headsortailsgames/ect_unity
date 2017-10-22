using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	private bool isAttacking = false;
	private Animator animator;

	void Awake() {
		this.animator = this.transform.Find("Model").GetComponent<Animator> ();
	}

	void Update() {
		if (!this.isAttacking && Input.GetButtonDown ("Attack")) {
			this.isAttacking = true;
			this.animator.SetTrigger ("Attack");
		}
	}

	public void OnAttackEnd() {
		this.isAttacking = false;
	}
}
