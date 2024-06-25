using UnityEngine;

public class BaseShootingBehavior : ScriptableObject
{
    public virtual bool Shoot(EnemyView lockedTarget) {  return false; }

    public virtual bool Shoot(out float range) 
    {
        range = 0f;
        return false; 
    }

    public virtual EnemyView SelectTarget() {  return null; }
}
