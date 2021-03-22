using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console2Script : MonoBehaviour
{
    public Text startText; // "Press F to start"
    public Text timer;
    TImer timerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Hide start and timer text
        startText.enabled = false;
        timer.enabled = false;
        // Reference timer script 
        timerScript = timer.GetComponent<TImer>();
    }

    // Enable start text on enter
    private void OnTriggerEnter(Collider other)
    {
        startText.enabled = true;
    }

    // If f is pressed then start timer 
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            timer.enabled = true;
            timerScript.start = true;
        }
    }

    // Hide startText on exit
    private void OnTriggerExit(Collider other)
    {
        startText.enabled = false;
    }
}