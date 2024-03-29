﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console2Script : MonoBehaviour
{
    // TIMER
    public Text startText; // "Press F to start"
    public Text timer;
    TImer timerScript;
    GenerateBots generateBots;

    public bool nearConsole;

    // Start is called before the first frame update
    void Start()
    {
        // Hide start and timer text
        startText.enabled = false;
        timer.enabled = false;
        // Reference timer script 
        timerScript = timer.GetComponent<TImer>();
        generateBots = gameObject.GetComponent<GenerateBots>();
    }

    void Update()
    {
        if (nearConsole)
        {
            if (Input.GetKeyDown(KeyCode.F) && timerScript.start == false)
            {
                // Start timer
                timer.enabled = true;
                timerScript.start = true;

                // Generate bots
                generateBots.Generate();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Enable start text on enter
        startText.enabled = true;
        nearConsole = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        // Hide startText on exit
        startText.enabled = false;
        nearConsole = false;
    }
}