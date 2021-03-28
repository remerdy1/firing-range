using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Text score;
    float bestTime;
    float currentTime;

    void Start()
    {
        LoadData();
        score.text = $"Your Score: {Math.Round(currentTime, 2)} \n Best Score: {Math.Round(bestTime, 2)}";    
    }

    public void LoadData(){
        Data data = SaveSystem.LoadData();

        bestTime = data.bestTime;
        currentTime = data.currentTime;
    }
}
