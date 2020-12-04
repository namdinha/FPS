using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour {

    [SerializeField] Camera FPCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    bool zoomedInToggle = false;

    void Update() {
        if(Input.GetMouseButtonDown(1)) {
            if(zoomedInToggle == false) {
                zoomedInToggle = true;
                FPCamera.fieldOfView = zoomedInFOV;
            }
            else {
                zoomedInToggle = false;
                FPCamera.fieldOfView = zoomedOutFOV;
            }
        }
    }
}
