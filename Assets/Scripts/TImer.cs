using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImer : MonoBehaviour
{
    float currentTime;
    float startingTime = 0;
    public Text timerText;
    public bool start = false;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (start)
        {
        currentTime += 1 * Time.deltaTime;
            timerText.text = Math.Round(currentTime, 2).ToString();
        }
    }
}
