using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour {

	public int lifes = 3;
	public Sprite emptyHeart;

	public Image heart1;
	public Image heart2;
	public Image heart3;

	public UnityEvent onDead;

	private Image[] uiHearts;

	private Player player;

	void Awake () {
		player = GetComponent<Player> ();

		this.uiHearts = new Image[this.lifes];
		this.uiHearts [0] = heart1;
		this.uiHearts [1] = heart2;
		this.uiHearts [2] = heart3;
	}

	public void TakeDamage () {
		if (this.lifes == 0) return;

		this.lifes--;
		this.uiHearts [this.lifes].sprite = emptyHeart;

		this.player.SetScripts (false);

		if (this.lifes > 0) {
			this.player.animator.SetTrigger ("TakeDamage");
		} else {
			this.player.animator.SetTrigger ("Dead");
			this.player.rigidbody.isKinematic = true;

			this.onDead.Invoke ();
		}
	}

	public void OnTakeDamageEnd () {
		this.player.SetScripts (true);
	}
}
