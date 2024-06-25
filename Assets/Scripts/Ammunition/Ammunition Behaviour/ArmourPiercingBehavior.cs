using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmourPiercingBehavior : AbstractAmmunitionBehavior
{
    private float speed;

    public ArmourPiercingBehavior(float speed)
    {
        this.speed = speed;
    }

    public override void Travel(Transform transform, Vector3 targetPosition){ }

    public override void Travel(Transform transform)
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}