using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerScript : MonoBehaviour
{
    public List<TankSO> tanks;

    [SerializeField] private TankView tankView;

    public void CreateTank(TankTypes tankType)
    {
        foreach (TankSO tank in tanks) 
        {
            if (tankType == tank.TankType)
            {
                TankModel tankModel = new TankModel(tank.TankSpeed, tank.TankRotation, tank.TankType, tank.TankColor, tank.FireCoolDown, tank.TankAmmunitionType, tank.TankShootingBehavior);
                TankController tankController = new TankController(tankModel, tankView);
            }
        }
    }
}
