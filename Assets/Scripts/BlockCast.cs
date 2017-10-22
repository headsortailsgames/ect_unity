using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCast : MonoBehaviour {

	public GameObject blockPrefab;
	public int playerNumber = 1;

	private bool onSpawn;
	private Transform blockSpawn;private Animator animator;
	private Movement movement;


	void Awake () {
		this.onSpawn = false;
		this.blockSpawn = transform.Find ("BlockSpawn");
		this.movement = GetComponent<Movement> ();
		this.animator = this.transform.Find("Model").GetComponent<Animator> ();
	}

	void Update () {
		Spawn ();
	}

	public void Spawn () {
		if (!this.onSpawn && Input.GetButtonDown ("Spawn Block P" + playerNumber)) {
			this.onSpawn = true;
			this.movement.enabled = false;
			this.animator.SetTrigger ("SpawnBlock");
		}
	}

	public void OnSpawnBlock () {
		Instantiate (this.blockPrefab, this.blockSpawn.position, this.blockSpawn.rotation);
	}

	public void OnSpawnBlockEnd () {
		this.onSpawn = false;
		this.movement.enabled = true;
	}
}
