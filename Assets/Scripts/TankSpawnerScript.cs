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
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(tanks[0].movementSpeed, tanks[0].rotationSpeed, tanks[0].type, tanks[0].color);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
