using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    public float maxHealth = 100f;
    PlayerController Player;

    private void Start() {
        healthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        currentHealth = Player.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

}
