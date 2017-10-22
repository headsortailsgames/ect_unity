using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 5f;

	private Player player;

	void Awake () {
		player = GetComponent<Player> ();
	}

	void FixedUpdate () {
		Move ();
	}

	public void Move () {
		Vector3 velocity = new Vector3 ();
		velocity.x = Input.GetAxis("Horizontal P" + this.player.playerNumber);
		velocity.z = Input.GetAxis ("Vertical P" + this.player.playerNumber);

		if (Mathf.Abs(velocity.x) >= Mathf.Abs(velocity.z))
			velocity.z = 0;
		else
			velocity.x = 0;
		
		velocity *= this.speed;

		if (velocity.sqrMagnitude > 0) {
			this.transform.forward = velocity;
			this.player.animator.SetBool ("Running", true);
		} else {
			this.player.animator.SetBool ("Running", false);
		}

		this.player.rigidbody.velocity = velocity;
	}
}
