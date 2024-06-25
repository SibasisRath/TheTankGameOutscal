using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPiercingRoundsModel : AmmunitionModel
{
    public float LifeSpan {  get; set; }
    public float DamageMultiplier {  get; set; }
    public ArmourPiercingRoundsModel(AmmunitionSO ammunitionSO) : base(ammunitionSO) 
    {
        LifeSpan = ammunitionSO.lifeSpan;
        DamageMultiplier = ammunitionSO.damageMultiplier;
    }
}