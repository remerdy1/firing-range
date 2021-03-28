using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TImer : MonoBehaviour
{
    public float currentTime;
    public float bestTime;
    float startingTime = 0;
    public Text timerText;
    public bool start = false;

    public GenerateBots generateBots;

    private void Start()
    {
        LoadData();
        currentTime = startingTime;
    }

    private void Update()
    {
        if (start)
        {
            currentTime += 1 * Time.deltaTime;
            timerText.text = Math.Round(currentTime, 2).ToString();
        }

        if(generateBots.finishedGenerating && generateBots.botCount == 0){
            start = false;
            SaveData();
            SceneManager.LoadScene("End Menu");
        }
    }

    public void SaveData(){
        SaveSystem.SaveData(this);
    }

    public void LoadData(){
        Data data = SaveSystem.LoadData();

        bestTime = data.bestTime;
    }
}
