using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int health = 100;

    PlayerInfoUIHandler UIHandler;

    void Start() {
        UIHandler = FindObjectOfType<PlayerInfoUIHandler>();
        UIHandler.UpdateHealthDisplay(health);
    }

    public void TakeDamage(int damage) {
        health -= damage;
        UIHandler.UpdateHealthDisplay(health);
        if(health <= 0) {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
