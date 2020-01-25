using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour {
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float damageTime = 0.3f;

    private void Start() {
        damageCanvas.enabled = false;
    }

    public void ShowDamage() {
        StartCoroutine("EnableSplatter");
    }

    IEnumerator EnableSplatter() {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(damageTime);
        damageCanvas.enabled = false;
    }
}
