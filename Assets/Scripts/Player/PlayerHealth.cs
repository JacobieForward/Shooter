using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] float hitpoints = 10.0f;

    public void TakeDamage(float damage) {
        hitpoints -= damage;
        if (hitpoints <= 0) {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
