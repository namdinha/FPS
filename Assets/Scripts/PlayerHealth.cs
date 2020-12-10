using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int health = 100;

    PlayerInfoUIHandler UIHandler;
    DisplayDamage displayDamage;

    void Start() {
        displayDamage = FindObjectOfType<DisplayDamage>();
        UIHandler = FindObjectOfType<PlayerInfoUIHandler>();
        UIHandler.UpdateHealthDisplay(health);
    }

    public void TakeDamage(int damage) {
        health -= damage;
        UIHandler.UpdateHealthDisplay(health);
        displayDamage.ShowDamage();
        if (health <= 0) {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
