using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour {
    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 30f;
    [SerializeField] float zoomedOutMouseSensitivity = 2f;
    [SerializeField] float zoomedInMouseSensitivity = 1f;

    [SerializeField] bool canZoom = false;

    bool zoomedIn = false;

    private void OnDisable() {
        //ZoomOut();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            if (zoomedIn) {
                ZoomIn();
            } else {
                ZoomOut();
            }
        }
    }

    private void ZoomIn() {
        Camera.main.fieldOfView = zoomedOutFOV;
        firstPersonController.GetMouseLook().XSensitivity = zoomedOutMouseSensitivity;
        firstPersonController.GetMouseLook().YSensitivity = zoomedOutMouseSensitivity;
        zoomedIn = false;
    }

    private void ZoomOut() {
        Camera.main.fieldOfView = zoomedInFOV;
        firstPersonController.GetMouseLook().XSensitivity = zoomedInMouseSensitivity;
        firstPersonController.GetMouseLook().YSensitivity = zoomedInMouseSensitivity;
        zoomedIn = true;
    }
}
