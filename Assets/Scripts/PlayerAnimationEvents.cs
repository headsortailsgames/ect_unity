using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {

	private Attack attack;
	private BlockCast blockCast;

	void Awake() {
		this.attack = GetComponentInParent<Attack> ();
		this.blockCast = GetComponentInParent<BlockCast> ();
	}

	void OnAttackEnd() {
		this.attack.OnAttackEnd ();
	}

	void OnPunch() {
		this.attack.OnPunch ();
	}

	void OnSpawnBlock () {
		this.blockCast.OnSpawnBlock ();
	}

	void OnSpawnBlockEnd () {
		this.blockCast.OnSpawnBlockEnd ();
	}
}
