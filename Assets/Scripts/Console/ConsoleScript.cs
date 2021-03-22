using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour
{
    public Text spawnText;
    public GameObject robot;
    public Animator robotAnim;
    // Start is called before the first frame update
    void Start()
    {
        spawnText.enabled = false;
        robot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        spawnText.enabled = true;
    }

    private void OnTriggerStay(Collider other) {
        if(Input.GetKeyDown(KeyCode.F)){
            // Spawn bot
            robot.SetActive(true);
            // Play animation
            robotAnim.SetTrigger("fPressed?");
        }
    }
    private void OnTriggerExit(Collider other) {
        spawnText.enabled = false;
    }
}
