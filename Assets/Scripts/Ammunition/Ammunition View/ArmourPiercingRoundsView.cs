using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPiercingRoundsView : AmmunitionView
{

    public override void ShowFireEffect()
    {
        Debug.Log("Showing fire effect for Armour Piercing Rounds.");
    }

    public override void ShowExplosionEffect()
    {
        Debug.Log("Showing explosion effect for Armour Piercing Rounds.");
    }

    public override void PlaySoundEffect()
    {
        Debug.Log("Playing sound effect for Armour Piercing Rounds.");
    }

    public override void ShowAmmunitionTrail()
    {
        Debug.Log("Rendering ammunition trail.");
    }

    // Add on trigger method for detecting collisions with single enemy.
    private void OnTriggerEnter(Collider other)
    {
        ammunitionController.OnCollision(other);
    }

    public override void DeactivateAmmunition()
    {
        ammunitionViewRenderer.enabled = false;
        colider.enabled = false;
        Debug.Log("Deactivating collider and renderer");
    }
    // if collision happens then follow the enemy damage part or
    // Add Self destruction coroutine method.
}
