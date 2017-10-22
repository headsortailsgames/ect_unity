using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {

	private Player player;

	void Awake () {
		player = GetComponentInParent<Player> ();
	}

	void OnAttackEnd() {
		this.player.attack.OnAttackEnd ();
	}

	void OnPunch() {
		this.player.attack.OnPunch ();
	}

	void OnSpawnBlock () {
		this.player.blockCast.OnSpawnBlock ();
	}

	void OnSpawnBlockEnd () {
		this.player.blockCast.OnSpawnBlockEnd ();
	}

	void OnTakeDamageEnd () {
		this.player.health.OnTakeDamageEnd ();
	}
}
