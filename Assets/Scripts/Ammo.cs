using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    [SerializeField] AmmoSlot[] ammoSlots;
    
    [System.Serializable]
    private class AmmoSlot {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    //todo TAKE CARE OF THE NULLS
    public void IncreaseCurrentAmmo(AmmoType ammoType, int amount) {
        GetAmmoSlot(ammoType).ammoAmount += amount;
    }

    public void DecreaseCurrentAmmo(AmmoType ammoType) {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public int GetCurrentAmmo(AmmoType ammoType) {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType) {
        foreach(AmmoSlot ammoSlot in ammoSlots) {
            if(ammoSlot.ammoType == ammoType) {
                return ammoSlot;
            }
        }
        return null;
    }
}
