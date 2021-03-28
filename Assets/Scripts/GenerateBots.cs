using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBots : MonoBehaviour
{   
    // Bot
    public GameObject bot;
    public int botCount;
    int maxCount;
    public bool finishedGenerating;
    // Position
    public int xPos;
    public int zPos;
    public GameObject room2;
    
    // Start is called before the first frame update
    void Start()
    {
        maxCount = Random.Range(9, 15);
    }

    IEnumerator EnemyDrop(){
        while(botCount < maxCount){
            // Instantiate bot
            xPos = Random.Range(7, 33);
            zPos = Random.Range(-9, -25);
            GameObject newBot = Instantiate(bot, new Vector3(xPos, -0.2f, zPos), Quaternion.identity);
            //TODO play animation

            // Add this script to the bot
            newBot.GetComponent<Target>().generateBots = this;
            newBot.transform.parent = room2.transform;

            // Wait 0.5s
            yield return new WaitForSeconds(0.5f);
            botCount++;
        }
        finishedGenerating = true;
    }

    public void Generate(){
        StartCoroutine(EnemyDrop());
    }
}
