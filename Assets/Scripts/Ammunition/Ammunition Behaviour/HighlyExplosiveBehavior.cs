using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighlyExplosiveBehavior : AbstractAmmunitionBehavior
{
    private float speed;
    private float arcHeight;

    public float power = 50f; // The power with which the projectile is thrown

    public HighlyExplosiveBehavior(float speed, float arcHeight)
    {
        this.speed = speed;
        this.arcHeight = arcHeight;
    }
    public override void Travel(Transform transform, Vector3 targetPosition)
    {

    }

    public override void Travel(Transform transform) 
    {

        Rigidbody rb = transform.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on this object.");
            return;
        }

        // Normalize direction to get only direction information without magnitude
        Vector3 normalizedDirection = transform.forward;

        // Calculate the initial velocity components
        float initialHorizontalVelocity = Mathf.Sqrt(power) * Mathf.Cos(45 * Mathf.Deg2Rad);
        float initialVerticalVelocity = Mathf.Sqrt(power) * Mathf.Sin(45 * Mathf.Deg2Rad);

        // Combine horizontal and vertical velocities
        Vector3 initialVelocity = (normalizedDirection * initialHorizontalVelocity) + (Vector3.up * initialVerticalVelocity);

        // Apply the initial velocity to the Rigidbody
        rb.velocity = initialVelocity;
    }
}
