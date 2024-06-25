using System.Collections;
using UnityEngine;

public abstract class AmmunitionController
{
    protected AmmunitionModel ammunitionModel;
    protected AmmunitionView ammunitionView;
    protected AbstractAmmunitionBehavior ammunitionBehavior;

    public AmmunitionController(AmmunitionModel model, AmmunitionView view)
    {
        ammunitionModel = model;
        ammunitionView = view;
        ammunitionView.SetAmmunitionController(this);
    }

    public abstract void Fire();

    public abstract void OnCollision(Collider other);

    public abstract void AmmunitionEndSequence();

    public abstract void ResultDamage(EnemyView enemyView);
}

