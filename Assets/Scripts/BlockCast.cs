using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCast : MonoBehaviour {

	public float destroyTime = 5f;
	public GameObject blockPrefab;

	private Transform blockSpawn;

	void Awake () {
		this.blockSpawn = transform.Find ("BlockSpawn");
	}

	void Update () {
		Spawn ();
	}

	public void Spawn () {
		if (Input.GetButtonDown ("Spawn Block")) {
			GameObject block = Instantiate (this.blockPrefab, this.blockSpawn.position, this.blockSpawn.rotation);
			Destroy (block, this.destroyTime);
		}
	}
}
