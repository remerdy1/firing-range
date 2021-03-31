using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Lit");
        anim.SetTrigger("character_nearby");
    }

    private void OnTriggerExit(Collider other) {
        anim.ResetTrigger("character_nearby");
    }
}
