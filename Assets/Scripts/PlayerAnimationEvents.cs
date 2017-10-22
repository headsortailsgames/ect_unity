using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {

	private Attack attack;

	void Awake() {
		this.attack = GetComponentInParent<Attack> ();
	}

	void OnAttackEnd() {
		this.attack.OnAttackEnd ();
	}
}
