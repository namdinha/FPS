using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUIHandler : MonoBehaviour {

    [SerializeField] Text healthText;
    [SerializeField] Text ammoText;

    public void UpdateHealthDisplay(int health) {
        healthText.text = health.ToString();
    }

    public void UpdateAmmoDisplay(int amount) {
        ammoText.text = amount.ToString();
    }

}
