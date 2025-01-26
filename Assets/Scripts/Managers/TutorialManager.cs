using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class TutorialManager : MonoBehaviour
{
	public static TutorialManager Instance{ get;set;}
   
   void Awake()
   {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
   }

	[System.Serializable]
	public class TutorialDTO{
		public string id;
		public string text;
		public Vector3 positionInit;
		public Vector3 positionEnd;
	}
	public GameObject container;
	public TMP_Text text;
	public TutorialDTO[] secuence_tutorial;
	
	public bool CheckEnableTutorial(){
		return !LevelManager.Instance && LevelManager.Instance.GetLevel() == 0;
	}
	private bool isActive;
	private int index = 0;
	void Update(){
		if(Input.GetKeyDown(KeyCode.Q)){
			ShowTutorial();
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			if(isActive){
				HideTutorial();	
			}			
		}
	}
	void NextTutorial(){
		index++;
		if(index < secuence_tutorial.Length){
			ShowTutorial();	
		}
		
	}
	TutorialDTO currentTutorial;
	public void ShowTutorial(){
		
		Time.timeScale = 0;
		currentTutorial = secuence_tutorial[index];
		text.text = currentTutorial.text;
		container.transform.position = currentTutorial.positionInit;
		container.transform.DOMove(currentTutorial.positionEnd,1).OnComplete(()=>{
			isActive = true;
		});
	}
	public void HideTutorial(){
		
		Time.timeScale = 1;
		container.transform.DOMove(currentTutorial.positionInit,1).OnComplete(()=>{
			isActive = false;
			currentTutorial = null;
			Invoke(nameof(NextTutorial),3f);
		});
	}
}
