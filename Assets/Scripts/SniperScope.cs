using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperScope : MonoBehaviour
{

    public Camera playerCam;
    public GameObject sniperScope;
    public Image redDot;

    // Start is called before the first frame update
    private void Start() {
        playerCam = gameObject.transform.parent.GetComponent<Camera>();
        redDot = GameObject.FindGameObjectWithTag("Red Dot").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && gameObject.GetComponent<Shooting>().reloading == false){
            playerCam.fieldOfView = 30;
            sniperScope.SetActive(true);
            redDot.enabled = false;
        }
        
        if (Input.GetMouseButtonUp(1) || gameObject.GetComponent<Shooting>().reloading == true){
            playerCam.fieldOfView = 60;
            sniperScope.SetActive(false);
            redDot.enabled = true;
        }
    }
}
