using UnityEngine;

public class AmmunitionSpawner : MonoBehaviour
{
    public AmmunitionSO[] ammunitionTypes; // List of all ammunition types as ScriptableObjects

    public AmmunitionController SpawnAmmunition(AmmunitionSO ammunitionSO, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = ammunitionSO.prefab;
        GameObject instance = Instantiate(prefab, position, rotation);

        // Create the corresponding controller based on the ammunition type
        switch (ammunitionSO.ammunitionType)
        {
            case AmmunitionType.Highly_Explosive_Rounds:
                return new HighlyExplosiveRoundsController(new HighlyExplosiveRoundsModel(ammunitionSO), instance.GetComponent<HighlyExplosiveRoundsView>());
            case AmmunitionType.Guided_Missiles:
                return new GuidedMissilesController(new GuidedMissilesModel(ammunitionSO), instance.GetComponent<GuidedMissilesView>());
            case AmmunitionType.Armour_Piercing_Rounds:
                return new ArmourPiercingRoundsController(new ArmourPiercingRoundsModel(ammunitionSO), instance.GetComponent<ArmourPiercingRoundsView>());
            default:
                return null;
        }
    }
}
