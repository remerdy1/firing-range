using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health = 100f;

    public bool isHoldingWeapon = false;
    public GameObject pausedUI;

    bool paused;

    private void Start() {
        paused = false;
        pausedUI.SetActive(false);
    }

    private void Update() {
        // Paused 
        if(Input.GetKeyDown(KeyCode.Escape) && !paused){
            paused = true;
            Time.timeScale = 0;
            pausedUI.SetActive(true);
        }else if(Input.GetKeyDown(KeyCode.Escape) && paused){
            paused = false;
            Time.timeScale = 1;
            pausedUI.SetActive(false);
        }
    }
}
