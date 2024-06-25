using UnityEngine;

[CreateAssetMenu(fileName = "NewRounds", menuName = "ScriptableObjects/Ammunition")]
public class AmmunitionSO : ScriptableObject
{
    public AmmunitionType ammunitionType;

    public GameObject prefab; // Reference to the ammunition prefab
    private EnemyView targetEnemy; // only for guided missile
    
    public float baseDamage; // this present for all.
    
    // in armour piercing missiles this will make more damage and in Highly explosive missiles this will cover more are.
    public float damageMultiplier;

    // these two are needed for Highly explosive missiles.
    public float baseExplosionRadious;
    public float explosionRadiousMultiplier; 
    
    public float movementSpeed;
    public float lifeSpan;

    public AudioClip fireSound;
    public AudioClip explosionSound;
    public TrailRenderer trailRenderer;
    public ParticleSystem fireEffect;
    public ParticleSystem explosionEffect;

    public void SetSelectedEnemy(EnemyView selectedEnemy) { targetEnemy = selectedEnemy; }
    public EnemyView GetSelectedEnemy() {  return targetEnemy; }
}
