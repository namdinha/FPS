using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour {

    [SerializeField] float angle = 70f;
    [SerializeField] float intensity = 5f;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(angle);
            other.gameObject.GetComponentInChildren<FlashlightSystem>().AddLightIntensity(intensity);
            Destroy(gameObject);
        }
    }
}
