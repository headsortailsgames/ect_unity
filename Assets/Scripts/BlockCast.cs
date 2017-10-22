using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCast : MonoBehaviour {

	public GameObject blockPrefab;

	private bool onSpawn;
	private Transform blockSpawn;

	private Player player;

	void Awake () {
		player = GetComponent<Player> ();

		this.onSpawn = false;
		this.blockSpawn = transform.Find ("BlockSpawn");
	}

	void Update () {
		Spawn ();
	}

	public void Spawn () {
		if (!this.onSpawn && Input.GetButtonDown ("Spawn Block P" + this.player.playerNumber)) {
			this.onSpawn = true;
			this.player.SetScripts (false);
			this.player.animator.SetTrigger ("SpawnBlock");
		}
	}

	public void OnSpawnBlock () {
		Instantiate (this.blockPrefab, this.blockSpawn.position, this.blockSpawn.rotation);
	}

	public void OnSpawnBlockEnd () {
		this.onSpawn = false;
		this.player.SetScripts (true);
	}
}
