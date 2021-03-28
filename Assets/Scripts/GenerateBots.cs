using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBots : MonoBehaviour
{   
    // Bot
    public GameObject bot;
    public int botCount;
    int maxCount;
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
            xPos = Random.Range(7, 33);
            zPos = Random.Range(-9, -25);
            GameObject newBot = Instantiate(bot, new Vector3(xPos, -0.2f, zPos), Quaternion.identity);
            newBot.transform.parent = room2.transform;
            yield return new WaitForSeconds(0.5f);
            botCount++;
        }
    }

    public void Generate(){
        StartCoroutine(EnemyDrop());
    }
}
