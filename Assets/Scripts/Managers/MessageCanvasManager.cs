using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCanvasManager : MonoBehaviour
{
   public static MessageCanvasManager Instance{ get;set;}
   
   void Awake()
   {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }

        Instance = this;
   }

   public GameObject winCanvas;
   public GameObject loseCanvas;
  bool isWinning;
   public void SetMessage(bool win, string message = ""){
      this.isWinning = win;

      Invoke(nameof(ActiveMessage),0.5f);
     //  loseMessage.text = message;
   }
   void ActiveMessage(){
      winCanvas.SetActive(isWinning);
       loseCanvas.SetActive(!isWinning);
   }
}
