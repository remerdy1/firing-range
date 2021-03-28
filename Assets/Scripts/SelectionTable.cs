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
    public GameObject buttons;
    public Button akButton;
    public Button pistolButton;
    public Button shotgunButton;

    // CAMERA
    public Camera tableCam; 
    public Camera mainCam;
    
    // FPS Controller 
    public FirstPersonController fps;
    public PlayerController playerScript;
    
    // Is the table being looked at?
    bool weaponSelect = false;

    // PREFABS
    public GameObject akPrefab;
    public GameObject pistolPrefab;
    public GameObject shotgunPrefab;

    // Start is called before the first frame update
    void Start()
    {        
        akButton.onClick.AddListener(equipAk);
        pistolButton.onClick.AddListener(equipPistol);
        shotgunButton.onClick.AddListener(equipShotgun);

        // Hide UI
        selectText.enabled = false;
        buttons.SetActive(false);
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
            // E to cancel 
            if(Input.GetKeyDown(KeyCode.E)){
                disableTable();
            } 
        }
    }

    private void OnTriggerExit(Collider other) {
        selectText.enabled = false;
    }

    // Table 
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
        // Show UI
        buttons.SetActive(true);

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
        buttons.SetActive(false);
        weaponSelect = false;
    }

    // Equip weapons
    private void equipGun(Vector3 position, GameObject prefab){
        mainCam.enabled = true;
        GameObject gun = Instantiate(prefab, position, prefab.transform.rotation);
        gun.transform.parent = mainCam.transform;
        gun.transform.localPosition = position;
        playerScript.isHoldingWeapon = true;
    }

    public void equipAk(){
        if(playerScript.isHoldingWeapon == true){
            GameObject equippedGun = mainCam.transform.GetChild(0).gameObject;
            Destroy(equippedGun);
        }
        
        equipGun(new Vector3(0.34f, -0.24f, 0.67f), akPrefab);
        disableTable();  
    }

    public void equipShotgun(){
        if(playerScript.isHoldingWeapon == true){
            GameObject equippedGun = mainCam.transform.GetChild(0).gameObject;
            Destroy(equippedGun);
        }
        
        equipGun(new Vector3(0.34f, -0.24f, 0.67f), shotgunPrefab);
        disableTable();
    }

    public void equipPistol(){
        if(playerScript.isHoldingWeapon == true){
            GameObject equippedGun = mainCam.transform.GetChild(0).gameObject;
            Destroy(equippedGun);
        }
        
        equipGun(new Vector3(1f, -0.98f, 1.3f), pistolPrefab);
        disableTable();
    }
}