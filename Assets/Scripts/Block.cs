using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public float destroyTime = 5f;

	private bool onFire = false;
	private new Rigidbody rigidbody;
	private ParticleSystem destroyParticle;
	private Animator animator;
	private Collider collider;

	void Awake () {
		this.rigidbody = GetComponent<Rigidbody> ();
		this.destroyParticle = GetComponentInChildren<ParticleSystem> ();
		this.animator = GetComponent<Animator>();
		this.collider = GetComponent<Collider> ();

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
		
		if (collidedWithBlock || (collidedWithNonBlock && this.onFire)) {
			DestroyBlock ();
		}
	}

	private void DestroyBlock() {
		this.destroyParticle.Play ();
		this.animator.SetBool ("destroy", true);
		this.collider.enabled = false;
		this.rigidbody.velocity = Vector3.zero;
		Destroy (gameObject, 2.0f);
	}

}
