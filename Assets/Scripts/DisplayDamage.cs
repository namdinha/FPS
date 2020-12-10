using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour {

    [SerializeField] float displayDamageDuration = 1f;

    Canvas canvas;

    void Awake() {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void ShowDamage() {
        StartCoroutine(DisplayDamageImage());
    }

    IEnumerator DisplayDamageImage() {
        canvas.enabled = true;
        yield return new WaitForSeconds(displayDamageDuration);
        canvas.enabled = false;
    }
}
