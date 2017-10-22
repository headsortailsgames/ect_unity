using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int lifes = 3;
	public Sprite emptyHeart;

	public Image heart1;
	public Image heart2;
	public Image heart3;

	private Image[] uiHearts;
	private Animator animator;
	private Attack attack;
	private Movement movement;
	private BlockCast blockCast;

	void Awake () {
		this.attack = GetComponent<Attack> ();
		this.movement = GetComponent<Movement> ();
		this.blockCast = GetComponent<BlockCast> ();

		this.animator = this.transform.Find("Model").GetComponent<Animator> ();

		this.uiHearts = new Image[this.lifes];
		this.uiHearts [0] = heart1;
		this.uiHearts [1] = heart2;
		this.uiHearts [2] = heart3;
	}

	public void TakeDamage () {
		if (this.lifes == 0) return;

		this.lifes--;
		this.uiHearts [this.lifes].sprite = emptyHeart;

		this.attack.enabled = false;
		this.movement.enabled = false;
		this.blockCast.enabled = false;

		if (this.lifes > 0)
			this.animator.SetTrigger ("TakeDamage");
	}

	public void OnTakeDamageEnd () {
		this.attack.enabled = true;
		this.movement.enabled = true;
		this.blockCast.enabled = true;
	}
}
