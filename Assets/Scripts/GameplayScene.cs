using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayScene : MonoBehaviour {

	public float timeToChangeScene = 5f;


	public void OnGameover () {
		Invoke ("LoadMainMenuScene", this.timeToChangeScene);
	}

	private void LoadMainMenuScene () {
		SceneManager.LoadScene ("MainMenu");
	}
}
