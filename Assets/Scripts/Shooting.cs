using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    // Gun Stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold, isEquipped;
    int bulletsLeft, bulletsShot;

    // bools
    bool shooting, readyToShoot, reloading;

    //Reference
    Camera fpsCam;
    RaycastHit rayHit;
    public ParticleSystem muzzleFlash;
    public Transform barrelLocation;
    AudioSource gunshot;

    //Animator
    Animator reloadAnim;

    // UI
    Text ammoUI;

    private void Awake() {
        isEquipped = false;

        bulletsLeft = magazineSize;
        readyToShoot = true;
        reloadAnim = GetComponent<Animator>();
        gunshot = GetComponent<AudioSource>();
        // Main Camera
        fpsCam = Camera.main;
        // Ammo text
        ammoUI = GameObject.Find("UI").transform.GetChild(1).GetComponent<Text>();
    }

    private void Update() {
        MyInput();
        // Update UI
        ammoUI.text = $"{bulletsLeft}/{magazineSize}";
    }

    private void MyInput(){
        if(isEquipped == true){
            if(allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
            else shooting = Input.GetKeyDown(KeyCode.Mouse0);

            if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading){
                Debug.Log("Reloading");
                Reload();
                };

            //Shoot
            if(readyToShoot && shooting && !reloading && bulletsLeft > 0){
                bulletsShot = bulletsPerTap;
                MuzzleFlash();
                Shoot();
            }   
        }

    }

    void Shoot(){
        
        readyToShoot = false;
        gunshot.Play(0);

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate direction with spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x,y,0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range)){
            Debug.Log(rayHit.collider.name);

            if(rayHit.collider.CompareTag("Target")){
                Target target  = rayHit.transform.GetComponent<Target>();
                target.TakeDamage(damage);
            }
        }

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0){
            Invoke("Shoot", timeBetweenShots);
        }
    }

    void ResetShot(){
        readyToShoot = true;
    }

    void Reload(){
        reloading = true;
        reloadAnim.SetBool("Reloading", true);
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished(){
        bulletsLeft = magazineSize;
        reloading = false;
        reloadAnim.SetBool("Reloading", false);
    }

    void MuzzleFlash(){
        muzzleFlash.transform.position = barrelLocation.position;
        muzzleFlash.Play();
    }
}
