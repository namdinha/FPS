using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    [SerializeField] int ammoAmount = 10;

    public void IncreaseCurrentAmmo(int amount) {
        ammoAmount += amount;
    }

    public void DecreaseCurrentAmmo() {
        ammoAmount--;
    }

    public int GetCurrentAmmo() {
        return ammoAmount;
    }
}
