using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public float destroyTime = 5f;

	private bool onFire = false;
	private new Rigidbody rigidbody;

	void Awake () {
		this.rigidbody = GetComponent<Rigidbody> ();

		Invoke ("DestroyBlock", this.destroyTime);
	}

	public void Fire(Vector3 force) {
		rigidbody.isKinematic = false;
		rigidbody.AddForce (force, ForceMode.Impulse);
		this.onFire = true;
	}

	void OnCollisionEnter(Collision collision) {

		bool collidedWithBlock = collision.gameObject.CompareTag ("Block");
		bool collidedWithNonBlock = (  collision.gameObject.CompareTag ("Wall")
		                            || collision.gameObject.CompareTag ("Player"));
		if ( collidedWithBlock || (collidedWithNonBlock && this.onFire)) {
			DestroyBlock ();
		}
	}

	void DestroyBlock() {
		Destroy (gameObject);
	}
}
