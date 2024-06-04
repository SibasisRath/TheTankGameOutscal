using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerScript : MonoBehaviour
{
    [SerializeField] private TankView tankView;
    // Start is called before the first frame update
    void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(30,80);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
