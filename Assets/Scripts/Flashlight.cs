using UnityEngine;

public class Flashlight : MonoBehaviour {
    [SerializeField] float lightDecay = 0.3f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumSpotAngle = 20f;
    [SerializeField] float maximumSpotAngle = 60f;

    Light myLight;

    private void Start() {
        myLight = GetComponent<Light>();
        myLight.spotAngle = maximumSpotAngle;
    }

    private void Update() {
        DecreaseLightAngle();
        DecreateLightIntensity();
    }

    public void RestoreLightAngle() {
        myLight.spotAngle = maximumSpotAngle;
    }

    public void RestoreLightIntensity(float restoreIntensity) {
        myLight.intensity += restoreIntensity;
    }

    private void DecreateLightIntensity() {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle() {
        if (myLight.spotAngle > minimumSpotAngle) {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }
}
