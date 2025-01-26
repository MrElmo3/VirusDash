using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

	public VirusController virusPlayer;

	public bool isStarted = false;

	void Start(){
		if(audioManager.instance) audioManager.instance.PlayBGM("music-gameplay");
		Invoke(nameof(PlayBubble),3.2f);
	}

	void PlayBubble(){
		if(audioManager.instance) audioManager.instance.Play("bubble");
	}

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
	
	public void OnClick(){
        if(audioManager.instance) audioManager.instance.Play("click-2");
    }
}
