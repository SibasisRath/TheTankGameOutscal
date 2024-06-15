using UnityEngine;

public abstract class ShootingBehavior : ScriptableObject
{
    public abstract bool Shoot(TankView tankView);
}
