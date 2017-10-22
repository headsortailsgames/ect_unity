using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public float force = 50.0f;

	private bool isAttacking = false;
	private Player player;

	void Awake () {
		player = GetComponent<Player> ();
	}

	void Update() {
		if (!this.isAttacking && Input.GetButtonDown ("Attack P" + this.player.playerNumber)) {
			this.isAttacking = true;
			this.player.SetScripts (false);
			this.player.animator.SetTrigger ("Attack");
		}
	}

	public void OnPunch() {
		Vector3 origin = transform.position;
		origin.y = 0.5f;

		RaycastHit hit;

		int layerMask = LayerMask.GetMask ("Block");
		bool hitted = Physics.Raycast (origin, transform.forward, out hit, Mathf.Infinity, layerMask);
		if (hitted) {
			Block block = hit.collider.gameObject.GetComponent<Block>();
			block.Fire(transform.forward * force);
		}
	}

	public void OnAttackEnd() {
		this.isAttacking = false;
		this.player.SetScripts (true);
	}
}
