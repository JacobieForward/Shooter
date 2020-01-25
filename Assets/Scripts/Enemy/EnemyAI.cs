using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 2f;

    EnemyHealth health;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().gameObject.transform;
    }

    void Update() {
        if (!health.GetIsDead()) {
            UpdateDistanceToTarget();

            if (isProvoked) {
                EngageTarget();
            } else if (distanceToTarget <= chaseRange) {
                isProvoked = true;
            }
        } else {
            enabled = false;
            navMeshAgent.enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    public void OnDamageTaken() {
        isProvoked = true;
    }

    private void EngageTarget() {
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
        FaceTarget();
    }

    private void ChaseTarget() {
        GetComponent<Animator>().SetTrigger("Move");
        SetTargetDestination();
        StopAttackTarget();
    }

    private void AttackTarget() {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void StopAttackTarget() {
        GetComponent<Animator>().SetBool("Attack", false);
    }

    private void SetTargetDestination() {
        navMeshAgent.SetDestination(target.position);
    }


    private void UpdateDistanceToTarget() {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
    }

    private void FaceTarget() {
        // transform.rotation = where the target is, rotate at a certain speed
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
