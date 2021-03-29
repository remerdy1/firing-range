using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public GenerateBots generateBots;
    public ConsoleScript consoleScript;

    public void TakeDamage(float damage){
        health -= damage;
        
        if(health <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    private void OnDestroy() {
        if (generateBots)
        {
            generateBots.botCount--;
        }
        else
        {
            consoleScript.botCount--;
        }
        
    }
}
