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
   //public Text loseMessage;
   public void SetMessage(bool win, string message = ""){
       winCanvas.SetActive(win);
       loseCanvas.SetActive(!win);
     //  loseMessage.text = message;
   }

   void TweenMessage(){

   }

}
