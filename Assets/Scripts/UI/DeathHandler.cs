using UnityEngine;

public class DeathHandler : MonoBehaviour {
    [SerializeField] Canvas gameOverCanvas;

    private void Start() {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath() {
        gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().gameObject.SetActive(false);
    }
}
