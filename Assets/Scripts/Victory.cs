using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {

	private Attack attack;
	private BlockCast blockCast;

	private Animator animator;

	void Awake () {
		this.attack = GetComponent<Attack> ();
		this.blockCast = GetComponent<BlockCast> ();

		this.animator = this.transform.Find("Model").GetComponent<Animator> ();
	}

	public void OnVictory () {
		this.attack.enabled = false;
		this.blockCast.enabled = false;

		this.animator.SetTrigger ("Victory");
	}
}
