using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAmmunitionBehavior
{
    public abstract void Travel(Transform transform, Vector3 targetPosition);
    public abstract void Travel(Transform transform);
}