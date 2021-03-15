using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour
{
    public Text spawnText;
    // Start is called before the first frame update
    void Start()
    {
        spawnText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        spawnText.enabled = true;
    }

    private void OnTriggerExit(Collider other) {
        spawnText.enabled = true;
    }
}
