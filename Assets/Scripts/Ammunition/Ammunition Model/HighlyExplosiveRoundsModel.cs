using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlyExplosiveRoundsModel : AmmunitionModel
{
    public float BaseExplosionRadious {  get; protected set; }
    public float ExplosionRadiousMultiplier { get; protected set; }
    public HighlyExplosiveRoundsModel(AmmunitionSO ammunitionSO) : base(ammunitionSO) 
    {
        BaseExplosionRadious = ammunitionSO.baseExplosionRadious;
        ExplosionRadiousMultiplier = ammunitionSO.explosionRadiousMultiplier;
    }
}
