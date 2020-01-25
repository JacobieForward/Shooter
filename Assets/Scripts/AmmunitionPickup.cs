using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPickup : MonoBehaviour {
    [SerializeField] int ammunitionAmount = 5;
    [SerializeField] AmmunitionType ammunitionType = AmmunitionType.Bullets;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<Ammunition>().AcquireAmmunition(ammunitionType, ammunitionAmount);
            print("got ammuntion");
        }
        Destroy(gameObject);
    }
}
