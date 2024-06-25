using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GuidedMissilesView : AmmunitionView
{
    [SerializeField] private float ascentDuration;

    public float AscentDuration { get => ascentDuration; set => ascentDuration = value; }

    public override void ShowFireEffect()
    {
        Debug.Log("Showing fire effect for Guided Missiles.");
    }

    public override void ShowExplosionEffect()
    {
        Debug.Log("Showing explosion effect for Guided Missiles.");
    }

    public override void PlaySoundEffect()
    {
        Debug.Log("Playing sound effect for Guided Missiles.");
    }

    public override void ShowAmmunitionTrail()
    {
        Debug.Log("Rendering ammunition trail.");
    }

    public override void DeactivateAmmunition()
    {
        ammunitionViewRenderer.enabled = false;
        colider.enabled = false;
        Debug.Log("Deactivating collider and renderer");
    }

    private void OnTriggerEnter(Collider other)
    {
        ammunitionController.OnCollision(other);
    }
}
