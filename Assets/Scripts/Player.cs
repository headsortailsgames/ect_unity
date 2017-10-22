using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int playerNumber = 1;

	[HideInInspector] public new Rigidbody rigidbody;
	[HideInInspector] public Animator animator;

	[HideInInspector] public Attack attack;
	[HideInInspector] public Movement movement;
	[HideInInspector] public BlockCast blockCast;
	[HideInInspector] public Health health;

	void Awake () {
		this.attack = GetComponent<Attack> ();
		this.movement = GetComponent<Movement> ();
		this.blockCast = GetComponent<BlockCast> ();
		this.health = GetComponent<Health> ();

		this.rigidbody = GetComponent<Rigidbody> ();
		this.animator = this.transform.Find("Model").GetComponent<Animator> ();	
	}

	public void SetScripts(bool enabled) {
		this.attack.enabled = enabled;
		this.movement.enabled = enabled;
		this.blockCast.enabled = enabled;
	}
}
