using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuidedMissilesController : AmmunitionController
{
    private EnemyView lockedTarget;

    private GuidedMissilesModel guidedMissilesModel;
    private GuidedMissilesView guidedMissilesView;

    private bool hasnotbeenColidedYet = true;

    public GuidedMissilesController(GuidedMissilesModel model, GuidedMissilesView view)
        : base(model, view)
    {
        guidedMissilesModel = model;
        guidedMissilesView = view;
        ammunitionBehavior = new GuidedMissilesBehavior(guidedMissilesModel.MovementSpeed, guidedMissilesModel.TargetEnemyView.transform, guidedMissilesView.AscentDuration);
    }

    public override void Fire()
    {
        guidedMissilesView.ShowFireEffect();
        guidedMissilesView.PlaySoundEffect();
        guidedMissilesView.ShowAmmunitionTrail();

        guidedMissilesView.StartCoroutine(TravelCoroutine());

    }

    private IEnumerator TravelCoroutine()
    {
        while (hasnotbeenColidedYet && guidedMissilesModel.TargetEnemyView != null)
        {
            ammunitionBehavior.Travel(guidedMissilesView.transform);
            //armourPiercingRoundsView.ShowAmmunitionTrail();
            yield return null;
        }

        if (!hasnotbeenColidedYet || guidedMissilesModel.TargetEnemyView == null)
        {
            AmmunitionEndSequence();
        }
    }

    public override void OnCollision(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyView>() == guidedMissilesModel.TargetEnemyView)
        {
            hasnotbeenColidedYet = false;
            ResultDamage(guidedMissilesModel.TargetEnemyView);
            Debug.Log("hit");
        }

    }

    public override void ResultDamage(EnemyView enemyView)
    {
        //enemy will get damage.
        float totalDamage = guidedMissilesModel.BaseDamage;
        Debug.Log($"Total damage is: {totalDamage}");
    }

    public override void AmmunitionEndSequence()
    {
        guidedMissilesView.ShowExplosionEffect();
        //explosion sound
        guidedMissilesView.PlaySoundEffect();
        //stop trail, deactivate ammunition mesh renderer and collider (trigger), play the effects
        guidedMissilesView.DeactivateAmmunition();

        // add a coroutine and destroy this game object.
        guidedMissilesView.StartCoroutine(SafeDestruction());
    }


    private IEnumerator SafeDestruction()
    {
        yield return new WaitForSeconds(2);
        Object.Destroy(guidedMissilesView.gameObject);
    }
}
