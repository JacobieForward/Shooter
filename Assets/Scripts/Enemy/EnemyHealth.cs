using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] float hitpoints = 100f;

    bool isDead = false;

    public void TakeDamage(float damage) {
        BroadcastMessage("OnDamageTaken");
        hitpoints -= damage;
        if (hitpoints <= 0 && !isDead) {
            Die();
        }
    }

    private void Die() {
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }

    public bool GetIsDead() {
        return isDead;
    }
}
