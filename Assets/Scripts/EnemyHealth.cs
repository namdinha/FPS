using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public void TakeDamage(float damage) {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints <= 0f) {
            Die();
        }
    }

    private void Die() {
        if(isDead) { return; }
        isDead = true;
        GetComponent<Animator>().enabled = false;
    }

    public bool IsDead() {
        return isDead;
    }
}
