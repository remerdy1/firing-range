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

    public int botCount;
    public int maxBots;

    public bool nearConsole = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnText.enabled = false;
        botCount = 0;
        maxBots = 3;
    }

    // Update is called once per frame
    void Update()
    {
        spawnText.text = $"Press F to spawn bot ({botCount}/{maxBots})";

        if (nearConsole)
        {
            if (Input.GetKeyDown(KeyCode.F) && botCount < maxBots)
            {
                // Spawn bot
                GameObject newBot = Instantiate(soloBot, new Vector3(36.92751f, 0.1000004f, -25.97998f), soloBot.transform.rotation);
                newBot.transform.parent = room1.transform;
                newBot.GetComponent<Target>().consoleScript = this;
                botCount++;

                // Play animation
                newBot.GetComponent<Animator>().SetTrigger("fPressed?");
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        spawnText.enabled = true;
        nearConsole = true;
    }

    private void OnTriggerExit(Collider other) {
        spawnText.enabled = false;
        nearConsole = false;
    }
}
