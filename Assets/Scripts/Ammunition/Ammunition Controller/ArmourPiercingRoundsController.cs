using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ArmourPiercingRoundsController : AmmunitionController
{
    private ArmourPiercingRoundsModel armourPiercingRoundsModel;
    private ArmourPiercingRoundsView armourPiercingRoundsView;

    private bool hasnotbeenColidedYet = true;
    public ArmourPiercingRoundsController(ArmourPiercingRoundsModel model, ArmourPiercingRoundsView view)
        : base(model, view)
    {
        armourPiercingRoundsModel = model;
        armourPiercingRoundsView = view;
        ammunitionBehavior = new ArmourPiercingBehavior(armourPiercingRoundsModel.MovementSpeed);
    }

    public override void Fire() 
    {
        armourPiercingRoundsView.ShowFireEffect();
        armourPiercingRoundsView.PlaySoundEffect();
        armourPiercingRoundsView.ShowAmmunitionTrail();


        armourPiercingRoundsView.StartCoroutine(TravelCoroutine());

    }

    private IEnumerator TravelCoroutine()
    {
        while (armourPiercingRoundsModel.LifeSpan > 0.1f && hasnotbeenColidedYet)
        {
            ammunitionBehavior.Travel(armourPiercingRoundsView.transform);
            //armourPiercingRoundsView.ShowAmmunitionTrail();
            armourPiercingRoundsModel.LifeSpan -= armourPiercingRoundsModel.LifeSpan * Time.deltaTime;
            yield return null;
        }

        if (armourPiercingRoundsModel.LifeSpan <= 0.1f && !hasnotbeenColidedYet)
        {
            AmmunitionEndSequence();
        }
    }

    public override void OnCollision(Collider other)
    {
        Debug.Log("You hit.");
        hasnotbeenColidedYet = false;
        EnemyView enemyView = other.gameObject.GetComponent<EnemyView>();
        if (enemyView != null)
        {
            ResultDamage(enemyView);
        }

        AmmunitionEndSequence();
    }

    public override void AmmunitionEndSequence() 
    {
        armourPiercingRoundsView.ShowExplosionEffect();
        //explosion sound
        armourPiercingRoundsView.PlaySoundEffect();
        //stop trail, deactivate ammunition mesh renderer and collider (trigger), play the effects
        armourPiercingRoundsView.DeactivateAmmunition();

        // add a coroutine and destroy this game object.
        armourPiercingRoundsView.StartCoroutine(SafeDestruction());
    }

    private IEnumerator SafeDestruction()
    {
        yield return new WaitForSeconds(2);
        Object.Destroy(armourPiercingRoundsView.gameObject);
    }


    public override void ResultDamage(EnemyView enemyView)
    {
        //enemy will get damage.
        float totalDamage = ammunitionModel.BaseDamage * armourPiercingRoundsModel.DamageMultiplier;
        Debug.Log($"Total damage is: {totalDamage}");
        
    }
}

