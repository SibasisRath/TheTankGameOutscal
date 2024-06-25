using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissilesModel : AmmunitionModel
{
    public EnemyView TargetEnemyView { get; set; }
    public GuidedMissilesModel(AmmunitionSO ammunitionSO) : base(ammunitionSO) 
    {
        TargetEnemyView = ammunitionSO.GetSelectedEnemy();
    }
}
