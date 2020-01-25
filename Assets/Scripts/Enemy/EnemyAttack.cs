using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    PlayerHealth target;
    [SerializeField] float damage = 1.0f;

    private void Awake() {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent() {
        if (target == null) {
            return;
        }
        target.TakeDamage(damage);
        target.GetComponent<DamageEffect>().ShowDamage();
    }
}
