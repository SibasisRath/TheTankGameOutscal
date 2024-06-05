using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerScript : MonoBehaviour
{
    [Serializable]
    public class Tank
    {
        public TankTypes type;
        public float movementSpeed;
        public float rotationSpeed;
        public Material color;
    }

    public List<Tank> tanks;

    [SerializeField] private TankView tankView;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void CreateTank(TankTypes tankType)
    {
        if (tankType == TankTypes.BlueTank)
        {
            TankModel tankModel = new TankModel(tanks[2].movementSpeed, tanks[2].rotationSpeed, tanks[2].type, tanks[2].color);
            TankController tankController = new TankController(tankModel, tankView);
        }

        else if (tankType == TankTypes.RedTank)
        {
            TankModel tankModel = new TankModel(tanks[1].movementSpeed, tanks[1].rotationSpeed, tanks[1].type, tanks[1].color);
            TankController tankController = new TankController(tankModel, tankView);
        }

        else if (tankType == TankTypes.GreenTank)
        {
            TankModel tankModel = new TankModel(tanks[0].movementSpeed, tanks[0].rotationSpeed, tanks[0].type, tanks[0].color);
            TankController tankController = new TankController(tankModel, tankView);
        }


    }
}
