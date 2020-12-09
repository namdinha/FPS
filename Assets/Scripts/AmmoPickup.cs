using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

    [SerializeField] AmmoType ammo;
    [SerializeField] int amount = 5;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Ammo>().IncreaseCurrentAmmo(ammo, amount);
            Destroy(gameObject);
        }
    }
}
