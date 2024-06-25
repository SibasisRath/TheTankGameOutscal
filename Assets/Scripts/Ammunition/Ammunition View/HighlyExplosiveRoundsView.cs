using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlyExplosiveRoundsView : AmmunitionView
{
    [SerializeField] private float arcHeight = 5f;
    [SerializeField] private Rigidbody rb;

    public float ArcHeight { get => arcHeight; }

    public override void ShowFireEffect()
    {
        // Implement fire effect
        Debug.Log("Showing fire effect for Highly Explosive Rounds.");
    }

    public override void ShowExplosionEffect()
    {
        // Implement explosion effect
        Debug.Log("Showing explosion effect for Highly Explosive Rounds.");
    }

    public override void PlaySoundEffect()
    {
        // Implement sound effect
        Debug.Log("Playing sound effect for Highly Explosive Rounds.");
    }

    public override void ShowAmmunitionTrail()
    {
        Debug.Log("Rendering ammunition trail.");
    }

    public override void DeactivateAmmunition()
    {
        ammunitionViewRenderer.enabled = false;
        rb.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"hit {other.name}");
        ammunitionController.OnCollision(other);
    }
}