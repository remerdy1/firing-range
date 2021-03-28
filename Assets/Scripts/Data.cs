using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
 public float currentTime;
 public float bestTime;

 public Data (TImer timerScript){
     currentTime = timerScript.currentTime;
     bestTime = timerScript.bestTime;
     
    if(bestTime == 0){
        bestTime = currentTime;
    }

     if(currentTime < bestTime){
         bestTime = currentTime;
     }
 }

}
