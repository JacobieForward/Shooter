using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour {
    [SerializeField] float lightIntensityRestoreAmount = 2;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<Flashlight>().RestoreLightIntensity(lightIntensityRestoreAmount);
            FindObjectOfType<Flashlight>().RestoreLightAngle();
            Destroy(gameObject);
        }
    }
}
