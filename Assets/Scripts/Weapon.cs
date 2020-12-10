using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;

    PlayerInfoUIHandler UIcanvas;
    bool canShoot = true;

    void Awake() {
        UIcanvas = FindObjectOfType<PlayerInfoUIHandler>();
    }

    void OnEnable() {
        canShoot = true;
        UIcanvas.UpdateAmmoDisplay(ammoSlot.GetCurrentAmmo(ammoType));
    }

    void Update() {
        if(Input.GetButtonDown("Fire1") && canShoot) {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot() {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0) {
            ammoSlot.DecreaseCurrentAmmo(ammoType);
            PlayMuzzleFlash();
            ProcessRaycast();
            UIcanvas.UpdateAmmoDisplay(ammoSlot.GetCurrentAmmo(ammoType));
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash() {
        muzzleFlash.Play();
    }

    private void ProcessRaycast() {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {
            if(hit.collider.gameObject.tag == "Enemy") {
                hit.collider.isTrigger = true;
            }
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
    }

    private void CreateHitImpact(RaycastHit hit) {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
