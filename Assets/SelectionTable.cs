using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SelectionTable : MonoBehaviour
{
    // UI
    public Text selectText; // "Press F to select weapon"
    public Button akButton;

    // CAMERA
    public Camera tableCam; 
    public Camera mainCam;
    
    // FPS Controller 
    public FirstPersonController fps;
    
    bool weaponSelect = false;

    // PREFABS
    public GameObject akPrefab;
    public GameObject pistolPrefab;
    public GameObject shotgunPrefab;

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
                //! Ray is currently colliding with other objects 
                Debug.Log("Click");
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if( Physics.Raycast( ray, out hit, 100 )){
                    string[] gunArray = {"Pistol", "Ak_47", "Shotgun", "Sniper Rifle"};
                    string gunTag = hit.transform.tag;
                    int pos = Array.IndexOf(gunArray, gunTag);
                    Debug.Log(gunTag + pos);
                    if(pos > -1){
                        
                        // Weapon disapear from table
                        hit.transform.gameObject.SetActive(false);
                        //TODO Equip weapon
                        switch(gunTag){
                            case "Ak_47":
                                equipGun(new Vector3(0.34f, -0.24f, 0.67f), akPrefab);
                                break;
                            case "Pistol":
                                equipGun(new Vector3(1f, -0.98f, 1.3f), pistolPrefab);
                                break;
                            case "Shotgun":
                                equipGun(new Vector3(0.34f, -0.24f, 0.67f), shotgunPrefab);
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

    private void equipGun(Vector3 position, GameObject prefab){
        mainCam.enabled = true;
        GameObject gun = Instantiate(prefab, position, prefab.transform.rotation);
        gun.transform.parent = mainCam.transform;
        gun.transform.localPosition = position;
    }
}


//TODO Only select 1 weapon
//TODO Can only select guns 
//TODO Fix gun collisions 
//TODO Set gun to equipped 

