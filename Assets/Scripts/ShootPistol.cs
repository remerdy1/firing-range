using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPistol : MonoBehaviour
{
    public float damage = 5;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public Transform barrelLocation;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        MuzzleFlash();
        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
        }
        
        Target target  = hit.transform.GetComponent<Target>();

        if(target.tag == "Target"){
            target.TakeDamage(damage);
        }
    }

    void MuzzleFlash(){
        muzzleFlash.transform.position = barrelLocation.position;
        muzzleFlash.Play();
    }
}
