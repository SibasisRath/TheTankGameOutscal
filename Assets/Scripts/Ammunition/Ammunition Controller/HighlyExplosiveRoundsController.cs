using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighlyExplosiveRoundsController : AmmunitionController
{
    private HighlyExplosiveRoundsModel highlyExplosiveRoundsModel;
    private HighlyExplosiveRoundsView highlyExplosiveRoundsView;

    public HighlyExplosiveRoundsController(HighlyExplosiveRoundsModel model, HighlyExplosiveRoundsView view)
        : base(model, view)
    {
        highlyExplosiveRoundsModel = model;
        highlyExplosiveRoundsView = view;
        ammunitionBehavior = new HighlyExplosiveBehavior(highlyExplosiveRoundsModel.MovementSpeed, highlyExplosiveRoundsView.ArcHeight);
    }

    public override void Fire()
    {
        highlyExplosiveRoundsView.ShowFireEffect();
        highlyExplosiveRoundsView.PlaySoundEffect();
        highlyExplosiveRoundsView.ShowAmmunitionTrail();

        ammunitionBehavior.Travel(highlyExplosiveRoundsView.transform);
    }

    public override void OnCollision(Collider other)
    {
        // Perform the sphere cast
        Vector3 origin = highlyExplosiveRoundsView.transform.position;
        float sphereRadius = highlyExplosiveRoundsModel.BaseExplosionRadious * highlyExplosiveRoundsModel.ExplosionRadiousMultiplier;
        RaycastHit[] hits = Physics.SphereCastAll(origin, sphereRadius, Vector3.forward, 0f);

        foreach (RaycastHit hit in hits)
        {
            EnemyView enemyView = hit.collider.gameObject.GetComponent<EnemyView>();
            if (enemyView != null)
            {
                ResultDamage(enemyView);
            }            
        }
        AmmunitionEndSequence();
    }


    public override void AmmunitionEndSequence()
    {
        highlyExplosiveRoundsView.ShowExplosionEffect();
        //explosion sound
        highlyExplosiveRoundsView.PlaySoundEffect();
        //stop trail, deactivate ammunition mesh renderer and collider (trigger), play the effects
        highlyExplosiveRoundsView.DeactivateAmmunition();

        // add a coroutine and destroy this game object.
        highlyExplosiveRoundsView.StartCoroutine(SafeDestruction());
    }

    private IEnumerator SafeDestruction()
    {
        yield return new WaitForSeconds(2);
        Object.Destroy(highlyExplosiveRoundsView.gameObject);
    }

    public override void ResultDamage(EnemyView enemyView)
    {
        float totalDamage = highlyExplosiveRoundsModel.BaseDamage;
        //enemy will get damage here.
        Debug.Log($"total damage: {totalDamage}");
    }
}
