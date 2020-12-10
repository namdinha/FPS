using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour {

    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    void Start() {
        myLight = GetComponent<Light>();
    }

    void Update() {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightIntensity() {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle() {
        myLight.spotAngle = Math.Max(minimumAngle, myLight.spotAngle - angleDecay * Time.deltaTime);
    }
}
