using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerScript : MonoBehaviour
{
    public List<TankSO> tanks;

    [SerializeField] private TankView tankView;

    public AmmunitionSpawner ammunitionSpawner;

    public void CreateTank(TankTypes tankType)
    {
        foreach (TankSO tank in tanks) 
        {
            if (tankType == tank.TankType)
            {
                TankModel tankModel = new TankModel(tank);
                TankController tankController = new TankController(tankModel, tankView, ammunitionSpawner);
            }
        }
    }
}
