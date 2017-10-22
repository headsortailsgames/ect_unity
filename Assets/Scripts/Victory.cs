using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {

	private Player player;

	void Awake () {
		player = GetComponent<Player> ();
	}

	public void OnVictory () {
		this.player.SetScripts (false);
		this.player.animator.SetTrigger ("Victory");
	}
}
