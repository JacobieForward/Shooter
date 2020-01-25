using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {
    [SerializeField] Camera FirstPersonCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float weaponRange = 100f;
    [SerializeField] float timeBetweenShots = 0.2f;

    bool canShoot = true;
    [SerializeField] Text ammunitionText;

    [SerializeField] Ammunition ammunitionSlot;
    [SerializeField] AmmunitionType ammunitionType;

    private void OnEnable() {
        canShoot = true;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && canShoot) {
            StartCoroutine(Fire());
        }
        DisplayAmmo();
    }

    private void DisplayAmmo() {
        ammunitionText.text = ammunitionSlot.GetAmmunitionAmount(ammunitionType).ToString();
    }

    IEnumerator Fire() {
        canShoot = false;
        if (ammunitionSlot.GetAmmunitionAmount(ammunitionType) > 0) {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammunitionSlot.ExpendAmmunition(ammunitionType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void ProcessRaycast() {
        RaycastHit hit;
        if (Physics.Raycast(FirstPersonCamera.transform.position, FirstPersonCamera.transform.forward, out hit, range) && Vector3.Distance(gameObject.transform.position, hit.transform.position) < weaponRange) {
            SpawnHitEffect(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null) {
                target.TakeDamage(damage);
            }
        } else {
            return;
        }
    }

    private void PlayMuzzleFlash() {
        muzzleFlash.Play();
    }

    private void SpawnHitEffect(RaycastHit hit) {
        GameObject hitEffectInstance = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffectInstance, 1f);
    }
}
