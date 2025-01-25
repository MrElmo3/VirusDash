using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager> {

	public VirusController virusPlayer;

	public bool isStarted = false;

	public void StartGame() {
		isStarted = true;
		virusPlayer.StartJump();
	}

	private void Update() {
		if (!isStarted) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				StartGame();
			}
		}
	}
}
