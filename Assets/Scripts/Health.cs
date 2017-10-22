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


	void Awake () {
		this.uiHearts = new Image[this.lifes];
		this.uiHearts [0] = heart1;
		this.uiHearts [1] = heart2;
		this.uiHearts [2] = heart3;
	}

	public void TakeDamage () {
		if (this.lifes == 0) return;

		this.lifes--;
		this.uiHearts [this.lifes].sprite = emptyHeart;

		if (this.lifes == 0) {
			Debug.Log ("DEAD");
		}
	}
}
