using UnityEngine;

public class Ammunition : MonoBehaviour {
    [SerializeField] AmmunitionSlot[] ammunitionSlots;

    [System.Serializable]
    private class AmmunitionSlot {
        public AmmunitionType ammunitionType;
        public int ammunitionAmount;
    }

    public int GetAmmunitionAmount(AmmunitionType ammoType) {
        return GetAmmunitionSlot(ammoType).ammunitionAmount;
    }

    public void ExpendAmmunition(AmmunitionType ammoType) {
        GetAmmunitionSlot(ammoType).ammunitionAmount--;
    }

    public void AcquireAmmunition(AmmunitionType ammoType, int amount) {
        GetAmmunitionSlot(ammoType).ammunitionAmount += amount;
    }

    private AmmunitionSlot GetAmmunitionSlot(AmmunitionType ammunitionType) {
        foreach (AmmunitionSlot ammunitionSlot in ammunitionSlots) {
            if (ammunitionSlot.ammunitionType.Equals(ammunitionType)) {
                return ammunitionSlot;
            }
        }
        return null;
    }
}
