using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour
{
    public Text spawnText;
    public GameObject soloBot;
    public GameObject room1;
    public Animator robotAnim;
    int activeBots;
    public int maxBots;

    // Start is called before the first frame update
    void Start()
    {
        spawnText.enabled = false;
        activeBots = 0;
        maxBots = 3;
    }

    // Update is called once per frame
    void Update()
    {
        spawnText.text = $"Press F to spawn bot ({activeBots}/{maxBots})";
    }

    private void OnTriggerEnter(Collider other) {
        spawnText.enabled = true;
    }

    private void OnTriggerStay(Collider other) {
        if(Input.GetKeyDown(KeyCode.F) && activeBots < maxBots){
            // Spawn bot
            GameObject newBot = Instantiate(soloBot, new Vector3(36.92751f, 0.1000004f, -25.97998f), soloBot.transform.rotation);
            newBot.transform.parent = room1.transform;
            activeBots++;

            // Play animation
            newBot.GetComponent<Animator>().SetTrigger("fPressed?");
        }
    }
    private void OnTriggerExit(Collider other) {
        spawnText.enabled = false;
    }
}
