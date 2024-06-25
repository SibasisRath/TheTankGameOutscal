using UnityEngine;

public abstract class AmmunitionModel
{
   // protected float thresholdDamage; // because we are multiplying the damage
    public AmmunitionType AmmunitionType { get; protected set; }
    public GameObject Prefab {  get; protected set; }
    public float BaseDamage { get; protected set; }
    public float MovementSpeed { get; protected set; }

    public AudioClip FireSound { get; protected set; }
    public AudioClip ExplosionSound { get; protected set; }
    public TrailRenderer TrailRenderer { get; protected set; }
    public ParticleSystem FireEffect { get; protected set; }
    public ParticleSystem ExplosionEffect { get; protected set; }

    public AmmunitionModel(AmmunitionSO ammunitionSO)
    {
        AmmunitionType = ammunitionSO.ammunitionType;
        Prefab = ammunitionSO.prefab;
        BaseDamage = ammunitionSO.baseDamage;
        MovementSpeed = ammunitionSO.movementSpeed;
    }
}

