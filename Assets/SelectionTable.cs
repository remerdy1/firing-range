using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SelectionTable : MonoBehaviour
{
    public Text selectText; // "Press F to select weapon"
    public Camera tableCam;
    public Camera mainCam;
    public FirstPersonController fps;
    bool weaponSelect = false;

    public GameObject akPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Hide text
        selectText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
        // Show text
        selectText.enabled = true;
    }

    private void OnTriggerStay(Collider other) {
        if(Input.GetKeyDown(KeyCode.F)){
            enableTable();
        }

        if(weaponSelect == true){
            // F to cancel 
            if(Input.GetKeyDown(KeyCode.E)){
                disableTable();
            } 

            // Check object pressed 
            if(Input.GetMouseButtonDown(0)){
                // Get weapon clicked
                //! Ray is currently colliding with player 
                Debug.Log("Click");
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if( Physics.Raycast( ray, out hit, 100 )){
                    string[] gunArray = {"Pistol", "Ak_47", "Shotgun", "Sniper Rifle"};
                    int pos = Array.IndexOf(gunArray, hit.transform.tag);
                    Debug.Log(hit.transform.tag + pos);
                    if(pos > -1){
                        
                        // Weapon disapear from table
                        hit.transform.gameObject.SetActive(false);
                        //TODO Equip weapon
                        switch(hit.transform.tag){
                            case "Ak_47":
                                GameObject gun = Instantiate(akPrefab, new Vector3(0,0,0), new Quaternion(0,0,0,0));
                                gun.transform.parent = mainCam.transform;
                                break;
                        }
                        // Leave table
                        disableTable();

                    }
                } 
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        selectText.enabled = false;
    }

    private void enableTable(){
        // Switch Camera to table
        tableCam.enabled = true;
        mainCam.enabled = false;
        // Show Cursor
        fps.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        // Change text
        selectText.text = "Press E To Cancel";

        weaponSelect = true;
    }
    private void disableTable(){
        // Hide text
        selectText.enabled = false;
        selectText.text = "Press F To Select A Weapon";
        // Switch Camera to main
        tableCam.enabled = false;
        mainCam.enabled = true;
        fps.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;

        weaponSelect = false;
    }
}


//TODO Only select 1 weapon
//TODO Can only select guns 
//TODO Fix gun collisions 
//TODO Set gun to equipped 

