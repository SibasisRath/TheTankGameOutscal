using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuidedMissilesBehavior : AbstractAmmunitionBehavior
{
    public Transform targetTransform;
    public float speed = 10f;
    public float ascentDuration = 1f; // Time in seconds for the missile to go up before tracking the target
    private float elapsedTime = 0f;
    private bool isAscending = true;

    public GuidedMissilesBehavior(float movementSpeed, Transform targetTransform, float ascentDuration)
    {
        this.speed = movementSpeed;
        this.targetTransform = targetTransform;
        this.ascentDuration = ascentDuration;
    }

    public override void Travel(Transform missileTransform)
    {
        elapsedTime += Time.deltaTime;

        if (isAscending)
        {
            // Move the missile upwards during the ascent phase
            missileTransform.position += Vector3.up * speed * Time.deltaTime;

            // Check if the ascent phase is over
            if (elapsedTime >= ascentDuration)
            {
                isAscending = false;
            }
        }
        else if (targetTransform != null)
        {
            // Track the target
            Vector3 direction = (targetTransform.position - missileTransform.position).normalized;
            missileTransform.position += direction * speed * Time.deltaTime;

            // Optional: Rotate the missile to face the target
            missileTransform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            return;
        }
    }
    public override void Travel(Transform missileTransform, Vector3 position) {}
}