using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour {

    [SerializeField] Camera FPCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float sensitivityIn = 0.5f;
    [SerializeField] float sensitivityOut = 2f;

    bool zoomedInToggle = false;
    RigidbodyFirstPersonController FPController;

    void Start() {
        FPController = GetComponent<RigidbodyFirstPersonController>();
    }

    void Update() {
        if(Input.GetMouseButtonDown(1)) {
            if(zoomedInToggle == false) {
                zoomedInToggle = true;
                FPCamera.fieldOfView = zoomedInFOV;
                SetSenitivity(sensitivityIn);
            }
            else {
                zoomedInToggle = false;
                FPCamera.fieldOfView = zoomedOutFOV;
                SetSenitivity(sensitivityOut);
            }
        }
    }

    private void SetSenitivity(float amount) {
        FPController.mouseLook.XSensitivity = amount;
        FPController.mouseLook.YSensitivity = amount;
    }
}
